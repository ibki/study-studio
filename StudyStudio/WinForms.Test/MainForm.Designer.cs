
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
            this.FileUploadGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.FileNoLabel = new System.Windows.Forms.Label();
            this.FileNoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.FileUploadGroupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileNoNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FileUploadButton
            // 
            this.FileUploadButton.Location = new System.Drawing.Point(3, 103);
            this.FileUploadButton.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.FileUploadButton.Name = "FileUploadButton";
            this.FileUploadButton.Size = new System.Drawing.Size(105, 23);
            this.FileUploadButton.TabIndex = 0;
            this.FileUploadButton.Text = "Upload file";
            this.FileUploadButton.UseVisualStyleBackColor = true;
            this.FileUploadButton.Click += new System.EventHandler(this.FileUploadButton_Click);
            // 
            // FileUploadGroupBox
            // 
            this.FileUploadGroupBox.Controls.Add(this.flowLayoutPanel1);
            this.FileUploadGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FileUploadGroupBox.Name = "FileUploadGroupBox";
            this.FileUploadGroupBox.Size = new System.Drawing.Size(189, 170);
            this.FileUploadGroupBox.TabIndex = 1;
            this.FileUploadGroupBox.TabStop = false;
            this.FileUploadGroupBox.Text = "File-Upload";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.FileNoLabel);
            this.flowLayoutPanel1.Controls.Add(this.FileNoNumericUpDown);
            this.flowLayoutPanel1.Controls.Add(this.FileNameLabel);
            this.flowLayoutPanel1.Controls.Add(this.FileNameTextBox);
            this.flowLayoutPanel1.Controls.Add(this.FileUploadButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(183, 150);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // FileNoLabel
            // 
            this.FileNoLabel.AutoSize = true;
            this.FileNoLabel.Location = new System.Drawing.Point(3, 5);
            this.FileNoLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.FileNoLabel.Name = "FileNoLabel";
            this.FileNoLabel.Size = new System.Drawing.Size(21, 12);
            this.FileNoLabel.TabIndex = 0;
            this.FileNoLabel.Text = "No";
            // 
            // FileNoNumericUpDown
            // 
            this.FileNoNumericUpDown.Location = new System.Drawing.Point(3, 20);
            this.FileNoNumericUpDown.Name = "FileNoNumericUpDown";
            this.FileNoNumericUpDown.Size = new System.Drawing.Size(105, 21);
            this.FileNoNumericUpDown.TabIndex = 1;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(3, 54);
            this.FileNameLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(39, 12);
            this.FileNameLabel.TabIndex = 2;
            this.FileNameLabel.Text = "Name";
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(3, 69);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(105, 21);
            this.FileNameTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FileUploadGroupBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FileUploadGroupBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileNoNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FileUploadButton;
        private System.Windows.Forms.GroupBox FileUploadGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label FileNoLabel;
        private System.Windows.Forms.NumericUpDown FileNoNumericUpDown;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.TextBox FileNameTextBox;
    }
}