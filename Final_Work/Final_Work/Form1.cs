using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Final_Work
{

    public partial class Form1 : Form
    {

        public static WindowsMediaPlayer WindowsMediaPlayer;

        public Form1()
        {
            InitializeComponent();


            WindowsMediaPlayer = new WindowsMediaPlayer();
            WindowsMediaPlayer.enabled = true;
            WindowsMediaPlayer.URL = "./sound/bgsound.wav";
            WindowsMediaPlayer.controls.play();
            

        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Exitbtn.Location = new Point((this.Width / 2) - (Exitbtn.Width / 2), (this.Height / 2)+100);
            optionsbtn.Location = new Point((this.Width / 2) - (optionsbtn.Width / 2), (this.Height / 2));
            startbtn.Location = new Point((this.Width/2 )- (startbtn.Width/2), (this.Height/2)-100); 
            titlelbl.Location = new Point((this.Width / 2) - (titlelbl.Width / 2), 100);
            label1.Location = new Point(0,this.Height- label1.Height);
        }

        private void startbtn_Click(object sender, EventArgs e)
        {
            Form sec_screen = new second_screen();
            sec_screen.Show();
            this.Hide();
        }

        private void optionsbtn_Click(object sender, EventArgs e)
        {
            Form a = new optionf(WindowsMediaPlayer);
            a.ShowDialog();
        }
    }
}
