namespace View;

partial class FormHome
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
        materialDrawer1 = new MaterialSkin.Controls.MaterialDrawer();
        materialCard1 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
        labelJobsCount = new MaterialSkin.Controls.MaterialLabel();
        labelJobs = new MaterialSkin.Controls.MaterialLabel();
        materialFloatingActionButton1 = new MaterialSkin.Controls.MaterialFloatingActionButton();
        imageList1 = new ImageList(components);
        materialFloatingActionButton2 = new MaterialSkin.Controls.MaterialFloatingActionButton();
        materialCard2 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar2 = new MaterialSkin.Controls.MaterialProgressBar();
        materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
        labelEmployees = new MaterialSkin.Controls.MaterialLabel();
        cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
        materialCard1.SuspendLayout();
        materialCard2.SuspendLayout();
        SuspendLayout();
        // 
        // materialDrawer1
        // 
        materialDrawer1.AutoHide = false;
        materialDrawer1.AutoShow = false;
        materialDrawer1.BackgroundWithAccent = false;
        materialDrawer1.BaseTabControl = null;
        materialDrawer1.Depth = 0;
        materialDrawer1.HighlightWithAccent = true;
        materialDrawer1.IndicatorWidth = 0;
        materialDrawer1.IsOpen = false;
        materialDrawer1.Location = new Point(-250, 76);
        materialDrawer1.MouseState = MaterialSkin.MouseState.HOVER;
        materialDrawer1.Name = "materialDrawer1";
        materialDrawer1.ShowIconsWhenHidden = false;
        materialDrawer1.Size = new Size(250, 120);
        materialDrawer1.TabIndex = 10;
        materialDrawer1.Text = "materialDrawer1";
        materialDrawer1.UseColors = false;
        // 
        // materialCard1
        // 
        materialCard1.BackColor = Color.FromArgb(255, 255, 255);
        materialCard1.Controls.Add(materialProgressBar1);
        materialCard1.Controls.Add(labelJobsCount);
        materialCard1.Controls.Add(labelJobs);
        materialCard1.Depth = 0;
        materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard1.Location = new Point(14, 23);
        materialCard1.Margin = new Padding(14);
        materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard1.Name = "materialCard1";
        materialCard1.Padding = new Padding(14);
        materialCard1.Size = new Size(224, 113);
        materialCard1.TabIndex = 11;
        // 
        // materialProgressBar1
        // 
        materialProgressBar1.Depth = 0;
        materialProgressBar1.Location = new Point(17, 91);
        materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar1.Name = "materialProgressBar1";
        materialProgressBar1.Size = new Size(190, 5);
        materialProgressBar1.TabIndex = 2;
        // 
        // labelJobsCount
        // 
        labelJobsCount.AutoSize = true;
        labelJobsCount.Depth = 0;
        labelJobsCount.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelJobsCount.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelJobsCount.Location = new Point(17, 42);
        labelJobsCount.MouseState = MaterialSkin.MouseState.HOVER;
        labelJobsCount.Name = "labelJobsCount";
        labelJobsCount.Size = new Size(85, 41);
        labelJobsCount.TabIndex = 1;
        labelJobsCount.Text = "XXXX";
        // 
        // labelJobs
        // 
        labelJobs.AutoSize = true;
        labelJobs.Depth = 0;
        labelJobs.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelJobs.Location = new Point(17, 19);
        labelJobs.MouseState = MaterialSkin.MouseState.HOVER;
        labelJobs.Name = "labelJobs";
        labelJobs.Size = new Size(83, 19);
        labelJobs.TabIndex = 0;
        labelJobs.Text = "Active Jobs";
        // 
        // materialFloatingActionButton1
        // 
        materialFloatingActionButton1.Depth = 0;
        materialFloatingActionButton1.Icon = (Image)resources.GetObject("materialFloatingActionButton1.Icon");
        materialFloatingActionButton1.ImageKey = "calender.png";
        materialFloatingActionButton1.ImageList = imageList1;
        materialFloatingActionButton1.Location = new Point(208, 50);
        materialFloatingActionButton1.MouseState = MaterialSkin.MouseState.HOVER;
        materialFloatingActionButton1.Name = "materialFloatingActionButton1";
        materialFloatingActionButton1.Size = new Size(56, 56);
        materialFloatingActionButton1.TabIndex = 12;
        materialFloatingActionButton1.Text = "materialFloatingActionButton1";
        materialFloatingActionButton1.UseVisualStyleBackColor = false;
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
        imageList1.Images.SetKeyName(5, "calender.png");
        // 
        // materialFloatingActionButton2
        // 
        materialFloatingActionButton2.Depth = 0;
        materialFloatingActionButton2.Icon = movers_lib.Properties.Resources.users;
        materialFloatingActionButton2.ImageKey = "users.png";
        materialFloatingActionButton2.ImageList = imageList1;
        materialFloatingActionButton2.Location = new Point(468, 52);
        materialFloatingActionButton2.MouseState = MaterialSkin.MouseState.HOVER;
        materialFloatingActionButton2.Name = "materialFloatingActionButton2";
        materialFloatingActionButton2.Size = new Size(56, 56);
        materialFloatingActionButton2.TabIndex = 14;
        materialFloatingActionButton2.Text = "materialFloatingActionButton2";
        materialFloatingActionButton2.UseVisualStyleBackColor = false;
        // 
        // materialCard2
        // 
        materialCard2.BackColor = Color.FromArgb(255, 255, 255);
        materialCard2.Controls.Add(materialProgressBar2);
        materialCard2.Controls.Add(materialLabel1);
        materialCard2.Controls.Add(labelEmployees);
        materialCard2.Depth = 0;
        materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard2.Location = new Point(274, 24);
        materialCard2.Margin = new Padding(14);
        materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard2.Name = "materialCard2";
        materialCard2.Padding = new Padding(14);
        materialCard2.Size = new Size(224, 113);
        materialCard2.TabIndex = 13;
        // 
        // materialProgressBar2
        // 
        materialProgressBar2.Depth = 0;
        materialProgressBar2.Location = new Point(17, 91);
        materialProgressBar2.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar2.Name = "materialProgressBar2";
        materialProgressBar2.Size = new Size(190, 5);
        materialProgressBar2.TabIndex = 3;
        // 
        // materialLabel1
        // 
        materialLabel1.AutoSize = true;
        materialLabel1.Depth = 0;
        materialLabel1.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        materialLabel1.Location = new Point(17, 42);
        materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
        materialLabel1.Name = "materialLabel1";
        materialLabel1.Size = new Size(85, 41);
        materialLabel1.TabIndex = 3;
        materialLabel1.Text = "XXXX";
        // 
        // labelEmployees
        // 
        labelEmployees.AutoSize = true;
        labelEmployees.Depth = 0;
        labelEmployees.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelEmployees.Location = new Point(17, 14);
        labelEmployees.MouseState = MaterialSkin.MouseState.HOVER;
        labelEmployees.Name = "labelEmployees";
        labelEmployees.Size = new Size(140, 19);
        labelEmployees.TabIndex = 3;
        labelEmployees.Text = "Working Employees";
        // 
        // cartesianChart1
        // 
        cartesianChart1.Location = new Point(14, 153);
        cartesianChart1.Name = "cartesianChart1";
        cartesianChart1.Size = new Size(242, 142);
        cartesianChart1.TabIndex = 15;
        cartesianChart1.Text = "cartesianChart1";
        // 
        // FormHome
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(529, 381);
        Controls.Add(cartesianChart1);
        Controls.Add(materialFloatingActionButton2);
        Controls.Add(materialFloatingActionButton1);
        Controls.Add(materialCard2);
        Controls.Add(materialCard1);
        Controls.Add(materialDrawer1);
        Name = "FormHome";
        Text = "formBlank";
        materialCard1.ResumeLayout(false);
        materialCard1.PerformLayout();
        materialCard2.ResumeLayout(false);
        materialCard2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
    private MaterialSkin.Controls.MaterialCard materialCard1;
    private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton1;
    private ImageList imageList1;
    private MaterialSkin.Controls.MaterialFloatingActionButton materialFloatingActionButton2;
    private MaterialSkin.Controls.MaterialCard materialCard2;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
    private MaterialSkin.Controls.MaterialLabel labelJobsCount;
    private MaterialSkin.Controls.MaterialLabel labelJobs;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar2;
    private MaterialSkin.Controls.MaterialLabel materialLabel1;
    private MaterialSkin.Controls.MaterialLabel labelEmployees;
    private LiveCharts.WinForms.CartesianChart cartesianChart1;
}