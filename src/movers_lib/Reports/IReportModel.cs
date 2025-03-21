using QuestPDF.Infrastructure;

namespace Reports;

public interface IDocument {
    public string Title();
    public void ComposeBody(IContainer container);
}

