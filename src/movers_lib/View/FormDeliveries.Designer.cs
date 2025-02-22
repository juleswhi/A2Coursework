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
        materialCard3 = new MaterialSkin.Controls.MaterialCard();
        materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
        labelPendingDelivieriesValue = new MaterialSkin.Controls.MaterialLabel();
        labelPendingDelivieries = new MaterialSkin.Controls.MaterialLabel();
        materialCard3.SuspendLayout();
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
        materialCard3.Location = new Point(23, 23);
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
        labelPendingDelivieries.Size = new Size(131, 19);
        labelPendingDelivieries.TabIndex = 3;
        labelPendingDelivieries.Text = "Pending Deliveries";
        // 
        // FormDeliveries
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(materialCard3);
        Name = "FormDeliveries";
        Text = "formSettings";
        materialCard3.ResumeLayout(false);
        materialCard3.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private MaterialSkin.Controls.MaterialCard materialCard3;
    private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
    private MaterialSkin.Controls.MaterialLabel labelPendingDelivieriesValue;
    private MaterialSkin.Controls.MaterialLabel labelPendingDelivieries;
}