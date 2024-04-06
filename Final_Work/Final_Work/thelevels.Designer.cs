namespace Final_Work
{
    partial class thelevels
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(thelevels));
            this.returnbtn = new System.Windows.Forms.PictureBox();
            this.againbtn = new System.Windows.Forms.PictureBox();
            this.stepslbl = new System.Windows.Forms.Label();
            this.countstepslbl = new System.Windows.Forms.Label();
            this.timerlbl = new System.Windows.Forms.Label();
            this.timershowlbl = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.optionbtn = new System.Windows.Forms.PictureBox();
            this.undobtn = new System.Windows.Forms.PictureBox();
            this.undolbl = new System.Windows.Forms.Label();
            this.autosolve = new System.Windows.Forms.PictureBox();
            this.patha = new System.Windows.Forms.Label();
            this.closeallbtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.returnbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.againbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.undobtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autosolve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeallbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // returnbtn
            // 
            this.returnbtn.BackColor = System.Drawing.Color.Transparent;
            this.returnbtn.Image = ((System.Drawing.Image)(resources.GetObject("returnbtn.Image")));
            this.returnbtn.Location = new System.Drawing.Point(29, 22);
            this.returnbtn.Name = "returnbtn";
            this.returnbtn.Size = new System.Drawing.Size(100, 50);
            this.returnbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.returnbtn.TabIndex = 1;
            this.returnbtn.TabStop = false;
            this.returnbtn.Click += new System.EventHandler(this.returnbtn_Click);
            // 
            // againbtn
            // 
            this.againbtn.BackColor = System.Drawing.Color.Transparent;
            this.againbtn.Image = ((System.Drawing.Image)(resources.GetObject("againbtn.Image")));
            this.againbtn.Location = new System.Drawing.Point(496, 529);
            this.againbtn.Name = "againbtn";
            this.againbtn.Size = new System.Drawing.Size(75, 75);
            this.againbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.againbtn.TabIndex = 2;
            this.againbtn.TabStop = false;
            this.againbtn.Click += new System.EventHandler(this.againbtn_click);
            // 
            // stepslbl
            // 
            this.stepslbl.AutoSize = true;
            this.stepslbl.BackColor = System.Drawing.Color.Transparent;
            this.stepslbl.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepslbl.Location = new System.Drawing.Point(866, 81);
            this.stepslbl.Name = "stepslbl";
            this.stepslbl.Size = new System.Drawing.Size(112, 49);
            this.stepslbl.TabIndex = 3;
            this.stepslbl.Text = "Steps";
            // 
            // countstepslbl
            // 
            this.countstepslbl.AutoSize = true;
            this.countstepslbl.BackColor = System.Drawing.Color.Transparent;
            this.countstepslbl.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countstepslbl.Location = new System.Drawing.Point(904, 154);
            this.countstepslbl.Name = "countstepslbl";
            this.countstepslbl.Size = new System.Drawing.Size(34, 40);
            this.countstepslbl.TabIndex = 4;
            this.countstepslbl.Text = "0";
            // 
            // timerlbl
            // 
            this.timerlbl.AutoSize = true;
            this.timerlbl.BackColor = System.Drawing.Color.Transparent;
            this.timerlbl.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerlbl.Location = new System.Drawing.Point(866, 388);
            this.timerlbl.Name = "timerlbl";
            this.timerlbl.Size = new System.Drawing.Size(119, 49);
            this.timerlbl.TabIndex = 5;
            this.timerlbl.Text = "Timer";
            // 
            // timershowlbl
            // 
            this.timershowlbl.AutoSize = true;
            this.timershowlbl.BackColor = System.Drawing.Color.Transparent;
            this.timershowlbl.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timershowlbl.Location = new System.Drawing.Point(856, 448);
            this.timershowlbl.Name = "timershowlbl";
            this.timershowlbl.Size = new System.Drawing.Size(137, 40);
            this.timershowlbl.TabIndex = 6;
            this.timershowlbl.Text = "00:00:00";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // optionbtn
            // 
            this.optionbtn.BackColor = System.Drawing.Color.Transparent;
            this.optionbtn.Image = ((System.Drawing.Image)(resources.GetObject("optionbtn.Image")));
            this.optionbtn.Location = new System.Drawing.Point(918, 12);
            this.optionbtn.Name = "optionbtn";
            this.optionbtn.Size = new System.Drawing.Size(60, 60);
            this.optionbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.optionbtn.TabIndex = 21;
            this.optionbtn.TabStop = false;
            this.optionbtn.Click += new System.EventHandler(this.optionbtn_Click);
            // 
            // undobtn
            // 
            this.undobtn.BackColor = System.Drawing.Color.Transparent;
            this.undobtn.Image = ((System.Drawing.Image)(resources.GetObject("undobtn.Image")));
            this.undobtn.Location = new System.Drawing.Point(94, 293);
            this.undobtn.Name = "undobtn";
            this.undobtn.Size = new System.Drawing.Size(107, 49);
            this.undobtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.undobtn.TabIndex = 22;
            this.undobtn.TabStop = false;
            this.undobtn.Visible = false;
            this.undobtn.Click += new System.EventHandler(this.undobtn_Click);
            // 
            // undolbl
            // 
            this.undolbl.AutoSize = true;
            this.undolbl.BackColor = System.Drawing.Color.Transparent;
            this.undolbl.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.undolbl.Location = new System.Drawing.Point(92, 241);
            this.undolbl.Name = "undolbl";
            this.undolbl.Size = new System.Drawing.Size(107, 49);
            this.undolbl.TabIndex = 23;
            this.undolbl.Text = "undo";
            this.undolbl.Visible = false;
            // 
            // autosolve
            // 
            this.autosolve.BackColor = System.Drawing.Color.Transparent;
            this.autosolve.Image = ((System.Drawing.Image)(resources.GetObject("autosolve.Image")));
            this.autosolve.Location = new System.Drawing.Point(94, 127);
            this.autosolve.Name = "autosolve";
            this.autosolve.Size = new System.Drawing.Size(129, 87);
            this.autosolve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.autosolve.TabIndex = 26;
            this.autosolve.TabStop = false;
            this.autosolve.Click += new System.EventHandler(this.autosolve_Click);
            // 
            // patha
            // 
            this.patha.AutoSize = true;
            this.patha.Location = new System.Drawing.Point(251, 127);
            this.patha.Name = "patha";
            this.patha.Size = new System.Drawing.Size(44, 16);
            this.patha.TabIndex = 27;
            this.patha.Text = "label1";
            this.patha.Visible = false;
            // 
            // closeallbtn
            // 
            this.closeallbtn.BackColor = System.Drawing.Color.Transparent;
            this.closeallbtn.Image = ((System.Drawing.Image)(resources.GetObject("closeallbtn.Image")));
            this.closeallbtn.Location = new System.Drawing.Point(984, 12);
            this.closeallbtn.Name = "closeallbtn";
            this.closeallbtn.Size = new System.Drawing.Size(60, 60);
            this.closeallbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closeallbtn.TabIndex = 28;
            this.closeallbtn.TabStop = false;
            this.closeallbtn.Click += new System.EventHandler(this.closeallbtn_Click);
            // 
            // thelevels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1053, 645);
            this.Controls.Add(this.closeallbtn);
            this.Controls.Add(this.patha);
            this.Controls.Add(this.autosolve);
            this.Controls.Add(this.undolbl);
            this.Controls.Add(this.undobtn);
            this.Controls.Add(this.optionbtn);
            this.Controls.Add(this.timershowlbl);
            this.Controls.Add(this.timerlbl);
            this.Controls.Add(this.countstepslbl);
            this.Controls.Add(this.stepslbl);
            this.Controls.Add(this.againbtn);
            this.Controls.Add(this.returnbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "thelevels";
            this.Text = "Firstlevel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Firstlevel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playermovement);
            ((System.ComponentModel.ISupportInitialize)(this.returnbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.againbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.undobtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autosolve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeallbtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox returnbtn;
        private System.Windows.Forms.PictureBox againbtn;
        private System.Windows.Forms.Label stepslbl;
        private System.Windows.Forms.Label countstepslbl;
        private System.Windows.Forms.Label timerlbl;
        private System.Windows.Forms.Label timershowlbl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox optionbtn;
        private System.Windows.Forms.PictureBox undobtn;
        private System.Windows.Forms.Label undolbl;
        private System.Windows.Forms.PictureBox autosolve;
        private System.Windows.Forms.Label patha;
        private System.Windows.Forms.PictureBox closeallbtn;
    }
}