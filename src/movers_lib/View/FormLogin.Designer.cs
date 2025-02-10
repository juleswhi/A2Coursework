namespace View;

partial class FormLogin
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtBoxUsername = new MaterialSkin.Controls.MaterialTextBox2();
        txtBoxPassword = new MaterialSkin.Controls.MaterialTextBox2();
        btnLogin = new MaterialSkin.Controls.MaterialButton();
        SuspendLayout();
        // 
        // txtBoxUsername
        // 
        txtBoxUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        txtBoxUsername.AnimateReadOnly = false;
        txtBoxUsername.BackgroundImageLayout = ImageLayout.None;
        txtBoxUsername.CharacterCasing = CharacterCasing.Normal;
        txtBoxUsername.Depth = 0;
        txtBoxUsername.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
        txtBoxUsername.HideSelection = true;
        txtBoxUsername.LeadingIcon = null;
        txtBoxUsername.Location = new Point(239, 138);
        txtBoxUsername.MaxLength = 32767;
        txtBoxUsername.MinimumSize = new Size(185, 0);
        txtBoxUsername.MouseState = MaterialSkin.MouseState.OUT;
        txtBoxUsername.Name = "txtBoxUsername";
        txtBoxUsername.PasswordChar = '\0';
        txtBoxUsername.PrefixSuffixText = null;
        txtBoxUsername.ReadOnly = false;
        txtBoxUsername.RightToLeft = RightToLeft.No;
        txtBoxUsername.SelectedText = "";
        txtBoxUsername.SelectionLength = 0;
        txtBoxUsername.SelectionStart = 0;
        txtBoxUsername.ShortcutsEnabled = true;
        txtBoxUsername.Size = new Size(185, 48);
        txtBoxUsername.TabIndex = 0;
        txtBoxUsername.TabStop = false;
        txtBoxUsername.TextAlign = HorizontalAlignment.Left;
        txtBoxUsername.TrailingIcon = null;
        txtBoxUsername.UseSystemPasswordChar = false;
        // 
        // txtBoxPassword
        // 
        txtBoxPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        txtBoxPassword.AnimateReadOnly = false;
        txtBoxPassword.BackgroundImageLayout = ImageLayout.None;
        txtBoxPassword.CharacterCasing = CharacterCasing.Normal;
        txtBoxPassword.Depth = 0;
        txtBoxPassword.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
        txtBoxPassword.HideSelection = true;
        txtBoxPassword.LeadingIcon = null;
        txtBoxPassword.Location = new Point(239, 192);
        txtBoxPassword.MaxLength = 32767;
        txtBoxPassword.MinimumSize = new Size(185, 0);
        txtBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
        txtBoxPassword.Name = "txtBoxPassword";
        txtBoxPassword.PasswordChar = '\0';
        txtBoxPassword.PrefixSuffixText = null;
        txtBoxPassword.ReadOnly = false;
        txtBoxPassword.RightToLeft = RightToLeft.No;
        txtBoxPassword.SelectedText = "";
        txtBoxPassword.SelectionLength = 0;
        txtBoxPassword.SelectionStart = 0;
        txtBoxPassword.ShortcutsEnabled = true;
        txtBoxPassword.Size = new Size(185, 48);
        txtBoxPassword.TabIndex = 1;
        txtBoxPassword.TabStop = false;
        txtBoxPassword.Text = "Password";
        txtBoxPassword.TextAlign = HorizontalAlignment.Left;
        txtBoxPassword.TrailingIcon = null;
        txtBoxPassword.UseSystemPasswordChar = false;
        // 
        // btnLogin
        // 
        btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        btnLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnLogin.Depth = 0;
        btnLogin.HighEmphasis = true;
        btnLogin.Icon = null;
        btnLogin.Location = new Point(258, 249);
        btnLogin.Margin = new Padding(4, 6, 4, 6);
        btnLogin.MinimumSize = new Size(150, 0);
        btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
        btnLogin.Name = "btnLogin";
        btnLogin.NoAccentTextColor = Color.Empty;
        btnLogin.Size = new Size(150, 36);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "Login";
        btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
        btnLogin.UseAccentColor = false;
        btnLogin.UseVisualStyleBackColor = true;
        // 
        // FormLogin
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.AntiqueWhite;
        ClientSize = new Size(800, 450);
        Controls.Add(btnLogin);
        Controls.Add(txtBoxPassword);
        Controls.Add(txtBoxUsername);
        MinimumSize = new Size(645, 205);
        Name = "FormLogin";
        Text = "FormLogin";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MaterialSkin.Controls.MaterialTextBox2 txtBoxUsername;
    private MaterialSkin.Controls.MaterialTextBox2 txtBoxPassword;
    private MaterialSkin.Controls.MaterialButton btnLogin;
}