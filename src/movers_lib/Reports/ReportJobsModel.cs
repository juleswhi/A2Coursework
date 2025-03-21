using Model;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Reports;

public class ReportJobsModel : IReportModel {
    public List<Clean> Cleans { get; set; } = DAL.Query<Clean>();

    public string Title() => "Cleaning Jobs";

    public void ComposeBody(IContainer container) {
        container
           .PaddingVertical(40)
           .Height(250)
           .Background(Colors.Grey.Lighten3)
           .AlignCenter()
           .AlignMiddle()
           .Text("Content").FontSize(16);


        container.Table(table => {
            table.ColumnsDefinition(columns => {
                columns.ConstantColumn(25);
                columns.RelativeColumn(3);
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            table.Header(header => {
                header.Cell().Element(CellStyle).Text("Id");
                header.Cell().Element(CellStyle).Text("Customer Name");
                header.Cell().Element(CellStyle).AlignRight().Text("StartDate");
                header.Cell().Element(CellStyle).AlignRight().Text("EndDate");
                header.Cell().Element(CellStyle).AlignRight().Text("Price");

                static IContainer CellStyle(IContainer container) {
                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                }
            });

            foreach (var item in Cleans) {
                table.Cell().Element(CellStyle).Text(item.Id.ToString());
                table.Cell().Element(CellStyle).Text(DAL.Query<Customer>().First(x => x.Id == item.CustomerId).Surname);
                table.Cell().Element(CellStyle).AlignRight().Text(item.StartDate.ToString());
                table.Cell().Element(CellStyle).AlignRight().Text(item.EndDate.ToString());
                table.Cell().Element(CellStyle).AlignRight().Text(item.Price.ToString());

                static IContainer CellStyle(IContainer container) {
                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            }
        });
    }
}
