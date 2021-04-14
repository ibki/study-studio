
namespace WinForms.Test
{
    partial class MainForm
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
            this.FileUploadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileUploadButton
            // 
            this.FileUploadButton.Location = new System.Drawing.Point(12, 12);
            this.FileUploadButton.Name = "FileUploadButton";
            this.FileUploadButton.Size = new System.Drawing.Size(105, 23);
            this.FileUploadButton.TabIndex = 0;
            this.FileUploadButton.Text = "Upload file";
            this.FileUploadButton.UseVisualStyleBackColor = true;
            this.FileUploadButton.Click += new System.EventHandler(this.FileUploadButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FileUploadButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FileUploadButton;
    }
}