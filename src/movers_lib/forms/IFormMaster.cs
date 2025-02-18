namespace Forms;

public interface IFormMaster {
    public Form CurrentlyDisplayedForm { get; }
    Panel GetHolder();
    void LoadForm(Form form);
}