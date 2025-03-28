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
    private void InitializeComponent() {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
        materialDrawer1 = new MaterialSkin.Controls.MaterialDrawer();
        materialCard1 = new MaterialSkin.Controls.MaterialCard();
        progressJobs = new MaterialSkin.Controls.MaterialProgressBar();
        labelJobsCount = new MaterialSkin.Controls.MaterialLabel();
        labelJobs = new MaterialSkin.Controls.MaterialLabel();
        btnActiveJobs = new MaterialSkin.Controls.MaterialFloatingActionButton();
        imageList1 = new ImageList(components);
        btnWorkingEmployees = new MaterialSkin.Controls.MaterialFloatingActionButton();
        materialCard2 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar2 = new MaterialSkin.Controls.MaterialProgressBar();
        labelWorkingEmployees = new MaterialSkin.Controls.MaterialLabel();
        labelEmployees = new MaterialSkin.Controls.MaterialLabel();
        cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
        materialCard3 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
        labelPendingDelivieriesValue = new MaterialSkin.Controls.MaterialLabel();
        labelPendingDelivieries = new MaterialSkin.Controls.MaterialLabel();
        btnPendingDeliveries = new MaterialSkin.Controls.MaterialFloatingActionButton();
        materialCard1.SuspendLayout();
        materialCard2.SuspendLayout();
        materialCard3.SuspendLayout();
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
        materialCard1.Controls.Add(progressJobs);
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
        // progressJobs
        // 
        progressJobs.Depth = 0;
        progressJobs.Location = new Point(17, 91);
        progressJobs.MouseState = MaterialSkin.MouseState.HOVER;
        progressJobs.Name = "progressJobs";
        progressJobs.Size = new Size(190, 5);
        progressJobs.TabIndex = 2;
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
        // btnActiveJobs
        // 
        btnActiveJobs.Depth = 0;
        btnActiveJobs.Icon = (Image)resources.GetObject("btnActiveJobs.Icon");
        btnActiveJobs.ImageKey = "calender.png";
        btnActiveJobs.ImageList = imageList1;
        btnActiveJobs.Location = new Point(208, 50);
        btnActiveJobs.MouseState = MaterialSkin.MouseState.HOVER;
        btnActiveJobs.Name = "btnActiveJobs";
        btnActiveJobs.Size = new Size(56, 56);
        btnActiveJobs.TabIndex = 12;
        btnActiveJobs.Text = "materialFloatingActionButton1";
        btnActiveJobs.UseVisualStyleBackColor = false;
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
        // btnWorkingEmployees
        // 
        btnWorkingEmployees.Depth = 0;
        btnWorkingEmployees.Icon = movers_lib.Properties.Resources.users;
        btnWorkingEmployees.ImageKey = "users.png";
        btnWorkingEmployees.ImageList = imageList1;
        btnWorkingEmployees.Location = new Point(468, 52);
        btnWorkingEmployees.MouseState = MaterialSkin.MouseState.HOVER;
        btnWorkingEmployees.Name = "btnWorkingEmployees";
        btnWorkingEmployees.Size = new Size(56, 56);
        btnWorkingEmployees.TabIndex = 14;
        btnWorkingEmployees.Text = "materialFloatingActionButton2";
        btnWorkingEmployees.UseVisualStyleBackColor = false;
        // 
        // materialCard2
        // 
        materialCard2.BackColor = Color.FromArgb(255, 255, 255);
        materialCard2.Controls.Add(materialProgressBar2);
        materialCard2.Controls.Add(labelWorkingEmployees);
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
        // labelWorkingEmployees
        // 
        labelWorkingEmployees.AutoSize = true;
        labelWorkingEmployees.Depth = 0;
        labelWorkingEmployees.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelWorkingEmployees.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelWorkingEmployees.Location = new Point(17, 42);
        labelWorkingEmployees.MouseState = MaterialSkin.MouseState.HOVER;
        labelWorkingEmployees.Name = "labelWorkingEmployees";
        labelWorkingEmployees.Size = new Size(85, 41);
        labelWorkingEmployees.TabIndex = 3;
        labelWorkingEmployees.Text = "XXXX";
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
        // materialCard3
        // 
        materialCard3.BackColor = Color.FromArgb(255, 255, 255);
        materialCard3.Controls.Add(materialProgressBar1);
        materialCard3.Controls.Add(labelPendingDelivieriesValue);
        materialCard3.Controls.Add(labelPendingDelivieries);
        materialCard3.Depth = 0;
        materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard3.Location = new Point(274, 182);
        materialCard3.Margin = new Padding(14);
        materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard3.Name = "materialCard3";
        materialCard3.Padding = new Padding(14);
        materialCard3.Size = new Size(224, 113);
        materialCard3.TabIndex = 16;
        // 
        // materialProgressBar1
        // 
        materialProgressBar1.Depth = 0;
        materialProgressBar1.Location = new Point(17, 91);
        materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar1.Name = "materialProgressBar1";
        materialProgressBar1.Size = new Size(190, 5);
        materialProgressBar1.TabIndex = 3;
        // 
        // labelPendingDelivieriesValue
        // 
        labelPendingDelivieriesValue.AutoSize = true;
        labelPendingDelivieriesValue.Depth = 0;
        labelPendingDelivieriesValue.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelPendingDelivieriesValue.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelPendingDelivieriesValue.Location = new Point(17, 42);
        labelPendingDelivieriesValue.MouseState = MaterialSkin.MouseState.HOVER;
        labelPendingDelivieriesValue.Name = "labelPendingDelivieriesValue";
        labelPendingDelivieriesValue.Size = new Size(85, 41);
        labelPendingDelivieriesValue.TabIndex = 3;
        labelPendingDelivieriesValue.Text = "XXXX";
        // 
        // labelPendingDelivieries
        // 
        labelPendingDelivieries.AutoSize = true;
        labelPendingDelivieries.Depth = 0;
        labelPendingDelivieries.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelPendingDelivieries.Location = new Point(17, 14);
        labelPendingDelivieries.MouseState = MaterialSkin.MouseState.HOVER;
        labelPendingDelivieries.Name = "labelPendingDelivieries";
        labelPendingDelivieries.Size = new Size(131, 19);
        labelPendingDelivieries.TabIndex = 3;
        labelPendingDelivieries.Text = "Pending Deliveries";
        // 
        // btnPendingDeliveries
        // 
        btnPendingDeliveries.Depth = 0;
        btnPendingDeliveries.Icon = movers_lib.Properties.Resources.users;
        btnPendingDeliveries.ImageKey = "users.png";
        btnPendingDeliveries.ImageList = imageList1;
        btnPendingDeliveries.Location = new Point(468, 211);
        btnPendingDeliveries.MouseState = MaterialSkin.MouseState.HOVER;
        btnPendingDeliveries.Name = "btnPendingDeliveries";
        btnPendingDeliveries.Size = new Size(56, 56);
        btnPendingDeliveries.TabIndex = 15;
        btnPendingDeliveries.Text = "materialFloatingActionButton2";
        btnPendingDeliveries.UseVisualStyleBackColor = false;
        // 
        // FormHome
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(562, 417);
        Controls.Add(btnPendingDeliveries);
        Controls.Add(materialCard3);
        Controls.Add(cartesianChart1);
        Controls.Add(btnWorkingEmployees);
        Controls.Add(btnActiveJobs);
        Controls.Add(materialCard2);
        Controls.Add(materialCard1);
        Controls.Add(materialDrawer1);
        Name = "FormHome";
        Text = "formBlank";
        materialCard1.ResumeLayout(false);
        materialCard1.PerformLayout();
        materialCard2.ResumeLayout(false);
        materialCard2.PerformLayout();
        materialCard3.ResumeLayout(false);
        materialCard3.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private MaterialSkin.Controls.MaterialDrawer materialDrawer1;
    private MaterialSkin.Controls.MaterialCard materialCard1;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnActiveJobs;
    private ImageList imageList1;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnWorkingEmployees;
    private MaterialSkin.Controls.MaterialCard materialCard2;
    private MaterialSkin.Controls.MaterialProgressBar progressJobs;
    private MaterialSkin.Controls.MaterialLabel labelJobsCount;
    private MaterialSkin.Controls.MaterialLabel labelJobs;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar2;
    private MaterialSkin.Controls.MaterialLabel labelWorkingEmployees;
    private MaterialSkin.Controls.MaterialLabel labelEmployees;
    private LiveCharts.WinForms.CartesianChart cartesianChart1;
    private MaterialSkin.Controls.MaterialCard materialCard3;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
    private MaterialSkin.Controls.MaterialLabel labelPendingDelivieriesValue;
    private MaterialSkin.Controls.MaterialLabel labelPendingDelivieries;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnPendingDeliveries;
}