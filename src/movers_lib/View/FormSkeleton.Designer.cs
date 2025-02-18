namespace View;

partial class FormSkeleton
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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSkeleton));
        cardView = new MaterialSkin.Controls.MaterialCard();
        panelHolder = new Panel();
        imageList1 = new ImageList(components);
        cardSide = new MaterialSkin.Controls.MaterialCard();
        btnReports = new MaterialSkin.Controls.MaterialButton();
        btnHome = new MaterialSkin.Controls.MaterialButton();
        btnJobs = new MaterialSkin.Controls.MaterialButton();
        btnStock = new MaterialSkin.Controls.MaterialButton();
        btnStaff = new MaterialSkin.Controls.MaterialButton();
        btnSettings = new MaterialSkin.Controls.MaterialButton();
        cardView.SuspendLayout();
        cardSide.SuspendLayout();
        SuspendLayout();
        // 
        // cardView
        // 
        cardView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        cardView.BackColor = Color.FromArgb(255, 255, 255);
        cardView.Controls.Add(panelHolder);
        cardView.Depth = 0;
        cardView.ForeColor = Color.FromArgb(222, 0, 0, 0);
        cardView.Location = new Point(216, 5);
        cardView.Margin = new Padding(14);
        cardView.MouseState = MaterialSkin.MouseState.HOVER;
        cardView.Name = "cardView";
        cardView.Padding = new Padding(14);
        cardView.Size = new Size(582, 450);
        cardView.TabIndex = 2;
        // 
        // panelHolder
        // 
        panelHolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelHolder.Location = new Point(5, 4);
        panelHolder.Name = "panelHolder";
        panelHolder.Size = new Size(572, 440);
        panelHolder.TabIndex = 0;
        // 
        // imageList1
        // 
        imageList1.ColorDepth = ColorDepth.Depth32Bit;
        imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
        imageList1.TransparentColor = Color.Transparent;
        imageList1.Images.SetKeyName(0, "users.png");
        imageList1.Images.SetKeyName(1, "exit.png");
        imageList1.Images.SetKeyName(2, "settings.png");
        imageList1.Images.SetKeyName(3, "star.png");
        imageList1.Images.SetKeyName(4, "burger.png");
        imageList1.Images.SetKeyName(5, "house.png");
        // 
        // cardSide
        // 
        cardSide.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        cardSide.BackColor = Color.FromArgb(255, 255, 255);
        cardSide.Controls.Add(btnReports);
        cardSide.Controls.Add(btnHome);
        cardSide.Controls.Add(btnJobs);
        cardSide.Controls.Add(btnStock);
        cardSide.Controls.Add(btnStaff);
        cardSide.Controls.Add(btnSettings);
        cardSide.Depth = 0;
        cardSide.ForeColor = Color.FromArgb(222, 0, 0, 0);
        cardSide.Location = new Point(6, 5);
        cardSide.Margin = new Padding(14);
        cardSide.MouseState = MaterialSkin.MouseState.HOVER;
        cardSide.Name = "cardSide";
        cardSide.Padding = new Padding(14, 14, 14, 40);
        cardSide.Size = new Size(200, 450);
        cardSide.TabIndex = 3;
        // 
        // btnReports
        // 
        btnReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        btnReports.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnReports.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnReports.Depth = 0;
        btnReports.HighEmphasis = true;
        btnReports.Icon = (Image)resources.GetObject("btnReports.Icon");
        btnReports.Location = new Point(13, 309);
        btnReports.Margin = new Padding(0);
        btnReports.MinimumSize = new Size(172, 50);
        btnReports.MouseState = MaterialSkin.MouseState.HOVER;
        btnReports.Name = "btnReports";
        btnReports.NoAccentTextColor = Color.Empty;
        btnReports.Size = new Size(172, 50);
        btnReports.TabIndex = 6;
        btnReports.Text = "Reports";
        btnReports.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
        btnReports.UseAccentColor = false;
        btnReports.UseVisualStyleBackColor = true;
        // 
        // btnHome
        // 
        btnHome.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        btnHome.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnHome.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnHome.Depth = 0;
        btnHome.HighEmphasis = true;
        btnHome.Icon = (Image)resources.GetObject("btnHome.Icon");
        btnHome.Location = new Point(13, 21);
        btnHome.Margin = new Padding(0);
        btnHome.MinimumSize = new Size(172, 50);
        btnHome.MouseState = MaterialSkin.MouseState.HOVER;
        btnHome.Name = "btnHome";
        btnHome.NoAccentTextColor = Color.Empty;
        btnHome.Size = new Size(172, 50);
        btnHome.TabIndex = 5;
        btnHome.Text = "Home";
        btnHome.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
        btnHome.UseAccentColor = false;
        btnHome.UseVisualStyleBackColor = true;
        // 
        // btnJobs
        // 
        btnJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        btnJobs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnJobs.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnJobs.Depth = 0;
        btnJobs.HighEmphasis = true;
        btnJobs.Icon = (Image)resources.GetObject("btnJobs.Icon");
        btnJobs.Location = new Point(13, 93);
        btnJobs.Margin = new Padding(0);
        btnJobs.MinimumSize = new Size(172, 50);
        btnJobs.MouseState = MaterialSkin.MouseState.HOVER;
        btnJobs.Name = "btnJobs";
        btnJobs.NoAccentTextColor = Color.Empty;
        btnJobs.Size = new Size(172, 50);
        btnJobs.TabIndex = 4;
        btnJobs.Text = "Jobs";
        btnJobs.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
        btnJobs.UseAccentColor = false;
        btnJobs.UseVisualStyleBackColor = true;
        // 
        // btnStock
        // 
        btnStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        btnStock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnStock.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnStock.Depth = 0;
        btnStock.HighEmphasis = true;
        btnStock.Icon = (Image)resources.GetObject("btnStock.Icon");
        btnStock.Location = new Point(13, 165);
        btnStock.Margin = new Padding(0);
        btnStock.MinimumSize = new Size(172, 50);
        btnStock.MouseState = MaterialSkin.MouseState.HOVER;
        btnStock.Name = "btnStock";
        btnStock.NoAccentTextColor = Color.Empty;
        btnStock.Size = new Size(172, 50);
        btnStock.TabIndex = 3;
        btnStock.Text = "Stock";
        btnStock.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
        btnStock.UseAccentColor = false;
        btnStock.UseVisualStyleBackColor = true;
        // 
        // btnStaff
        // 
        btnStaff.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        btnStaff.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnStaff.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnStaff.Depth = 0;
        btnStaff.HighEmphasis = true;
        btnStaff.Icon = (Image)resources.GetObject("btnStaff.Icon");
        btnStaff.Location = new Point(13, 237);
        btnStaff.Margin = new Padding(0);
        btnStaff.MinimumSize = new Size(172, 50);
        btnStaff.MouseState = MaterialSkin.MouseState.HOVER;
        btnStaff.Name = "btnStaff";
        btnStaff.NoAccentTextColor = Color.Empty;
        btnStaff.Size = new Size(172, 50);
        btnStaff.TabIndex = 2;
        btnStaff.Text = "Staff";
        btnStaff.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
        btnStaff.UseAccentColor = false;
        btnStaff.UseVisualStyleBackColor = true;
        // 
        // btnSettings
        // 
        btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        btnSettings.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnSettings.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnSettings.Depth = 0;
        btnSettings.HighEmphasis = true;
        btnSettings.Icon = (Image)resources.GetObject("btnSettings.Icon");
        btnSettings.Location = new Point(13, 381);
        btnSettings.Margin = new Padding(0);
        btnSettings.MinimumSize = new Size(172, 50);
        btnSettings.MouseState = MaterialSkin.MouseState.HOVER;
        btnSettings.Name = "btnSettings";
        btnSettings.NoAccentTextColor = Color.Empty;
        btnSettings.Size = new Size(172, 50);
        btnSettings.TabIndex = 1;
        btnSettings.Text = "Settings";
        btnSettings.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
        btnSettings.UseAccentColor = false;
        btnSettings.UseVisualStyleBackColor = true;
        // 
        // FormSkeleton
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(804, 461);
        Controls.Add(cardSide);
        Controls.Add(cardView);
        MaximumSize = new Size(820, 500);
        MinimumSize = new Size(820, 500);
        Name = "FormSkeleton";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FormSkeleton";
        cardView.ResumeLayout(false);
        cardSide.ResumeLayout(false);
        cardSide.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private MaterialSkin.Controls.MaterialCard cardView;
    private Panel panelHolder;
    private ImageList imageList1;
    private MaterialSkin.Controls.MaterialCard cardSide;
    // private MaterialSkin.Controls.MaterialCard materialCard1;
    private MaterialSkin.Controls.MaterialButton btnStaff;
    private MaterialSkin.Controls.MaterialButton btnSettings;
    private MaterialSkin.Controls.MaterialButton btnStock;
    private MaterialSkin.Controls.MaterialButton btnJobs;
    private MaterialSkin.Controls.MaterialButton btnHome;
    private MaterialSkin.Controls.MaterialButton btnReports;
}