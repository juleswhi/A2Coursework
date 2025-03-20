namespace View;

partial class FormReports
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReports));
        materialCard1 = new MaterialSkin.Controls.MaterialCard();
        progressJobs = new MaterialSkin.Controls.MaterialProgressBar();
        labelReportOneTitle = new MaterialSkin.Controls.MaterialLabel();
        labelReportOneDescription = new MaterialSkin.Controls.MaterialLabel();
        btnReportOne = new MaterialSkin.Controls.MaterialFloatingActionButton();
        btnReportTwo = new MaterialSkin.Controls.MaterialFloatingActionButton();
        materialCard2 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
        labelReportTwoTitle = new MaterialSkin.Controls.MaterialLabel();
        labelReportTwoDescription = new MaterialSkin.Controls.MaterialLabel();
        btnReportFour = new MaterialSkin.Controls.MaterialFloatingActionButton();
        materialCard3 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar2 = new MaterialSkin.Controls.MaterialProgressBar();
        labelReportFourTitle = new MaterialSkin.Controls.MaterialLabel();
        labelReportFourDescription = new MaterialSkin.Controls.MaterialLabel();
        btnReportThree = new MaterialSkin.Controls.MaterialFloatingActionButton();
        materialCard4 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar3 = new MaterialSkin.Controls.MaterialProgressBar();
        labelReportThreeTitle = new MaterialSkin.Controls.MaterialLabel();
        labelReportThreeDescription = new MaterialSkin.Controls.MaterialLabel();
        btnReportSix = new MaterialSkin.Controls.MaterialFloatingActionButton();
        materialCard5 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar4 = new MaterialSkin.Controls.MaterialProgressBar();
        labelReportSixTitle = new MaterialSkin.Controls.MaterialLabel();
        labelReportSixDescription = new MaterialSkin.Controls.MaterialLabel();
        btnReportFive = new MaterialSkin.Controls.MaterialFloatingActionButton();
        materialCard6 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar5 = new MaterialSkin.Controls.MaterialProgressBar();
        labelReportFiveTitle = new MaterialSkin.Controls.MaterialLabel();
        labelReportFiveDescription = new MaterialSkin.Controls.MaterialLabel();
        imageList1 = new ImageList(components);
        materialCard1.SuspendLayout();
        materialCard2.SuspendLayout();
        materialCard3.SuspendLayout();
        materialCard4.SuspendLayout();
        materialCard5.SuspendLayout();
        materialCard6.SuspendLayout();
        SuspendLayout();
        // 
        // materialCard1
        // 
        materialCard1.BackColor = Color.FromArgb(255, 255, 255);
        materialCard1.Controls.Add(progressJobs);
        materialCard1.Controls.Add(labelReportOneTitle);
        materialCard1.Controls.Add(labelReportOneDescription);
        materialCard1.Depth = 0;
        materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard1.Location = new Point(24, 26);
        materialCard1.Margin = new Padding(14);
        materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard1.Name = "materialCard1";
        materialCard1.Padding = new Padding(14);
        materialCard1.Size = new Size(224, 113);
        materialCard1.TabIndex = 12;
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
        // labelReportOneTitle
        // 
        labelReportOneTitle.AutoSize = true;
        labelReportOneTitle.Depth = 0;
        labelReportOneTitle.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelReportOneTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelReportOneTitle.Location = new Point(17, 14);
        labelReportOneTitle.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportOneTitle.Name = "labelReportOneTitle";
        labelReportOneTitle.Size = new Size(87, 41);
        labelReportOneTitle.TabIndex = 1;
        labelReportOneTitle.Text = "TITLE";
        // 
        // labelReportOneDescription
        // 
        labelReportOneDescription.AutoSize = true;
        labelReportOneDescription.Depth = 0;
        labelReportOneDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelReportOneDescription.Location = new Point(17, 61);
        labelReportOneDescription.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportOneDescription.Name = "labelReportOneDescription";
        labelReportOneDescription.Size = new Size(81, 19);
        labelReportOneDescription.TabIndex = 0;
        labelReportOneDescription.Text = "Description";
        // 
        // btnReportOne
        // 
        btnReportOne.Depth = 0;
        btnReportOne.Icon = (Image)resources.GetObject("btnReportOne.Icon");
        btnReportOne.ImageKey = "eye.png";
        btnReportOne.ImageList = imageList1;
        btnReportOne.Location = new Point(219, 53);
        btnReportOne.MouseState = MaterialSkin.MouseState.HOVER;
        btnReportOne.Name = "btnReportOne";
        btnReportOne.Size = new Size(56, 56);
        btnReportOne.TabIndex = 13;
        btnReportOne.Text = "materialFloatingActionButton1";
        btnReportOne.UseVisualStyleBackColor = false;
        // 
        // btnReportTwo
        // 
        btnReportTwo.Depth = 0;
        btnReportTwo.Icon = (Image)resources.GetObject("btnReportTwo.Icon");
        btnReportTwo.ImageKey = "calender.png";
        btnReportTwo.Location = new Point(488, 53);
        btnReportTwo.MouseState = MaterialSkin.MouseState.HOVER;
        btnReportTwo.Name = "btnReportTwo";
        btnReportTwo.Size = new Size(56, 56);
        btnReportTwo.TabIndex = 15;
        btnReportTwo.Text = "materialFloatingActionButton1";
        btnReportTwo.UseVisualStyleBackColor = false;
        // 
        // materialCard2
        // 
        materialCard2.BackColor = Color.FromArgb(255, 255, 255);
        materialCard2.Controls.Add(materialProgressBar1);
        materialCard2.Controls.Add(labelReportTwoTitle);
        materialCard2.Controls.Add(labelReportTwoDescription);
        materialCard2.Depth = 0;
        materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard2.Location = new Point(293, 26);
        materialCard2.Margin = new Padding(14);
        materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard2.Name = "materialCard2";
        materialCard2.Padding = new Padding(14);
        materialCard2.Size = new Size(224, 113);
        materialCard2.TabIndex = 14;
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
        // labelReportTwoTitle
        // 
        labelReportTwoTitle.AutoSize = true;
        labelReportTwoTitle.Depth = 0;
        labelReportTwoTitle.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelReportTwoTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelReportTwoTitle.Location = new Point(17, 14);
        labelReportTwoTitle.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportTwoTitle.Name = "labelReportTwoTitle";
        labelReportTwoTitle.Size = new Size(87, 41);
        labelReportTwoTitle.TabIndex = 1;
        labelReportTwoTitle.Text = "TITLE";
        // 
        // labelReportTwoDescription
        // 
        labelReportTwoDescription.AutoSize = true;
        labelReportTwoDescription.Depth = 0;
        labelReportTwoDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelReportTwoDescription.Location = new Point(17, 61);
        labelReportTwoDescription.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportTwoDescription.Name = "labelReportTwoDescription";
        labelReportTwoDescription.Size = new Size(81, 19);
        labelReportTwoDescription.TabIndex = 0;
        labelReportTwoDescription.Text = "Description";
        // 
        // btnReportFour
        // 
        btnReportFour.Depth = 0;
        btnReportFour.Icon = (Image)resources.GetObject("btnReportFour.Icon");
        btnReportFour.ImageKey = "calender.png";
        btnReportFour.Location = new Point(488, 180);
        btnReportFour.MouseState = MaterialSkin.MouseState.HOVER;
        btnReportFour.Name = "btnReportFour";
        btnReportFour.Size = new Size(56, 56);
        btnReportFour.TabIndex = 19;
        btnReportFour.Text = "materialFloatingActionButton2";
        btnReportFour.UseVisualStyleBackColor = false;
        // 
        // materialCard3
        // 
        materialCard3.BackColor = Color.FromArgb(255, 255, 255);
        materialCard3.Controls.Add(materialProgressBar2);
        materialCard3.Controls.Add(labelReportFourTitle);
        materialCard3.Controls.Add(labelReportFourDescription);
        materialCard3.Depth = 0;
        materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard3.Location = new Point(293, 153);
        materialCard3.Margin = new Padding(14);
        materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard3.Name = "materialCard3";
        materialCard3.Padding = new Padding(14);
        materialCard3.Size = new Size(224, 113);
        materialCard3.TabIndex = 18;
        // 
        // materialProgressBar2
        // 
        materialProgressBar2.Depth = 0;
        materialProgressBar2.Location = new Point(17, 91);
        materialProgressBar2.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar2.Name = "materialProgressBar2";
        materialProgressBar2.Size = new Size(190, 5);
        materialProgressBar2.TabIndex = 2;
        // 
        // labelReportFourTitle
        // 
        labelReportFourTitle.AutoSize = true;
        labelReportFourTitle.Depth = 0;
        labelReportFourTitle.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelReportFourTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelReportFourTitle.Location = new Point(17, 14);
        labelReportFourTitle.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportFourTitle.Name = "labelReportFourTitle";
        labelReportFourTitle.Size = new Size(87, 41);
        labelReportFourTitle.TabIndex = 1;
        labelReportFourTitle.Text = "TITLE";
        // 
        // labelReportFourDescription
        // 
        labelReportFourDescription.AutoSize = true;
        labelReportFourDescription.Depth = 0;
        labelReportFourDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelReportFourDescription.Location = new Point(17, 61);
        labelReportFourDescription.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportFourDescription.Name = "labelReportFourDescription";
        labelReportFourDescription.Size = new Size(81, 19);
        labelReportFourDescription.TabIndex = 0;
        labelReportFourDescription.Text = "Description";
        // 
        // btnReportThree
        // 
        btnReportThree.Depth = 0;
        btnReportThree.Icon = (Image)resources.GetObject("btnReportThree.Icon");
        btnReportThree.ImageKey = "calender.png";
        btnReportThree.Location = new Point(219, 180);
        btnReportThree.MouseState = MaterialSkin.MouseState.HOVER;
        btnReportThree.Name = "btnReportThree";
        btnReportThree.Size = new Size(56, 56);
        btnReportThree.TabIndex = 17;
        btnReportThree.Text = "materialFloatingActionButton1";
        btnReportThree.UseVisualStyleBackColor = false;
        // 
        // materialCard4
        // 
        materialCard4.BackColor = Color.FromArgb(255, 255, 255);
        materialCard4.Controls.Add(materialProgressBar3);
        materialCard4.Controls.Add(labelReportThreeTitle);
        materialCard4.Controls.Add(labelReportThreeDescription);
        materialCard4.Depth = 0;
        materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard4.Location = new Point(24, 153);
        materialCard4.Margin = new Padding(14);
        materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard4.Name = "materialCard4";
        materialCard4.Padding = new Padding(14);
        materialCard4.Size = new Size(224, 113);
        materialCard4.TabIndex = 16;
        // 
        // materialProgressBar3
        // 
        materialProgressBar3.Depth = 0;
        materialProgressBar3.Location = new Point(17, 91);
        materialProgressBar3.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar3.Name = "materialProgressBar3";
        materialProgressBar3.Size = new Size(190, 5);
        materialProgressBar3.TabIndex = 2;
        // 
        // labelReportThreeTitle
        // 
        labelReportThreeTitle.AutoSize = true;
        labelReportThreeTitle.Depth = 0;
        labelReportThreeTitle.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelReportThreeTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelReportThreeTitle.Location = new Point(19, 14);
        labelReportThreeTitle.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportThreeTitle.Name = "labelReportThreeTitle";
        labelReportThreeTitle.Size = new Size(87, 41);
        labelReportThreeTitle.TabIndex = 1;
        labelReportThreeTitle.Text = "TITLE";
        // 
        // labelReportThreeDescription
        // 
        labelReportThreeDescription.AutoSize = true;
        labelReportThreeDescription.Depth = 0;
        labelReportThreeDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelReportThreeDescription.Location = new Point(17, 62);
        labelReportThreeDescription.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportThreeDescription.Name = "labelReportThreeDescription";
        labelReportThreeDescription.Size = new Size(81, 19);
        labelReportThreeDescription.TabIndex = 0;
        labelReportThreeDescription.Text = "Description";
        // 
        // btnReportSix
        // 
        btnReportSix.Depth = 0;
        btnReportSix.Icon = (Image)resources.GetObject("btnReportSix.Icon");
        btnReportSix.ImageKey = "calender.png";
        btnReportSix.Location = new Point(488, 304);
        btnReportSix.MouseState = MaterialSkin.MouseState.HOVER;
        btnReportSix.Name = "btnReportSix";
        btnReportSix.Size = new Size(56, 56);
        btnReportSix.TabIndex = 23;
        btnReportSix.Text = "materialFloatingActionButton4";
        btnReportSix.UseVisualStyleBackColor = false;
        // 
        // materialCard5
        // 
        materialCard5.BackColor = Color.FromArgb(255, 255, 255);
        materialCard5.Controls.Add(materialProgressBar4);
        materialCard5.Controls.Add(labelReportSixTitle);
        materialCard5.Controls.Add(labelReportSixDescription);
        materialCard5.Depth = 0;
        materialCard5.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard5.Location = new Point(293, 277);
        materialCard5.Margin = new Padding(14);
        materialCard5.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard5.Name = "materialCard5";
        materialCard5.Padding = new Padding(14);
        materialCard5.Size = new Size(224, 113);
        materialCard5.TabIndex = 22;
        // 
        // materialProgressBar4
        // 
        materialProgressBar4.Depth = 0;
        materialProgressBar4.Location = new Point(17, 91);
        materialProgressBar4.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar4.Name = "materialProgressBar4";
        materialProgressBar4.Size = new Size(190, 5);
        materialProgressBar4.TabIndex = 2;
        // 
        // labelReportSixTitle
        // 
        labelReportSixTitle.AutoSize = true;
        labelReportSixTitle.Depth = 0;
        labelReportSixTitle.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelReportSixTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelReportSixTitle.Location = new Point(13, 14);
        labelReportSixTitle.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportSixTitle.Name = "labelReportSixTitle";
        labelReportSixTitle.Size = new Size(87, 41);
        labelReportSixTitle.TabIndex = 1;
        labelReportSixTitle.Text = "TITLE";
        // 
        // labelReportSixDescription
        // 
        labelReportSixDescription.AutoSize = true;
        labelReportSixDescription.Depth = 0;
        labelReportSixDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelReportSixDescription.Location = new Point(17, 61);
        labelReportSixDescription.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportSixDescription.Name = "labelReportSixDescription";
        labelReportSixDescription.Size = new Size(81, 19);
        labelReportSixDescription.TabIndex = 0;
        labelReportSixDescription.Text = "Description";
        // 
        // btnReportFive
        // 
        btnReportFive.Depth = 0;
        btnReportFive.Icon = (Image)resources.GetObject("btnReportFive.Icon");
        btnReportFive.ImageKey = "calender.png";
        btnReportFive.Location = new Point(219, 304);
        btnReportFive.MouseState = MaterialSkin.MouseState.HOVER;
        btnReportFive.Name = "btnReportFive";
        btnReportFive.Size = new Size(56, 56);
        btnReportFive.TabIndex = 21;
        btnReportFive.Text = "materialFloatingActionButton1";
        btnReportFive.UseVisualStyleBackColor = false;
        // 
        // materialCard6
        // 
        materialCard6.BackColor = Color.FromArgb(255, 255, 255);
        materialCard6.Controls.Add(materialProgressBar5);
        materialCard6.Controls.Add(labelReportFiveTitle);
        materialCard6.Controls.Add(labelReportFiveDescription);
        materialCard6.Depth = 0;
        materialCard6.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard6.Location = new Point(24, 277);
        materialCard6.Margin = new Padding(14);
        materialCard6.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard6.Name = "materialCard6";
        materialCard6.Padding = new Padding(14);
        materialCard6.Size = new Size(224, 113);
        materialCard6.TabIndex = 20;
        // 
        // materialProgressBar5
        // 
        materialProgressBar5.Depth = 0;
        materialProgressBar5.Location = new Point(17, 91);
        materialProgressBar5.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar5.Name = "materialProgressBar5";
        materialProgressBar5.Size = new Size(190, 5);
        materialProgressBar5.TabIndex = 2;
        // 
        // labelReportFiveTitle
        // 
        labelReportFiveTitle.AutoSize = true;
        labelReportFiveTitle.Depth = 0;
        labelReportFiveTitle.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelReportFiveTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelReportFiveTitle.Location = new Point(17, 14);
        labelReportFiveTitle.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportFiveTitle.Name = "labelReportFiveTitle";
        labelReportFiveTitle.Size = new Size(87, 41);
        labelReportFiveTitle.TabIndex = 1;
        labelReportFiveTitle.Text = "TITLE";
        // 
        // labelReportFiveDescription
        // 
        labelReportFiveDescription.AutoSize = true;
        labelReportFiveDescription.Depth = 0;
        labelReportFiveDescription.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        labelReportFiveDescription.Location = new Point(17, 61);
        labelReportFiveDescription.MouseState = MaterialSkin.MouseState.HOVER;
        labelReportFiveDescription.Name = "labelReportFiveDescription";
        labelReportFiveDescription.Size = new Size(81, 19);
        labelReportFiveDescription.TabIndex = 0;
        labelReportFiveDescription.Text = "Description";
        // 
        // imageList1
        // 
        imageList1.ColorDepth = ColorDepth.Depth32Bit;
        imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
        imageList1.TransparentColor = Color.Transparent;
        imageList1.Images.SetKeyName(0, "eye.png");
        // 
        // FormReports
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(568, 417);
        Controls.Add(btnReportSix);
        Controls.Add(materialCard5);
        Controls.Add(btnReportFive);
        Controls.Add(materialCard6);
        Controls.Add(btnReportFour);
        Controls.Add(materialCard3);
        Controls.Add(btnReportThree);
        Controls.Add(materialCard4);
        Controls.Add(btnReportTwo);
        Controls.Add(materialCard2);
        Controls.Add(btnReportOne);
        Controls.Add(materialCard1);
        Name = "FormReports";
        Text = "FormReports";
        materialCard1.ResumeLayout(false);
        materialCard1.PerformLayout();
        materialCard2.ResumeLayout(false);
        materialCard2.PerformLayout();
        materialCard3.ResumeLayout(false);
        materialCard3.PerformLayout();
        materialCard4.ResumeLayout(false);
        materialCard4.PerformLayout();
        materialCard5.ResumeLayout(false);
        materialCard5.PerformLayout();
        materialCard6.ResumeLayout(false);
        materialCard6.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private MaterialSkin.Controls.MaterialCard materialCard1;
    private MaterialSkin.Controls.MaterialProgressBar progressJobs;
    private MaterialSkin.Controls.MaterialLabel labelReportOneTitle;
    private MaterialSkin.Controls.MaterialLabel labelReportOneDescription;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnReportOne;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnReportTwo;
    private MaterialSkin.Controls.MaterialCard materialCard2;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
    private MaterialSkin.Controls.MaterialLabel labelReportTwoTitle;
    private MaterialSkin.Controls.MaterialLabel labelReportTwoDescription;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnReportFour;
    private MaterialSkin.Controls.MaterialCard materialCard3;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar2;
    private MaterialSkin.Controls.MaterialLabel labelReportFourTitle;
    private MaterialSkin.Controls.MaterialLabel labelReportFourDescription;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnReportThree;
    private MaterialSkin.Controls.MaterialCard materialCard4;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar3;
    private MaterialSkin.Controls.MaterialLabel labelReportThreeTitle;
    private MaterialSkin.Controls.MaterialLabel labelReportThreeDescription;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnReportSix;
    private MaterialSkin.Controls.MaterialCard materialCard5;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar4;
    private MaterialSkin.Controls.MaterialLabel labelReportSixTitle;
    private MaterialSkin.Controls.MaterialLabel labelReportSixDescription;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnReportFive;
    private MaterialSkin.Controls.MaterialCard materialCard6;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar5;
    private MaterialSkin.Controls.MaterialLabel labelReportFiveTitle;
    private MaterialSkin.Controls.MaterialLabel labelReportFiveDescription;
    private ImageList imageList1;
}