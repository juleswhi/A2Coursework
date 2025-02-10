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
        btnCreate = new MaterialSkin.Controls.MaterialButton();
        btnDelete = new MaterialSkin.Controls.MaterialButton();
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
        // btnCreate
        // 
        btnCreate.Anchor = AnchorStyles.Bottom;
        btnCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnCreate.Depth = 0;
        btnCreate.HighEmphasis = true;
        btnCreate.Icon = null;
        btnCreate.Location = new Point(284, 391);
        btnCreate.Margin = new Padding(4, 6, 4, 6);
        btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
        btnCreate.Name = "btnCreate";
        btnCreate.NoAccentTextColor = Color.Empty;
        btnCreate.Size = new Size(76, 36);
        btnCreate.TabIndex = 4;
        btnCreate.Text = "Create";
        btnCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
        btnCreate.UseAccentColor = true;
        btnCreate.UseVisualStyleBackColor = true;
        btnCreate.Click += btnCreate_Click;
        // 
        // btnDelete
        // 
        btnDelete.Anchor = AnchorStyles.Bottom;
        btnDelete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
        btnDelete.Depth = 0;
        btnDelete.HighEmphasis = true;
        btnDelete.Icon = null;
        btnDelete.Location = new Point(443, 391);
        btnDelete.Margin = new Padding(4, 6, 4, 6);
        btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
        btnDelete.Name = "btnDelete";
        btnDelete.NoAccentTextColor = Color.Empty;
        btnDelete.Size = new Size(73, 36);
        btnDelete.TabIndex = 5;
        btnDelete.Text = "Delete";
        btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
        btnDelete.UseAccentColor = true;
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // FormViewModel
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnDelete);
        Controls.Add(btnCreate);
        Controls.Add(dataGridView);
        Name = "FormViewModel";
        Padding = new Padding(0, 0, 0, 85);
        Text = "FormCustomerCreate";
        ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dataGridView;
    private MaterialSkin.Controls.MaterialButton btnCreate;
    private MaterialSkin.Controls.MaterialButton btnDelete;
}