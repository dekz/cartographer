﻿namespace cartographer
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
            this.loadKML = new System.Windows.Forms.Button();
            this.convertData = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadKML
            // 
            this.loadKML.Location = new System.Drawing.Point(797, 87);
            this.loadKML.Name = "loadKML";
            this.loadKML.Size = new System.Drawing.Size(168, 23);
            this.loadKML.TabIndex = 0;
            this.loadKML.Text = "Load KML";
            this.loadKML.UseVisualStyleBackColor = true;
            this.loadKML.Click += new System.EventHandler(this.loadKML_Click);
            // 
            // convertData
            // 
            this.convertData.Location = new System.Drawing.Point(797, 58);
            this.convertData.Name = "convertData";
            this.convertData.Size = new System.Drawing.Size(168, 23);
            this.convertData.TabIndex = 2;
            this.convertData.Text = "Convert Data";
            this.convertData.UseVisualStyleBackColor = true;
            this.convertData.Click += new System.EventHandler(this.convertData_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(797, 116);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(168, 23);
            this.exit.TabIndex = 3;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Cartographer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 524);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.convertData);
            this.Controls.Add(this.loadKML);
            this.Name = "Cartographer";
            this.Text = "Cartographer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadKML;
        private System.Windows.Forms.Button convertData;
        private System.Windows.Forms.Button exit;

    }
}

