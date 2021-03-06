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
            this.xlsLab = new System.Windows.Forms.Label();
            this.midLab = new System.Windows.Forms.Label();
            this.mifLab = new System.Windows.Forms.Label();
            this.xlsBut = new System.Windows.Forms.Button();
            this.midBut = new System.Windows.Forms.Button();
            this.mifBut = new System.Windows.Forms.Button();
            this.mifPB = new System.Windows.Forms.PictureBox();
            this.midPB = new System.Windows.Forms.PictureBox();
            this.xlsPB = new System.Windows.Forms.PictureBox();
            this.convertPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mifPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xlsPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.convertPB)).BeginInit();
            this.SuspendLayout();
            // 
            // loadKML
            // 
            this.loadKML.Location = new System.Drawing.Point(813, 228);
            this.loadKML.Name = "loadKML";
            this.loadKML.Size = new System.Drawing.Size(168, 23);
            this.loadKML.TabIndex = 0;
            this.loadKML.Text = "Load KML";
            this.loadKML.UseVisualStyleBackColor = true;
            this.loadKML.Click += new System.EventHandler(this.loadKML_Click);
            // 
            // convertData
            // 
            this.convertData.Location = new System.Drawing.Point(864, 185);
            this.convertData.Name = "convertData";
            this.convertData.Size = new System.Drawing.Size(117, 23);
            this.convertData.TabIndex = 2;
            this.convertData.Text = "Convert Data";
            this.convertData.UseVisualStyleBackColor = true;
            this.convertData.Click += new System.EventHandler(this.convertData_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(812, 489);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(168, 23);
            this.exit.TabIndex = 3;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // xlsLab
            // 
            this.xlsLab.AutoSize = true;
            this.xlsLab.Location = new System.Drawing.Point(861, 157);
            this.xlsLab.Name = "xlsLab";
            this.xlsLab.Size = new System.Drawing.Size(70, 13);
            this.xlsLab.TabIndex = 4;
            this.xlsLab.Text = "No XLS Data";
            // 
            // midLab
            // 
            this.midLab.AutoSize = true;
            this.midLab.Location = new System.Drawing.Point(861, 126);
            this.midLab.Name = "midLab";
            this.midLab.Size = new System.Drawing.Size(70, 13);
            this.midLab.TabIndex = 5;
            this.midLab.Text = "No MID Data";
            this.midLab.Click += new System.EventHandler(this.label2_Click);
            // 
            // mifLab
            // 
            this.mifLab.AutoSize = true;
            this.mifLab.Location = new System.Drawing.Point(861, 93);
            this.mifLab.Name = "mifLab";
            this.mifLab.Size = new System.Drawing.Size(68, 13);
            this.mifLab.TabIndex = 6;
            this.mifLab.Text = "No MIF Data";
            // 
            // xlsBut
            // 
            this.xlsBut.Location = new System.Drawing.Point(937, 152);
            this.xlsBut.Name = "xlsBut";
            this.xlsBut.Size = new System.Drawing.Size(44, 23);
            this.xlsBut.TabIndex = 8;
            this.xlsBut.Text = "Load";
            this.xlsBut.UseVisualStyleBackColor = true;
            this.xlsBut.Click += new System.EventHandler(this.xlsBut_Click);
            // 
            // midBut
            // 
            this.midBut.Location = new System.Drawing.Point(937, 121);
            this.midBut.Name = "midBut";
            this.midBut.Size = new System.Drawing.Size(44, 23);
            this.midBut.TabIndex = 9;
            this.midBut.Text = "Load";
            this.midBut.UseVisualStyleBackColor = true;
            this.midBut.Click += new System.EventHandler(this.midBut_Click);
            // 
            // mifBut
            // 
            this.mifBut.Location = new System.Drawing.Point(937, 88);
            this.mifBut.Name = "mifBut";
            this.mifBut.Size = new System.Drawing.Size(44, 23);
            this.mifBut.TabIndex = 10;
            this.mifBut.Text = "Load";
            this.mifBut.UseVisualStyleBackColor = true;
            this.mifBut.Click += new System.EventHandler(this.mifBut_Click);
            // 
            // mifPB
            // 
            this.mifPB.Location = new System.Drawing.Point(833, 90);
            this.mifPB.Name = "mifPB";
            this.mifPB.Size = new System.Drawing.Size(16, 16);
            this.mifPB.TabIndex = 11;
            this.mifPB.TabStop = false;
            // 
            // midPB
            // 
            this.midPB.Location = new System.Drawing.Point(833, 124);
            this.midPB.Name = "midPB";
            this.midPB.Size = new System.Drawing.Size(16, 16);
            this.midPB.TabIndex = 12;
            this.midPB.TabStop = false;
            // 
            // xlsPB
            // 
            this.xlsPB.Location = new System.Drawing.Point(833, 154);
            this.xlsPB.Name = "xlsPB";
            this.xlsPB.Size = new System.Drawing.Size(16, 16);
            this.xlsPB.TabIndex = 13;
            this.xlsPB.TabStop = false;
            // 
            // convertPB
            // 
            this.convertPB.Location = new System.Drawing.Point(833, 188);
            this.convertPB.Name = "convertPB";
            this.convertPB.Size = new System.Drawing.Size(16, 16);
            this.convertPB.TabIndex = 14;
            this.convertPB.TabStop = false;
            // 
            // Cartographer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 524);
            this.Controls.Add(this.convertPB);
            this.Controls.Add(this.xlsPB);
            this.Controls.Add(this.midPB);
            this.Controls.Add(this.mifPB);
            this.Controls.Add(this.mifBut);
            this.Controls.Add(this.midBut);
            this.Controls.Add(this.xlsBut);
            this.Controls.Add(this.mifLab);
            this.Controls.Add(this.midLab);
            this.Controls.Add(this.xlsLab);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.convertData);
            this.Controls.Add(this.loadKML);
            this.Name = "Cartographer";
            this.Text = "Cartographer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.mifPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xlsPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.convertPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadKML;
        private System.Windows.Forms.Button convertData;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label xlsLab;
        private System.Windows.Forms.Label midLab;
        private System.Windows.Forms.Label mifLab;
        private System.Windows.Forms.Button xlsBut;
        private System.Windows.Forms.Button midBut;
        private System.Windows.Forms.Button mifBut;
        private System.Windows.Forms.PictureBox mifPB;
        private System.Windows.Forms.PictureBox midPB;
        private System.Windows.Forms.PictureBox xlsPB;
        private System.Windows.Forms.PictureBox convertPB;

    }
}

