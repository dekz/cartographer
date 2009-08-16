namespace cartographer
{
    partial class Cartographer
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
            this.BROWSER = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // BROWSER
            // 
            this.BROWSER.Location = new System.Drawing.Point(283, 3);
            this.BROWSER.MinimumSize = new System.Drawing.Size(20, 20);
            this.BROWSER.Name = "BROWSER";
            this.BROWSER.Size = new System.Drawing.Size(646, 467);
            this.BROWSER.TabIndex = 0;
            // 
            // Cartographer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 723);
            this.Controls.Add(this.BROWSER);
            this.Name = "Cartographer";
            this.Text = "Cartographer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser BROWSER;
    }
}

