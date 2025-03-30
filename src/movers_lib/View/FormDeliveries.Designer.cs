namespace View;

partial class FormDeliveries
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDeliveries));
        materialCard3 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
        labelPendingDelivieriesValue = new MaterialSkin.Controls.MaterialLabel();
        labelPendingDelivieries = new MaterialSkin.Controls.MaterialLabel();
        materialCard2 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar3 = new MaterialSkin.Controls.MaterialProgressBar();
        labelDeliveredValue = new MaterialSkin.Controls.MaterialLabel();
        materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
        materialCard4 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar4 = new MaterialSkin.Controls.MaterialProgressBar();
        labelLateValue = new MaterialSkin.Controls.MaterialLabel();
        materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
        btnProcessingDeliveries = new MaterialSkin.Controls.MaterialFloatingActionButton();
        btnDeliveredDeliveries = new MaterialSkin.Controls.MaterialFloatingActionButton();
        btnLateDeliveries = new MaterialSkin.Controls.MaterialFloatingActionButton();
        cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
        materialCard3.SuspendLayout();
        materialCard2.SuspendLayout();
        materialCard4.SuspendLayout();
        SuspendLayout();
        // 
        // materialCard3
        // 
        materialCard3.BackColor = Color.FromArgb(255, 255, 255);
        materialCard3.Controls.Add(materialProgressBar1);
        materialCard3.Controls.Add(labelPendingDelivieriesValue);
        materialCard3.Controls.Add(labelPendingDelivieries);
        materialCard3.Depth = 0;
        materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard3.Location = new Point(314, 23);
        materialCard3.Margin = new Padding(14);
        materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard3.Name = "materialCard3";
        materialCard3.Padding = new Padding(14);
        materialCard3.Size = new Size(224, 113);
        materialCard3.TabIndex = 17;
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
        labelPendingDelivieries.Size = new Size(79, 19);
        labelPendingDelivieries.TabIndex = 3;
        labelPendingDelivieries.Text = "Processing";
        // 
        // materialCard2
        // 
        materialCard2.BackColor = Color.FromArgb(255, 255, 255);
        materialCard2.Controls.Add(materialProgressBar3);
        materialCard2.Controls.Add(labelDeliveredValue);
        materialCard2.Controls.Add(materialLabel4);
        materialCard2.Depth = 0;
        materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard2.Location = new Point(314, 153);
        materialCard2.Margin = new Padding(14);
        materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard2.Name = "materialCard2";
        materialCard2.Padding = new Padding(14);
        materialCard2.Size = new Size(224, 113);
        materialCard2.TabIndex = 18;
        // 
        // materialProgressBar3
        // 
        materialProgressBar3.Depth = 0;
        materialProgressBar3.Location = new Point(17, 91);
        materialProgressBar3.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar3.Name = "materialProgressBar3";
        materialProgressBar3.Size = new Size(190, 5);
        materialProgressBar3.TabIndex = 3;
        // 
        // labelDeliveredValue
        // 
        labelDeliveredValue.AutoSize = true;
        labelDeliveredValue.Depth = 0;
        labelDeliveredValue.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelDeliveredValue.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelDeliveredValue.Location = new Point(17, 42);
        labelDeliveredValue.MouseState = MaterialSkin.MouseState.HOVER;
        labelDeliveredValue.Name = "labelDeliveredValue";
        labelDeliveredValue.Size = new Size(85, 41);
        labelDeliveredValue.TabIndex = 3;
        labelDeliveredValue.Text = "XXXX";
        // 
        // materialLabel4
        // 
        materialLabel4.AutoSize = true;
        materialLabel4.Depth = 0;
        materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        materialLabel4.Location = new Point(17, 14);
        materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
        materialLabel4.Name = "materialLabel4";
        materialLabel4.Size = new Size(66, 19);
        materialLabel4.TabIndex = 3;
        materialLabel4.Text = "Delivered";
        // 
        // materialCard4
        // 
        materialCard4.BackColor = Color.FromArgb(255, 255, 255);
        materialCard4.Controls.Add(materialProgressBar4);
        materialCard4.Controls.Add(labelLateValue);
        materialCard4.Controls.Add(materialLabel6);
        materialCard4.Depth = 0;
        materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
        materialCard4.Location = new Point(314, 294);
        materialCard4.Margin = new Padding(14);
        materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
        materialCard4.Name = "materialCard4";
        materialCard4.Padding = new Padding(14);
        materialCard4.Size = new Size(224, 113);
        materialCard4.TabIndex = 18;
        // 
        // materialProgressBar4
        // 
        materialProgressBar4.Depth = 0;
        materialProgressBar4.Location = new Point(17, 91);
        materialProgressBar4.MouseState = MaterialSkin.MouseState.HOVER;
        materialProgressBar4.Name = "materialProgressBar4";
        materialProgressBar4.Size = new Size(190, 5);
        materialProgressBar4.TabIndex = 3;
        // 
        // labelLateValue
        // 
        labelLateValue.AutoSize = true;
        labelLateValue.Depth = 0;
        labelLateValue.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
        labelLateValue.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
        labelLateValue.Location = new Point(17, 42);
        labelLateValue.MouseState = MaterialSkin.MouseState.HOVER;
        labelLateValue.Name = "labelLateValue";
        labelLateValue.Size = new Size(85, 41);
        labelLateValue.TabIndex = 3;
        labelLateValue.Text = "XXXX";
        // 
        // materialLabel6
        // 
        materialLabel6.AutoSize = true;
        materialLabel6.Depth = 0;
        materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
        materialLabel6.Location = new Point(17, 14);
        materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
        materialLabel6.Name = "materialLabel6";
        materialLabel6.Size = new Size(32, 19);
        materialLabel6.TabIndex = 3;
        materialLabel6.Text = "Late";
        // 
        // btnProcessingDeliveries
        // 
        btnProcessingDeliveries.Depth = 0;
        btnProcessingDeliveries.Icon = (Image)resources.GetObject("btnProcessingDeliveries.Icon");
        btnProcessingDeliveries.ImageKey = "calender.png";
        btnProcessingDeliveries.Location = new Point(506, 50);
        btnProcessingDeliveries.MouseState = MaterialSkin.MouseState.HOVER;
        btnProcessingDeliveries.Name = "btnProcessingDeliveries";
        btnProcessingDeliveries.Size = new Size(56, 56);
        btnProcessingDeliveries.TabIndex = 20;
        btnProcessingDeliveries.Text = "btnProcessingDeliveries";
        btnProcessingDeliveries.UseVisualStyleBackColor = false;
        // 
        // btnDeliveredDeliveries
        // 
        btnDeliveredDeliveries.Depth = 0;
        btnDeliveredDeliveries.Icon = (Image)resources.GetObject("btnDeliveredDeliveries.Icon");
        btnDeliveredDeliveries.ImageKey = "calender.png";
        btnDeliveredDeliveries.Location = new Point(506, 182);
        btnDeliveredDeliveries.MouseState = MaterialSkin.MouseState.HOVER;
        btnDeliveredDeliveries.Name = "btnDeliveredDeliveries";
        btnDeliveredDeliveries.Size = new Size(56, 56);
        btnDeliveredDeliveries.TabIndex = 21;
        btnDeliveredDeliveries.Text = "btnDelivered";
        btnDeliveredDeliveries.UseVisualStyleBackColor = false;
        // 
        // btnLateDeliveries
        // 
        btnLateDeliveries.Depth = 0;
        btnLateDeliveries.Icon = (Image)resources.GetObject("btnLateDeliveries.Icon");
        btnLateDeliveries.ImageKey = "calender.png";
        btnLateDeliveries.Location = new Point(506, 321);
        btnLateDeliveries.MouseState = MaterialSkin.MouseState.HOVER;
        btnLateDeliveries.Name = "btnLateDeliveries";
        btnLateDeliveries.Size = new Size(56, 56);
        btnLateDeliveries.TabIndex = 22;
        btnLateDeliveries.Text = "btnLateDeliveries";
        btnLateDeliveries.UseVisualStyleBackColor = false;
        // 
        // cartesianChart1
        // 
        cartesianChart1.Location = new Point(29, 23);
        cartesianChart1.Name = "cartesianChart1";
        cartesianChart1.Size = new Size(273, 402);
        cartesianChart1.TabIndex = 23;
        cartesianChart1.Text = "cartesianChart1";
        // 
        // FormDeliveries
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(587, 437);
        Controls.Add(cartesianChart1);
        Controls.Add(btnLateDeliveries);
        Controls.Add(btnDeliveredDeliveries);
        Controls.Add(btnProcessingDeliveries);
        Controls.Add(materialCard4);
        Controls.Add(materialCard2);
        Controls.Add(materialCard3);
        Name = "FormDeliveries";
        Text = "formSettings";
        materialCard3.ResumeLayout(false);
        materialCard3.PerformLayout();
        materialCard2.ResumeLayout(false);
        materialCard2.PerformLayout();
        materialCard4.ResumeLayout(false);
        materialCard4.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private MaterialSkin.Controls.MaterialCard materialCard3;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
    private MaterialSkin.Controls.MaterialLabel labelPendingDelivieriesValue;
    private MaterialSkin.Controls.MaterialLabel labelPendingDelivieries;
    private MaterialSkin.Controls.MaterialCard materialCard2;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar3;
    private MaterialSkin.Controls.MaterialLabel labelDeliveredValue;
    private MaterialSkin.Controls.MaterialLabel materialLabel4;
    private MaterialSkin.Controls.MaterialCard materialCard4;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar4;
    private MaterialSkin.Controls.MaterialLabel labelLateValue;
    private MaterialSkin.Controls.MaterialLabel materialLabel6;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnProcessingDeliveries;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnDeliveredDeliveries;
    private MaterialSkin.Controls.MaterialFloatingActionButton btnLateDeliveries;
    private LiveCharts.WinForms.CartesianChart cartesianChart1;
}