namespace Final_Work
{
    partial class optionf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(optionf));
            this.titlelbl = new System.Windows.Forms.Label();
            this.onoff = new System.Windows.Forms.CheckBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.low = new System.Windows.Forms.Label();
            this.highlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titlelbl
            // 
            this.titlelbl.AutoSize = true;
            this.titlelbl.BackColor = System.Drawing.Color.Transparent;
            this.titlelbl.Font = new System.Drawing.Font("Microsoft YaHei", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlelbl.Location = new System.Drawing.Point(214, 143);
            this.titlelbl.Name = "titlelbl";
            this.titlelbl.Size = new System.Drawing.Size(164, 62);
            this.titlelbl.TabIndex = 21;
            this.titlelbl.Text = "music";
            // 
            // onoff
            // 
            this.onoff.Appearance = System.Windows.Forms.Appearance.Button;
            this.onoff.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onoff.Location = new System.Drawing.Point(225, 321);
            this.onoff.Name = "onoff";
            this.onoff.Size = new System.Drawing.Size(183, 109);
            this.onoff.TabIndex = 22;
            this.onoff.Text = "stop";
            this.onoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.onoff.UseVisualStyleBackColor = true;
            this.onoff.CheckedChanged += new System.EventHandler(this.onoff_CheckedChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(66, 227);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(489, 36);
            this.hScrollBar1.SmallChange = 10;
            this.hScrollBar1.TabIndex = 23;
            this.hScrollBar1.Value = 45;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(539, 37);
            this.label1.TabIndex = 24;
            this.label1.Text = "close the tab will keep the music play";
            // 
            // low
            // 
            this.low.AutoSize = true;
            this.low.BackColor = System.Drawing.Color.Transparent;
            this.low.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.low.Location = new System.Drawing.Point(28, 243);
            this.low.Name = "low";
            this.low.Size = new System.Drawing.Size(35, 20);
            this.low.TabIndex = 25;
            this.low.Text = "low";
            // 
            // highlbl
            // 
            this.highlbl.AutoSize = true;
            this.highlbl.BackColor = System.Drawing.Color.Transparent;
            this.highlbl.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highlbl.Location = new System.Drawing.Point(567, 243);
            this.highlbl.Name = "highlbl";
            this.highlbl.Size = new System.Drawing.Size(41, 20);
            this.highlbl.TabIndex = 26;
            this.highlbl.Text = "high";
            // 
            // optionf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 501);
            this.Controls.Add(this.highlbl);
            this.Controls.Add(this.low);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.onoff);
            this.Controls.Add(this.titlelbl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "optionf";
            this.Text = "optionf";
            this.Load += new System.EventHandler(this.optionf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titlelbl;
        private System.Windows.Forms.CheckBox onoff;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label low;
        private System.Windows.Forms.Label highlbl;
    }
}