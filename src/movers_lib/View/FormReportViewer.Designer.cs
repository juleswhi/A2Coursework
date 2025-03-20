namespace View {
    partial class FormReportViewer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            pdfViewer1 = new PdfiumViewer.PdfViewer();
            SuspendLayout();
            // 
            // pdfViewer1
            // 
            pdfViewer1.Dock = DockStyle.Fill;
            pdfViewer1.Location = new Point(0, 0);
            pdfViewer1.Margin = new Padding(4, 3, 4, 3);
            pdfViewer1.Name = "pdfViewer1";
            pdfViewer1.Size = new Size(800, 450);
            pdfViewer1.TabIndex = 0;
            // 
            // FormReportViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pdfViewer1);
            Name = "FormReportViewer";
            Text = "ReportViewer";
            ResumeLayout(false);
        }

        #endregion

        private PdfiumViewer.PdfViewer pdfViewer1;
    }
}