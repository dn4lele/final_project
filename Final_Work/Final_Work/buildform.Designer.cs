namespace Final_Work
{
    partial class buildform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(buildform));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxontagetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildingnowlbl = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.optionbtn = new System.Windows.Forms.PictureBox();
            this.returnbtn = new System.Windows.Forms.PictureBox();
            this.sizextxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeytxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.changesizebtn = new System.Windows.Forms.Button();
            this.closeallbtn = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeallbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem,
            this.objectsToolStripMenuItem,
            this.playerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(289, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(217, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floorToolStripMenuItem,
            this.wallToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(58, 27);
            this.mapToolStripMenuItem.Text = "map";
            // 
            // floorToolStripMenuItem
            // 
            this.floorToolStripMenuItem.Name = "floorToolStripMenuItem";
            this.floorToolStripMenuItem.Size = new System.Drawing.Size(132, 28);
            this.floorToolStripMenuItem.Text = "Wall";
            this.floorToolStripMenuItem.Click += new System.EventHandler(this.wallToolStripMenuItem_Click);
            // 
            // wallToolStripMenuItem
            // 
            this.wallToolStripMenuItem.Name = "wallToolStripMenuItem";
            this.wallToolStripMenuItem.Size = new System.Drawing.Size(132, 28);
            this.wallToolStripMenuItem.Text = "Floor";
            this.wallToolStripMenuItem.Click += new System.EventHandler(this.floorToolStripMenuItem_Click);
            // 
            // objectsToolStripMenuItem
            // 
            this.objectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxToolStripMenuItem,
            this.targetToolStripMenuItem,
            this.boxontagetToolStripMenuItem});
            this.objectsToolStripMenuItem.Name = "objectsToolStripMenuItem";
            this.objectsToolStripMenuItem.Size = new System.Drawing.Size(81, 27);
            this.objectsToolStripMenuItem.Text = "Objects";
            // 
            // boxToolStripMenuItem
            // 
            this.boxToolStripMenuItem.Name = "boxToolStripMenuItem";
            this.boxToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.boxToolStripMenuItem.Text = "Box";
            this.boxToolStripMenuItem.Click += new System.EventHandler(this.boxToolStripMenuItem_Click);
            // 
            // targetToolStripMenuItem
            // 
            this.targetToolStripMenuItem.Name = "targetToolStripMenuItem";
            this.targetToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.targetToolStripMenuItem.Text = "Target";
            this.targetToolStripMenuItem.Click += new System.EventHandler(this.targetToolStripMenuItem_Click);
            // 
            // boxontagetToolStripMenuItem
            // 
            this.boxontagetToolStripMenuItem.Name = "boxontagetToolStripMenuItem";
            this.boxontagetToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.boxontagetToolStripMenuItem.Text = "Boxontaget";
            this.boxontagetToolStripMenuItem.Click += new System.EventHandler(this.boxontagetToolStripMenuItem_Click);
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(70, 27);
            this.playerToolStripMenuItem.Text = "Player";
            this.playerToolStripMenuItem.Click += new System.EventHandler(this.playerToolStripMenuItem_Click);
            // 
            // buildingnowlbl
            // 
            this.buildingnowlbl.BackColor = System.Drawing.Color.Transparent;
            this.buildingnowlbl.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildingnowlbl.Location = new System.Drawing.Point(338, 118);
            this.buildingnowlbl.Name = "buildingnowlbl";
            this.buildingnowlbl.Size = new System.Drawing.Size(256, 35);
            this.buildingnowlbl.TabIndex = 1;
            this.buildingnowlbl.Tag = "";
            this.buildingnowlbl.Text = "wall";
            this.buildingnowlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(257, 83);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(420, 35);
            this.title.TabIndex = 2;
            this.title.Tag = "";
            this.title.Text = "press mouse left on board to create";
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(685, 496);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(215, 77);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newbtn.Location = new System.Drawing.Point(12, 496);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(215, 77);
            this.newbtn.TabIndex = 5;
            this.newbtn.Text = "new";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // optionbtn
            // 
            this.optionbtn.BackColor = System.Drawing.Color.Transparent;
            this.optionbtn.Image = ((System.Drawing.Image)(resources.GetObject("optionbtn.Image")));
            this.optionbtn.Location = new System.Drawing.Point(801, 0);
            this.optionbtn.Name = "optionbtn";
            this.optionbtn.Size = new System.Drawing.Size(60, 60);
            this.optionbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.optionbtn.TabIndex = 22;
            this.optionbtn.TabStop = false;
            this.optionbtn.Click += new System.EventHandler(this.optionbtn_Click);
            // 
            // returnbtn
            // 
            this.returnbtn.BackColor = System.Drawing.Color.Transparent;
            this.returnbtn.Image = ((System.Drawing.Image)(resources.GetObject("returnbtn.Image")));
            this.returnbtn.Location = new System.Drawing.Point(27, 30);
            this.returnbtn.Name = "returnbtn";
            this.returnbtn.Size = new System.Drawing.Size(100, 50);
            this.returnbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.returnbtn.TabIndex = 23;
            this.returnbtn.TabStop = false;
            this.returnbtn.Click += new System.EventHandler(this.returnbtn_Click);
            // 
            // sizextxt
            // 
            this.sizextxt.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizextxt.Location = new System.Drawing.Point(324, 542);
            this.sizextxt.Name = "sizextxt";
            this.sizextxt.Size = new System.Drawing.Size(100, 36);
            this.sizextxt.TabIndex = 24;
            this.sizextxt.Text = "9";
            this.sizextxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(362, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Y";
            // 
            // sizeytxt
            // 
            this.sizeytxt.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeytxt.Location = new System.Drawing.Point(494, 542);
            this.sizeytxt.Name = "sizeytxt";
            this.sizeytxt.Size = new System.Drawing.Size(100, 36);
            this.sizeytxt.TabIndex = 27;
            this.sizeytxt.Text = "9";
            this.sizeytxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(531, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 24);
            this.label2.TabIndex = 28;
            this.label2.Text = "X";
            // 
            // changesizebtn
            // 
            this.changesizebtn.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changesizebtn.Location = new System.Drawing.Point(344, 435);
            this.changesizebtn.Name = "changesizebtn";
            this.changesizebtn.Size = new System.Drawing.Size(215, 77);
            this.changesizebtn.TabIndex = 29;
            this.changesizebtn.Text = "change size";
            this.changesizebtn.UseVisualStyleBackColor = true;
            this.changesizebtn.Click += new System.EventHandler(this.changesizebtn_Click);
            // 
            // closeallbtn
            // 
            this.closeallbtn.BackColor = System.Drawing.Color.Transparent;
            this.closeallbtn.Image = ((System.Drawing.Image)(resources.GetObject("closeallbtn.Image")));
            this.closeallbtn.Location = new System.Drawing.Point(867, 0);
            this.closeallbtn.Name = "closeallbtn";
            this.closeallbtn.Size = new System.Drawing.Size(60, 60);
            this.closeallbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeallbtn.TabIndex = 30;
            this.closeallbtn.TabStop = false;
            this.closeallbtn.Click += new System.EventHandler(this.closeallbtn_Click);
            // 
            // buildform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(925, 585);
            this.Controls.Add(this.closeallbtn);
            this.Controls.Add(this.changesizebtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeytxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizextxt);
            this.Controls.Add(this.returnbtn);
            this.Controls.Add(this.optionbtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.title);
            this.Controls.Add(this.buildingnowlbl);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "buildform";
            this.Text = "buildform";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.buildform_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.returnbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeallbtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem targetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxontagetToolStripMenuItem;
        private System.Windows.Forms.Label buildingnowlbl;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.PictureBox optionbtn;
        private System.Windows.Forms.PictureBox returnbtn;
        private System.Windows.Forms.TextBox sizextxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sizeytxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button changesizebtn;
        private System.Windows.Forms.PictureBox closeallbtn;
    }
}