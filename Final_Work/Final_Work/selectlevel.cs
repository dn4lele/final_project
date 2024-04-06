using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Final_Work
{
    public partial class selectlevel : Form
    {

        public selectlevel()
        {
            InitializeComponent();

        }

        private List<PictureBox> picLevels;
        private List<Button> scoreButtons;

        private void selectlevel_Load(object sender, EventArgs e)
        {
            returnbtn.Location = new Point(10, 10);


            int commonY = (this.Height - piclvl1.Height) / 2 - 50;
            
            picLevels = new List<PictureBox> { piclvl0, piclvl1, piclvl2, piclvl3 , piclvl4 , piclvl5 , piclvl6 , piclvl7 , piclvl8, piclvl9, piclvl10 };
            scoreButtons = new List<Button> { score0btn, score1btn, score2btn, score3btn, score4btn, score5btn, score6btn, score7btn, score8btn, score9btn, score10btn };

            //change the size
            for (int i = 0; i < picLevels.Count; i++) { 
                picLevels[i].Size = new Size(250, 250);
                picLevels[i].Visible = false;
                picLevels[i].MouseHover += PictureBox_MouseHover;
                picLevels[i].MouseLeave += PictureBox_MouseLeave;
                int currentmove = i;
                picLevels[i].Click += (s, args) => enterlvl_click(s, args, currentmove);

            }

            for (int i = 0; i < scoreButtons.Count; i++) { 
                scoreButtons[i].Size = new Size(250, 40);
                scoreButtons[i].Visible = false;

                int currentScoreIndex = i;
                scoreButtons[i].Click += (s, args) => show_score(s, args, currentScoreIndex);
            }

            try
            {
                FileStream f = new FileStream("levelsaved.dangame", FileMode.Open);
                f.Close();
            }
            catch //didnt build
            {
                picLevels.RemoveAt(0);
                scoreButtons.RemoveAt(0);
            }


            for (int level = 0; level < 4 ; level++) // i want it to show only 4
            {
                int xOffset = ((this.Width - piclvl1.Width) * (level + 1) / 4) - 200;

                //position them
                picLevels[level].Location = new Point(xOffset, commonY);
                scoreButtons[level].Location = new Point(xOffset, commonY + 300);
                

                //make them visible
                picLevels[level].Visible = true;
                scoreButtons[level].Visible = true;
            }
            right_arrow.Location = new Point(this.Width -150, commonY+100);
            leftarrow.Location = new Point( 0, commonY + 100);

            closeallbtn.Location = new Point((this.Width - closeallbtn.Width) - 10, 10);
            optionbtn.Location = new Point((this.Width - optionbtn.Width)- closeallbtn.Width - 10, 10);
        }


        //all buttons to start the level
        private void enterlvl_click(object sender, EventArgs e , int num) {
            //check if there is save
            try
            {
                FileStream f = new FileStream("lvl" + num + "save.cool", FileMode.Open);
                BinaryReader r = new BinaryReader(f);
                

                DialogResult result = MessageBox.Show("We found you have save on this map\ndo you want to continue the progress?\ncancle will delete the progress", "Found Progress", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    int maxx = r.ReadInt32();
                    int maxy = r.ReadInt32();

                    for (int i = 0; i < maxx; i++)
                    {
                        for (int j = 0; j < maxy; j++)
                        {
                             Int32.Parse(r.ReadString());
                        }
                    }   
                    bool stepondot= r.ReadBoolean();
                    bool boxstepondot = r.ReadBoolean();
                    int steps = r.ReadInt32();
                    int elapsedSeconds = r.ReadInt32();

                    r.Close();
                    f.Close();

                    Form continueSavedLevel = new thelevels(num,maxx,maxy, stepondot, boxstepondot,steps,elapsedSeconds);
                    continueSavedLevel.Show();
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    r.Close();
                    f.Close();
                    File.Delete("lvl" + num + "save.cool");
                    //no save
                }
                else
                {
                    r.Close();
                    f.Close();
                }           
               

            }
            catch
            {
                //no save
            }


            Form thelevel = new thelevels(num);
            thelevel.Show();

        }


        //hovers and leaves
        private void PictureBox_MouseHover(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.Size = new Size(270, 270);
            }
        }
        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.Size = new Size(250, 250);
            }
        }


        //score buttons

        private void show_score(object sender, EventArgs e , int num) {
            Form a = new bestscores(num);
            a.ShowDialog();
        }
       

        //options
        private void optionbtn_Click(object sender, EventArgs e)
        {
            Form a = new optionf(Form1.WindowsMediaPlayer);
            a.ShowDialog();
        }


        //return 
        private void returnbtn_Click(object sender, EventArgs e)
        {
            Form back = new second_screen();
            back.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            PictureBox removedPictureBox = picLevels[0];
            picLevels.RemoveAt(0);
            picLevels.Add(removedPictureBox);


            Button removedButton = scoreButtons[0];
            scoreButtons.RemoveAt(0);
            scoreButtons.Add(removedButton);


            show();
        }

        private void show()
        {
            int commonY = (this.Height - piclvl1.Height) / 2 - 50;

            for (int level = 0; level < 4; level++) // i want it to show only 4
            {
                int xOffset = ((this.Width - piclvl1.Width) * (level + 1) / 4) - 200;

                //position them
                picLevels[level].Location = new Point(xOffset, commonY);
                scoreButtons[level].Location = new Point(xOffset, commonY + 300);


                //make them visible
                picLevels[level].Visible = true;
                scoreButtons[level].Visible = true;
            }
            for (int level = 4; level < picLevels.Count; level++) // i want it to show only 4
            {
                //make them visible
                picLevels[level].Visible = false;
                scoreButtons[level].Visible = false;
            }

        }

        private void leftarrow_Click(object sender, EventArgs e)
        {
            int lastIndex = picLevels.Count - 1;

            PictureBox removedPictureBox = picLevels[picLevels.Count - 1];
            picLevels.RemoveAt(lastIndex);
            picLevels.Insert(0, removedPictureBox);

            Button removedButton = scoreButtons[scoreButtons.Count-1];
            scoreButtons.RemoveAt(lastIndex);
            scoreButtons.Insert(0, removedButton);


            show();


        }

        private void closeallbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
        }
    }
}
