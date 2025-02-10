namespace movers_lib.View;

using MaterialSkin.Controls;
using movers_lib.forms;
using movers_lib.model;
using movers_lib.writeup_tools;

public partial class FormLogin : Form, IResizeable
{
    public FormLogin()
    {
        InitializeComponent();
        button_login.UseMnemonic = true;
        button_login.Text = "&Login";

        // StoryboardConverter.Convert();

        // FormCreate.do_something();

        button_login.Click += (_, _) => {
            // ShowGCF<FormViewModel, Customer>();
            ShowForm<FormMain>();
        };

        button_login.UseAccentColor = true;

        Controls.AddRange([
            textbox_username,
            textbox_password,
            button_login,
            half_panel
            ]);

        Resize += (s, e) =>
        {
            OnViewPortChanged();
        };
    }

    private MaterialMaskedTextBox textbox_username = new();
    private MaterialMaskedTextBox textbox_password = new();
    private MaterialButton button_login = new();
    private HalfPanel half_panel = new();

    public void OnViewPortChanged()
    {
        textbox_username!.CenterY((int)(textbox_username!.Height * 0.75));
        textbox_password!.CenterY(-(int)(textbox_password!.Height * 0.75));

        textbox_username!.CenterX(-Width / 4);
        textbox_password!.CenterX(-Width / 4);

        button_login!.CenterY(-(int)(textbox_username!.Height * 2.25));
        button_login!.CenterX(-Width / 4);

        half_panel.OnViewPortChanged(Size);
    }
}
