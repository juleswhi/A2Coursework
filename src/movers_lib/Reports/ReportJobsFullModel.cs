﻿using Model;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Reports;

public class ReportJobsFullModel : QuestPDF.Infrastructure.IDocument {
    public List<Clean> Cleans { get; set; } = DAL.
        Query<Clean>().
        ToList();

    public string Title() => "Cleaning Jobs";

    private void ComposeDescription(IContainer container) {
        container.Background(Colors.Grey.Lighten3).Padding(10).Column(column => {
            column.Spacing(5);
            column.Item().Text("Description").FontSize(14);
            column.Item().Text("All cleaning jobs, with all information included");
        });
    }

    public void Compose(IDocumentContainer container) {
        container.
            Page(page => {
                page.Margin(50);

                page.Header().Element(ComposeHeader);

                page.Content().Column(c => {
                    c.Item().Padding(10).Element(ComposeDescription);
                    c.Item().Element(ComposeBody);
                });

                page.Footer().AlignCenter().Text(x => {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
    }

    private void ComposeHeader(IContainer container) {
        container.Row(row => {
            row.RelativeItem().Column(column => {
                column.Item()
                    .Text(Title()).FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
            });
        });
    }

    // TODO: make it so that startdate can be in the past

    public void ComposeBody(IContainer container) {
        container.Table(table => {
            table.ColumnsDefinition(columns => {
                // columns.ConstantColumn(50);
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            table.Header(header => {
                // header.Cell().Element(CellStyle).Text("Id");
                header.Cell().Element(CellStyle).Text("Customer Name");
                header.Cell().Element(CellStyle).AlignRight().Text("Book Date");
                header.Cell().Element(CellStyle).AlignRight().Text("Start Date");
                header.Cell().Element(CellStyle).AlignRight().Text("End Date");
                header.Cell().Element(CellStyle).AlignRight().Text("Price");
                header.Cell().Element(CellStyle).AlignRight().Text("Paid");

                static IContainer CellStyle(IContainer container) {
                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                }
            });

            foreach (var item in Cleans) {
                var cust = DAL.Query<Customer>().First(x => x.Id == item.CustomerId);
                table.Cell().Element(CellStyle).Text($"{cust.Forename[0]}. {cust.Surname}");
                table.Cell().Element(CellStyle).AlignRight().Text(item.BookDate.ToString());
                table.Cell().Element(CellStyle).AlignRight().Text(item.StartDate.ToString());
                table.Cell().Element(CellStyle).AlignRight().Text(item.EndDate.ToString());
                table.Cell().Element(CellStyle).AlignRight().Text($"£{item.Price.ToString()}");
                table.Cell().Element(CellStyle).AlignRight().Text(item.Paid ? "Y" : "N");

                static IContainer CellStyle(IContainer container) {
                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            }
        });
    }
}
