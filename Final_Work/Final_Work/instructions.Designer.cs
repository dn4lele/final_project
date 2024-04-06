namespace Final_Work
{
    partial class instructions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(instructions));
            this.returnbtn = new System.Windows.Forms.PictureBox();
            this.optionbtn = new System.Windows.Forms.PictureBox();
            this.infolbl = new System.Windows.Forms.Label();
            this.backmove = new System.Windows.Forms.Button();
            this.forwordbutton = new System.Windows.Forms.Button();
            this.moveslbl = new System.Windows.Forms.Label();
            this.keyslbl = new System.Windows.Forms.Label();
            this.buttonpic = new System.Windows.Forms.PictureBox();
            this.closeallbtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.returnbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeallbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // returnbtn
            // 
            this.returnbtn.BackColor = System.Drawing.Color.Transparent;
            this.returnbtn.Image = ((System.Drawing.Image)(resources.GetObject("returnbtn.Image")));
            this.returnbtn.Location = new System.Drawing.Point(58, 25);
            this.returnbtn.Name = "returnbtn";
            this.returnbtn.Size = new System.Drawing.Size(100, 50);
            this.returnbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.returnbtn.TabIndex = 2;
            this.returnbtn.TabStop = false;
            this.returnbtn.Click += new System.EventHandler(this.returnbtn_Click);
            // 
            // optionbtn
            // 
            this.optionbtn.BackColor = System.Drawing.Color.Transparent;
            this.optionbtn.Image = ((System.Drawing.Image)(resources.GetObject("optionbtn.Image")));
            this.optionbtn.Location = new System.Drawing.Point(952, 9);
            this.optionbtn.Name = "optionbtn";
            this.optionbtn.Size = new System.Drawing.Size(60, 60);
            this.optionbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.optionbtn.TabIndex = 22;
            this.optionbtn.TabStop = false;
            this.optionbtn.Click += new System.EventHandler(this.optionbtn_Click);
            // 
            // infolbl
            // 
            this.infolbl.AutoSize = true;
            this.infolbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infolbl.Location = new System.Drawing.Point(275, 9);
            this.infolbl.Name = "infolbl";
            this.infolbl.Size = new System.Drawing.Size(471, 175);
            this.infolbl.TabIndex = 23;
            this.infolbl.Text = "In the game, use the arrow keys to move. \r\n\r\n\r\nnow you need click on an arrow,\r\n\r" +
    "\nthe game will display which button was pressed \r\nand show the corresponding mov" +
    "ement.";
            // 
            // backmove
            // 
            this.backmove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backmove.BackgroundImage")));
            this.backmove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.backmove.Location = new System.Drawing.Point(304, 503);
            this.backmove.Name = "backmove";
            this.backmove.Size = new System.Drawing.Size(138, 101);
            this.backmove.TabIndex = 24;
            this.backmove.UseVisualStyleBackColor = true;
            this.backmove.Click += new System.EventHandler(this.backmove_Click_1);
            // 
            // forwordbutton
            // 
            this.forwordbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("forwordbutton.BackgroundImage")));
            this.forwordbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.forwordbutton.Location = new System.Drawing.Point(614, 503);
            this.forwordbutton.Name = "forwordbutton";
            this.forwordbutton.Size = new System.Drawing.Size(138, 101);
            this.forwordbutton.TabIndex = 25;
            this.forwordbutton.UseVisualStyleBackColor = true;
            this.forwordbutton.Click += new System.EventHandler(this.forwordbutton_Click);
            // 
            // moveslbl
            // 
            this.moveslbl.AutoSize = true;
            this.moveslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveslbl.Location = new System.Drawing.Point(464, 517);
            this.moveslbl.Name = "moveslbl";
            this.moveslbl.Size = new System.Drawing.Size(110, 51);
            this.moveslbl.TabIndex = 26;
            this.moveslbl.Text = "1/12";
            // 
            // keyslbl
            // 
            this.keyslbl.AutoSize = true;
            this.keyslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyslbl.Location = new System.Drawing.Point(2, 274);
            this.keyslbl.Name = "keyslbl";
            this.keyslbl.Size = new System.Drawing.Size(294, 36);
            this.keyslbl.TabIndex = 27;
            this.keyslbl.Text = "the Keys are pressed";
            // 
            // buttonpic
            // 
            this.buttonpic.Location = new System.Drawing.Point(30, 313);
            this.buttonpic.Name = "buttonpic";
            this.buttonpic.Size = new System.Drawing.Size(161, 105);
            this.buttonpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonpic.TabIndex = 28;
            this.buttonpic.TabStop = false;
            // 
            // closeallbtn
            // 
            this.closeallbtn.BackColor = System.Drawing.Color.Transparent;
            this.closeallbtn.Image = ((System.Drawing.Image)(resources.GetObject("closeallbtn.Image")));
            this.closeallbtn.Location = new System.Drawing.Point(1018, 9);
            this.closeallbtn.Name = "closeallbtn";
            this.closeallbtn.Size = new System.Drawing.Size(60, 60);
            this.closeallbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeallbtn.TabIndex = 29;
            this.closeallbtn.TabStop = false;
            this.closeallbtn.Click += new System.EventHandler(this.closeallbtn_Click);
            // 
            // instructions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1090, 663);
            this.ControlBox = false;
            this.Controls.Add(this.closeallbtn);
            this.Controls.Add(this.buttonpic);
            this.Controls.Add(this.keyslbl);
            this.Controls.Add(this.moveslbl);
            this.Controls.Add(this.forwordbutton);
            this.Controls.Add(this.backmove);
            this.Controls.Add(this.infolbl);
            this.Controls.Add(this.optionbtn);
            this.Controls.Add(this.returnbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "instructions";
            this.Text = "instructions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.instructions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.returnbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeallbtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox returnbtn;
        private System.Windows.Forms.PictureBox optionbtn;
        private System.Windows.Forms.Label infolbl;
        private System.Windows.Forms.Button backmove;
        private System.Windows.Forms.Button forwordbutton;
        private System.Windows.Forms.Label moveslbl;
        private System.Windows.Forms.Label keyslbl;
        private System.Windows.Forms.PictureBox buttonpic;
        private System.Windows.Forms.PictureBox closeallbtn;
    }
}