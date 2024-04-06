using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Final_Work
{
    public partial class buildform : Form
    {


        //tag 0  = wall
        //tag 1 = floor
        //tag 2 = box 
        //tag 3 = box place
        //tag 4 = good place
        //tag 5  = player

        //arr 6 = right
        //arr 7 = left
        //arr 8 = up 
        //arr 9 =down

        //tag 10 = was box place

        public buildform()
        {
            InitializeComponent();
        }


        Image[] imgarr = new Image[20];
        PictureBox[,] arr;
        int reround = 0;

        int maxx = 9, maxy = 9;

        private void LoadImages()
        {

            imgarr[0] = Image.FromFile("./PNG/WallRound_Brown.png");
            imgarr[1] = Image.FromFile("./PNG/GroundGravel_Dirt.png");
            imgarr[2] = Image.FromFile("./PNG/Crate_Gray.png");
            imgarr[3] = Image.FromFile("./PNG/EndPoint_Gray.png");
            imgarr[4] = Image.FromFile("./PNG/CrateDark_Gray.png");
            imgarr[5] = Image.FromFile("./PNG/Character4.png");
            imgarr[6] = Image.FromFile("./PNG/Character2.png");
            imgarr[7] = Image.FromFile("./PNG/Character1.png");
            imgarr[8] = Image.FromFile("./PNG/Character4.png");
            imgarr[9] = Image.FromFile("./PNG/Character8.png");


        }

        private void buildform_Load(object sender, EventArgs e)
        {
            LoadImages();

            
            menuStrip1.Location = new Point((this.Width - menuStrip1.Width) / 2, 0);

            title.Location = new Point((this.Width - title.Width) / 2, (20 + menuStrip1.Height));
            buildingnowlbl.Location = new Point((this.Width - buildingnowlbl.Width) / 2, (50 + title.Height));
            savebtn.Location = new Point((this.Width - savebtn.Width)-20, (this.Height - savebtn.Height)-20);
            newbtn.Location = new Point(20, (this.Height - savebtn.Height) - 20);

            returnbtn.Location = new Point(10, 10);
            closeallbtn.Location = new Point((this.Width - closeallbtn.Width) - 10, 10);
            optionbtn.Location = new Point((this.Width - optionbtn.Width) - closeallbtn.Width - 10, 10);

            label1.Location = new Point((this.Width - label1.Width) / 2-200, (this.Height - label1.Height) - 30);
            sizextxt.Location= new Point((this.Width - sizextxt.Width) / 2 - 200, (this.Height - sizextxt.Height));

            label2.Location = new Point((this.Width - label2.Width) / 2+200, (this.Height - label2.Height) - 30);
            sizeytxt.Location = new Point((this.Width - sizeytxt.Width) / 2 + 200, (this.Height - sizeytxt.Height));

            changesizebtn.Location = new Point((this.Width - changesizebtn.Width) / 2, (this.Height - changesizebtn.Height) );
            maxx = Int32.Parse(sizextxt.Text.ToString());
            maxy = Int32.Parse(sizeytxt.Text.ToString());

            byd();


        }



        public void PictureBox_Click(object sender, MouseEventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender;

            if (e.Button == MouseButtons.Left)
            {
                if (reround == 0) //pressed wall
                {
                    clickedPictureBox.Tag = "0";
                    clickedPictureBox.BackgroundImage = imgarr[0];
                    clickedPictureBox.Image = null;
                }
                else if (reround == 1)// press floor on wall
                {
                    clickedPictureBox.Tag = "1";
                    clickedPictureBox.BackgroundImage = imgarr[1];
                    clickedPictureBox.Image = null;
                }
                else if (reround >= 2 && reround <= 4 && !clickedPictureBox.Tag.Equals("0"))
                {
                    clickedPictureBox.Tag = reround.ToString();
                    clickedPictureBox.Image = imgarr[reround];
                }
                else if (reround == 5) // pressed player
                {
                    if (thereisplayer()) //there is
                    {
                        MessageBox.Show("There can be only 1 player in the game.");
                    }
                    else //there isent
                    {
                        clickedPictureBox.Tag = "5";
                        clickedPictureBox.Image = imgarr[5];
                    }
                }
                else { //pressd something on wall
                    MessageBox.Show("Can't add that object to a wall.");
                }
            }
        }

        //only 1 player on board
        private bool thereisplayer() {
            bool found = false;

            for (int i = 0; i < maxx; i++)
                for (int j = 0; j < maxy ; j++)
                    if (arr[i, j].Tag.Equals("5"))
                        found = true;

            return found;
        
        }



        //the build of the level
        private void byd() {
            int xx = (this.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (this.ClientSize.Height - (maxy * 65)) / 2;

            arr = new PictureBox[maxx, maxy];
            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    arr[i, j] = new PictureBox();
                    arr[i, j].Size = new Size(65, 65);
                    arr[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    arr[i, j].Location = new Point(xx, yy);

                    // Level 3 layout
                    if (i == 0 || i == maxx - 1 || j == 0 || j == maxy - 1)
                    {
                        arr[i, j].Tag = "0"; // Wall
                        arr[i, j].BackgroundImage = imgarr[0];
                    }
                    else
                    {
                        arr[i, j].Tag = "1"; // Floor
                        arr[i, j].BackgroundImage = imgarr[1];
                        arr[i, j].MouseClick += PictureBox_Click;

                    }

                    arr[i, j].BackColor = Color.Transparent;
                    this.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (this.ClientSize.Width - (maxx * 65)) / 2;
            }
        }

        //if box equals the targets
        private bool boxequaltargets()
        {
            int target = 0;
            int box = 0;

            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    if (arr[i, j].Tag.Equals("2"))
                        target++;
                    if (arr[i, j].Tag.Equals("3"))
                        box++;
                }
            }

            return target == box;
        }


        //save the map
        private void savebtn_Click(object sender, EventArgs e)
        {
            if (boxequaltargets() && thereisplayer())
            {
                //i need to save the maxx , maxy  and every picture tag 
                //and to solve it i only need an function that translate
                FileStream f = new FileStream("levelsaved.dangame", FileMode.Create);
                BinaryWriter sr = new BinaryWriter(f);
                try
                {
                    sr.Write(maxx);
                    sr.Write(maxy);
                    for (int i = 0; i < maxx; i++)
                        for (int j = 0; j < maxy; j++)
                            sr.Write(arr[i,j].Tag.ToString());

                    MessageBox.Show("level saved");


                    //delete other level scores
                    SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-S569GU1\\SQLEXPRESS;database=sokoban_game;Integrated Security=SSPI;");
                    SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                    mySqlConnection.Open();
                    mySqlCommand.CommandText = "delete from lvlsdata where lvl=0;";
                    mySqlCommand.ExecuteNonQuery();
                    mySqlConnection.Close();

                    Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    sr.Close();
                    f.Close();
                }


            }
            else {
                if(!boxequaltargets())
                    MessageBox.Show("for every box must be target");
                else
                    MessageBox.Show("must be an player in the game");

            }
        }



        //the menu strip
        private void boxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reround = 2;
            buildingnowlbl.Text = "Box";

        }

        private void targetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reround = 3;
            buildingnowlbl.Text = "Target";


        }

        private void boxontagetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reround = 4;
            buildingnowlbl.Text = "Box On Target";

        }

        private void floorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reround = 1;
            buildingnowlbl.Text = "Floor";

        }

        private void wallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reround = 0;
            buildingnowlbl.Text = "Wall";

        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reround = 5;
            buildingnowlbl.Text = "Player";

        }




        //return option and new
        private void returnbtn_Click(object sender, EventArgs e)
        {
            Form back = new second_screen();
            back.Show();
            this.Close();
        }

        private void optionbtn_Click(object sender, EventArgs e)
        {
            Form a = new optionf(Form1.WindowsMediaPlayer);
            a.ShowDialog();
        }

        private void changesizebtn_Click(object sender, EventArgs e)
        {
            foreach (PictureBox pb in arr)
            {
                this.Controls.Remove(pb);
                pb.Dispose(); // Dispose to release resources
            }
            arr = null;

            maxx = Int32.Parse(sizextxt.Text.ToString());
            maxy = Int32.Parse(sizeytxt.Text.ToString());
            byd();

        }

        private void closeallbtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            foreach (PictureBox pb in arr)
            {
                this.Controls.Remove(pb);
                pb.Dispose(); // Dispose to release resources
            }
            arr = null;

            maxx = Int32.Parse(sizextxt.Text.ToString());
            maxy = Int32.Parse(sizeytxt.Text.ToString());
            byd();


        }
    }
}
