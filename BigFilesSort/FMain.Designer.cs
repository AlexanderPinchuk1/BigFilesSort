namespace BigFilesSort
{
    partial class FMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButGenerateFile = new System.Windows.Forms.Button();
            this.ButSortFile = new System.Windows.Forms.Button();
            this.ButExit = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // ButGenerateFile
            // 
            this.ButGenerateFile.Location = new System.Drawing.Point(75, 46);
            this.ButGenerateFile.Name = "ButGenerateFile";
            this.ButGenerateFile.Size = new System.Drawing.Size(111, 53);
            this.ButGenerateFile.TabIndex = 0;
            this.ButGenerateFile.Text = "Generate file";
            this.ButGenerateFile.UseVisualStyleBackColor = true;
            this.ButGenerateFile.Click += new System.EventHandler(this.ButGenerateFile_Click);
            // 
            // ButSortFile
            // 
            this.ButSortFile.Location = new System.Drawing.Point(75, 114);
            this.ButSortFile.Name = "ButSortFile";
            this.ButSortFile.Size = new System.Drawing.Size(111, 48);
            this.ButSortFile.TabIndex = 0;
            this.ButSortFile.Text = "Sort file";
            this.ButSortFile.UseVisualStyleBackColor = true;
            this.ButSortFile.Click += new System.EventHandler(this.ButSortFile_Click);
            // 
            // ButExit
            // 
            this.ButExit.Location = new System.Drawing.Point(75, 180);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(111, 40);
            this.ButExit.TabIndex = 0;
            this.ButExit.Text = "Exit";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 274);
            this.Controls.Add(this.ButExit);
            this.Controls.Add(this.ButSortFile);
            this.Controls.Add(this.ButGenerateFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FMain";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButGenerateFile;
        private System.Windows.Forms.Button ButSortFile;
        private System.Windows.Forms.Button ButExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

