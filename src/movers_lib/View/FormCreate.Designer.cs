namespace movers_lib.View
{
    partial class FormCreate
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
            panel1 = new Panel();
            btnCreate = new MaterialSkin.Controls.MaterialButton();
            btnBack = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(126, 9);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(557, 368);
            panel1.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Bottom;
            btnCreate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCreate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCreate.Depth = 0;
            btnCreate.HighEmphasis = true;
            btnCreate.Icon = null;
            btnCreate.Location = new Point(432, 399);
            btnCreate.Margin = new Padding(4, 6, 4, 6);
            btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            btnCreate.Name = "btnCreate";
            btnCreate.NoAccentTextColor = Color.Empty;
            btnCreate.Size = new Size(76, 36);
            btnCreate.TabIndex = 5;
            btnCreate.Text = "Create";
            btnCreate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCreate.UseAccentColor = false;
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom;
            btnBack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBack.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBack.Depth = 0;
            btnBack.HighEmphasis = true;
            btnBack.Icon = null;
            btnBack.Location = new Point(324, 399);
            btnBack.Margin = new Padding(4, 6, 4, 6);
            btnBack.MouseState = MaterialSkin.MouseState.HOVER;
            btnBack.Name = "btnBack";
            btnBack.NoAccentTextColor = Color.Empty;
            btnBack.Size = new Size(64, 36);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBack.UseAccentColor = false;
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // FormCreate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnCreate);
            Controls.Add(panel1);
            Name = "FormCreate";
            Text = "FormCreate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton btnCreate;
        private MaterialSkin.Controls.MaterialButton btnBack;
    }
}