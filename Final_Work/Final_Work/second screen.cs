using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Final_Work
{
    public partial class second_screen : Form
    {
        public second_screen()
        {
            InitializeComponent();

        }

        private void stepslbl_Click(object sender, EventArgs e)
        {

        }

        private void almostclickbyd(object sender, EventArgs e)
        {
            pictureBox3.Visible= false;
            pictureBox4.Visible = true;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
        }
        private void almostclicklvels(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

        }

        private void second_screen_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((this.Width - pictureBox1.Width) / 2 - 400, (this.Height - pictureBox1.Height) / 2);
            pictureBox2.Location = new Point((this.Width - pictureBox2.Width) / 2 + 400, (this.Height - pictureBox2.Height) / 2);


            pictureBox3.Location = new Point((this.Width - pictureBox3.Width) / 2 - 400, (this.Height - pictureBox1.Height) / 2 -100);
            pictureBox4.Location = new Point((this.Width - pictureBox4.Width) / 2 + 400, (this.Height - pictureBox2.Height) / 2 -100);


            label1.Location = new Point((this.Width - label1.Width) / 2 - 400, (this.Height - pictureBox1.Height) / 2 + 300);
            label2.Location = new Point((this.Width - label2.Width) / 2 + 400, (this.Height - pictureBox1.Height) / 2 + 300);

            howtoplaybtn.Location = new Point((this.Width - howtoplaybtn.Width)/2, (this.Height - howtoplaybtn.Height)-20);

            title.Location = new Point((this.Width - title.Width) / 2 , 100);
            returnbtn.Location = new Point(10, 10);

            optionbtn.Location = new Point((this.Width - optionbtn.Width) - 10, 10);

        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form a = new selectlevel();
            a.ShowDialog();
        }

        private void optionbtn_Click(object sender, EventArgs e)
        {
            Form a = new optionf(Form1.WindowsMediaPlayer);
            a.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form a = new buildform();
            a.ShowDialog();
        }

        private void howtoplaybtn_Click(object sender, EventArgs e)
        {
            //show how to play on the first level
            Form instraction = new instructions();
            instraction.ShowDialog();
        }

   
    }
}
