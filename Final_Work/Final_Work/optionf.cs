using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Work
{
    public partial class optionf : Form
    {
        private WindowsMediaPlayer t_axWindowsMediaPlayer;


        public optionf(WindowsMediaPlayer axWindowsMediaPlayer)
        {
            InitializeComponent();
            t_axWindowsMediaPlayer=axWindowsMediaPlayer;
            

            if (t_axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                onoff.Text = "stop";
            }
            else
            {
                onoff.Text = "start ";
            }


        }


        private void onoff_CheckedChanged(object sender, EventArgs e)
        {
            if (t_axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                t_axWindowsMediaPlayer.controls.stop();
                onoff.Text = "start";
            }
            else {
                t_axWindowsMediaPlayer.controls.play();
                onoff.Text = "stop";
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int volume = hScrollBar1.Value;
            t_axWindowsMediaPlayer.settings.volume = volume;
        }

        private void optionf_Load(object sender, EventArgs e)
        {

        }

        
    }
}
