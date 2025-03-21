using QuestPDF.Infrastructure;

namespace Reports;

public interface IReportModel {
    public string Title();
    public void ComposeBody(IContainer container);
}

