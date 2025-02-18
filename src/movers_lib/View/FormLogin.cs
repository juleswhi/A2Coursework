namespace View;

public partial class FormLogin : Form {
    public FormLogin() {
        InitializeComponent();

        BackColor = Color.White;

        btnLogin.UseMnemonic = true;
        btnLogin.Text = "&Login";

        btnLogin.Click += (_, _) => {
            ShowForm<FormHome>();
        };

        btnLogin.UseAccentColor = true;
    }
}
