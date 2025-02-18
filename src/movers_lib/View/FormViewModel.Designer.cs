namespace View;

partial class FormViewModel
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
        dataGridView = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
        SuspendLayout();
        // 
        // dataGridView
        // 
        dataGridView.AllowUserToAddRows = false;
        dataGridView.AllowUserToDeleteRows = false;
        dataGridView.AllowUserToResizeColumns = false;
        dataGridView.AllowUserToResizeRows = false;
        dataGridView.BorderStyle = BorderStyle.None;
        dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView.Dock = DockStyle.Fill;
        dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        dataGridView.Location = new Point(0, 0);
        dataGridView.Margin = new Padding(20);
        dataGridView.MultiSelect = false;
        dataGridView.Name = "dataGridView";
        dataGridView.ReadOnly = true;
        dataGridView.Size = new Size(800, 365);
        dataGridView.TabIndex = 0;
        // 
        // FormViewModel
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dataGridView);
        Name = "FormViewModel";
        Padding = new Padding(0, 0, 0, 85);
        Text = "FormCustomerCreate";
        ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView;
}