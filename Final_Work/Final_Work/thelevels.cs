using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Final_Work
{
    public partial class thelevels : Form
    {

        bool stepOnDot = false;
        bool boxstepOnDot = false;
        Image[] imgarr = new Image[20];
        

        //diffrent each level
        int whatlevel = 0;
        PictureBox[,] arr;
        int maxx = 9;
        int maxy = 9;

        //stack of the moves
        Stack<undoc> everymove = new Stack<undoc>();

        bool useundo = false;


        public thelevels(int level  )
        {
            InitializeComponent();

            whatlevel = level;


        }

        int stepcounter = 0;
        int elapsedSeconds = 0;
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


        private void helpbuilder(int maxx , int maxy) {
            Button[,] arr1;

            int xx = (this.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (this.ClientSize.Height - (maxy * 65)) / 2;

            arr1 = new Button[maxx, maxy];
            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {

                    arr1[i, j] = new Button();
                    arr1[i, j].Text = i.ToString() + ", " + j.ToString();

                    arr1[i, j].Size = new Size(65, 65);
                    arr1[i, j].Location = new Point(xx, yy);
                    if (i == 0 || i == maxx-1 || j == 0 || j == maxy-1)
                    {
                        arr1[i, j].Tag = "0";
                        arr1[i, j].BackgroundImage = imgarr[0];
                    }
                    else
                    {
                        arr1[i, j].Tag = "1";
                        arr1[i, j].BackgroundImage = imgarr[1];

                    }

                    arr1[i, j].BackColor = Color.Transparent;
                    this.Controls.Add(arr1[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (this.ClientSize.Width - (maxx * 65)) / 2;
            }
            

        }

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

        private void Firstlevel_Load(object sender, EventArgs e)
        {
            LoadImages();




            //check what level
            switch (whatlevel)
            {
                case 1:
                    //helpbuilder(7, 7);
                    maxx = 7;
                    maxy = 7;
                    arr = builderoflevels.Lvl1(this, maxx, maxy, arr, imgarr);
                    break;

                case 2:
                    maxx = 9;
                    maxy = 9;
                    arr = builderoflevels.Lvl2(this, maxx, maxy, arr, imgarr);
                    break;

                case 3:
                    maxx = 9;
                    maxy = 11;
                    arr = builderoflevels.Lvl3(this, maxx, maxy, arr, imgarr);
                    break;

                case 4:
                    maxx = 7;
                    maxy = 7;
                    arr = builderoflevels.Lvl4(this, maxx, maxy, arr, imgarr);
                    break;

                case 5:
                    maxx = 8;
                    maxy = 8;
                    arr = builderoflevels.Lvl5(this, maxx, maxy, arr, imgarr);
                    break;

                case 6:
                    maxx = 9;
                    maxy = 8;
                    arr = builderoflevels.Lvl6(this, maxx, maxy, arr, imgarr);
                    break;

                    //change
                case 7:
                    maxx = 7;
                    maxy = 8;
                    arr = builderoflevels.Lvl7(this, maxx, maxy, arr, imgarr);
                    break;

                case 8:
                    maxx = 8;
                    maxy = 8;
                    arr = builderoflevels.Lvl8(this, maxx, maxy, arr, imgarr);
                    break;

                case 9:
                    maxx = 7;
                    maxy = 9;
                    arr = builderoflevels.Lvl9(this, maxx, maxy, arr, imgarr);
                    break;

                case 10:
                    maxx = 8;
                    maxy = 7;
                    arr = builderoflevels.Lvl10(this, maxx, maxy, arr, imgarr);
                    break;

                case 0:
                    try
                    {
                        FileStream f = new FileStream("levelsaved.dangame", FileMode.Open);
                        BinaryReader sr = new BinaryReader(f);

                        maxx = sr.ReadInt32();
                        maxy = sr.ReadInt32();

                        sr.Close();
                        f.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }

                    arr = builderoflevels.Lvl0(this, maxx, maxy, arr, imgarr);
                    break;



                default:
                    // Handle the default case if whatlevel doesn't match any of the specified cases
                    break;
            }

            //location the timer and return
            returnbtn.Location = new Point(10, 10);
            againbtn.Location = new Point((this.ClientSize.Width - againbtn.Width) / 2, this.ClientSize.Height - 100);

            stepslbl.Location = new Point(this.ClientSize.Width - (stepslbl.Width+500)/2 , 200);
            countstepslbl.Location=new Point(this.ClientSize.Width - (countstepslbl.Width+500)/2, 250);

            timerlbl.Location = new Point(this.ClientSize.Width - (timerlbl.Width + 500) / 2, 500);
            timershowlbl.Location = new Point(this.ClientSize.Width - (timerlbl.Width + 500) / 2, 550);

            optionbtn.Location = new Point((this.Width - optionbtn.Width) - 10, 10);

            undobtn.Location = new Point(20 + undobtn.Width , this.ClientSize.Height / 2 + 50);
            undolbl.Location = new Point(20 + undolbl.Width  , (this.ClientSize.Height / 2 ));


            //save the first position 
            everymove.Push(new undoc(arr, stepOnDot));
        }


        /* before i wanted to build spesific class that build all lvls
        private void floormade()
        {

            int xx = (this.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (this.ClientSize.Height - (maxy * 65)) / 2;

            arr = new PictureBox[maxx, maxy];
            for (int i = 0; i < maxy; i++)
            {
                for (int j = 0; j < maxx; j++)
                {
                    arr[i, j] = new PictureBox();
                    arr[i, j].Size = new Size(65, 65);
                    arr[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    arr[i, j].Location = new Point(xx, yy);
                    if (i == 0 || i == 8 || j == 0 || j == 8)
                    {
                        arr[i, j].Tag = "0";
                        arr[i, j].BackgroundImage = imgarr[0];
                    }
                    else
                    {
                        arr[i, j].Tag = "1";
                        arr[i, j].BackgroundImage = imgarr[1];

                    }

                    if (i < 6 && j >= 6)
                    {
                        arr[i, j].Tag = "0";
                        arr[i, j].BackgroundImage = imgarr[0];
                    }


                    if (j == 2 && i <= 5 && i > 2)
                    {
                        arr[i, j].Tag = "0";
                        arr[i, j].BackgroundImage = imgarr[0];
                    }

                    arr[i, j].BackColor = Color.Transparent;
                    Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (this.ClientSize.Width - (maxx * 65)) / 2;
            }




            arr[3, 1].Tag = "0";
            arr[3, 1].BackgroundImage = imgarr[0];

            arr[4, 3].Tag = "0";
            arr[4, 3].BackgroundImage = imgarr[0];

            arr[1, 1].Tag = "0";
            arr[1, 1].BackgroundImage = imgarr[0];

            arr[1, 2].Tag = "0";
            arr[1, 2].BackgroundImage = imgarr[0];

            //boxes
            arr[2, 3].Tag = "2";
            arr[2, 3].Image = imgarr[2];

            arr[3,4].Tag = "2";
            arr[3,4].Image = imgarr[2];

            arr[6, 4].Tag = "2";
            arr[6, 4].Image = imgarr[2];

            arr[6, 5].Tag = "2";
            arr[6, 5].Image = imgarr[2];

            arr[6, 1].Tag = "2";
            arr[6, 1].Image = imgarr[2];

            arr[4,4].Tag = "2";
            arr[4,4].Image = imgarr[2];

            //targets
            arr[2, 1].Tag = "3";
            arr[2, 1].Image = imgarr[3];

            arr[3, 5].Tag = "3";
            arr[3, 5].Image = imgarr[3];

            arr[5, 4].Tag = "3";
            arr[5, 4].Image = imgarr[3];

            arr[4, 1].Tag = "3";
            arr[4, 1].Image = imgarr[3];

            arr[7,4].Tag = "3";
            arr[7,4].Image = imgarr[3];

            arr[6,7].Tag = "3";
            arr[6,7].Image = imgarr[3];

            arr[6,3].Tag = "3";
            arr[6, 3].Image = imgarr[3];


            //hitturget

            arr[6, 3].Tag = "4";
            arr[6, 3].Image = imgarr[4];


            //PLAYER MADE
            arr[2, 2].Tag = "5";
            arr[2, 2].Image = imgarr[5];


        }

        */


        public void MovePlayer(int xOffset, int yOffset , bool havemove)
        {
            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    if (havemove) { 
                        if (arr[i, j].Tag.Equals("5")) // Check if it's the player character
                        {
                            int nextX = i + xOffset;
                            int nextY = j + yOffset;
                           
                            if (IsValidMove(nextX, nextY)) // clear move nothing infront
                            {
                                stepcounter++;

                                if (stepOnDot)
                                {
                                    arr[i, j].Tag = "3";
                                    arr[i, j].Image = imgarr[3];
                                }
                                else
                                {
                                    arr[i, j].Tag = "1";
                                    arr[i, j].Image = null;
                                }

                                if (arr[nextX, nextY].Tag.Equals("3"))
                                    stepOnDot = true;
                                else
                                    stepOnDot = false;

                                


                                // Move the player

                                arr[nextX, nextY].Tag = "5";
                                arr[nextX, nextY].Image = GetPlayerImage(xOffset, yOffset);
                                havemove=false;
                            }
                            else if (IsBoxMove(nextX, nextY))
                            {
                                // Check if there's a box to move
                                int boxNextX = nextX + xOffset;
                                int boxNextY = nextY + yOffset;

                                if (boxIsValidMove(boxNextX, boxNextY))
                                {
                                    stepcounter++;


                                    if (stepOnDot)
                                    {
                                        arr[i, j].Tag = "3";
                                        arr[i, j].Image = imgarr[3];
                                    }
                                    else
                                    {
                                        arr[i, j].Tag = "1";
                                        arr[i, j].Image = null;
                                    }

                                    if (arr[boxNextX, boxNextY].Tag.Equals("3")) {
                                        boxstepOnDot = true;
                                        stepOnDot = false;
                                    }
                                    else {
                                        boxstepOnDot = false;
                                        stepOnDot=false;
                                    }


                                    if (boxstepOnDot) {
                                        // Move the box and make it dark
                                        arr[boxNextX, boxNextY].Tag = "4";
                                        arr[boxNextX, boxNextY].Image = imgarr[4];
                                    }
                                    else
                                    {
                                        // Move the box
                                        arr[boxNextX, boxNextY].Tag = "2";
                                        arr[boxNextX, boxNextY].Image = imgarr[2];
                                    }

                                    

                                    // Move the player

                                    arr[nextX, nextY].Tag = "5";
                                    arr[nextX, nextY].Image = GetPlayerImage(xOffset, yOffset);
                                    havemove = false;

                                }
                            }

                            else if (goodboxmoved(nextX, nextY))
                            {

                                // Check if there's a box to move
                                int boxNextX = nextX + xOffset;
                                int boxNextY = nextY + yOffset;

                                if (boxIsValidMove(boxNextX, boxNextY))
                                {

                                    stepcounter++;

                                    if (stepOnDot)
                                    {
                                        arr[i, j].Tag = "3";
                                        arr[i, j].Image = imgarr[3];
                                    }
                                    else
                                    {
                                        arr[i, j].Tag = "1";
                                        arr[i, j].Image = null;
                                    }   

                                    stepOnDot = true;//person step on dot

                                    if (arr[boxNextX, boxNextY].Tag.Equals("3"))
                                        boxstepOnDot = true;
                                    else
                                        boxstepOnDot = false;


                                    if (boxstepOnDot)
                                    {
                                        // Move the box and make it dark
                                        arr[boxNextX, boxNextY].Tag = "4";
                                        arr[boxNextX, boxNextY].Image = imgarr[4];
                                    }
                                    else
                                    {
                                        // Move the box
                                        arr[boxNextX, boxNextY].Tag = "2";
                                        arr[boxNextX, boxNextY].Image = imgarr[2];
                                    }



                                    // Move the player
                                    arr[nextX, nextY].Tag = "5";
                                    arr[nextX, nextY].Image = GetPlayerImage(xOffset, yOffset);
                                    havemove = false;

                                }
                            }


                        }

                    }
                }
            }
        }


        

        private bool boxIsValidMove(int x, int y)
        {
            return x >= 0 && x < maxx && y >= 0 && y < maxy && !arr[x, y].Tag.Equals("0") && !arr[x, y].Tag.Equals("2") && !arr[x, y].Tag.Equals("4");
        }

        private bool IsValidMove(int x, int y)
        {
            return x >= 0 && x < maxx && y >= 0 && y < maxy && !arr[x, y].Tag.Equals("0") && !arr[x, y].Tag.Equals("2") && !arr[x, y].Tag.Equals("4");
        }

        private bool IsBoxMove(int x, int y)
        {
            return x >= 0 && x < maxx && y >= 0 && y < maxy && (arr[x, y].Tag.Equals("2") );
        }

        private bool goodboxmoved(int x, int y)
        {
            return x >= 0 && x < maxx && y >= 0 && y < maxy && (arr[x, y].Tag.Equals("4"));
        }

        private Image GetPlayerImage(int xOffset, int yOffset)
        {
            if (yOffset == 1) return imgarr[6];  // Right
            if (yOffset == -1) return imgarr[7]; // Left
            if (xOffset == 1) return imgarr[8];  // up
            if (xOffset == -1) return imgarr[9]; // down

            // Default image (up) if no valid movement
            return imgarr[6];
        }



        /* MY FIRST TRY OF MOVMENT

        private void moveright(bool havemove) {
            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    if (havemove) // move once
                    {
                        if (arr[i, j].Tag.Equals("5") && !arr[i, j + 1].Tag.Equals("0")) // not an wall
                        {
                            if (arr[i, j + 1].Tag.Equals("2") && !arr[i, j + 2].Tag.Equals("0") && !arr[i, j + 2].Tag.Equals("2"))//move box
                            {
                                //move box
                                arr[i, j + 2].Tag = "2";
                                arr[i, j + 2].Image = imgarr[2];

                                //move left with box
                                arr[i, j].Tag = "1";
                                arr[i, j].Image = null;
                                arr[i, j + 1].Tag = "5";
                                arr[i, j + 1].Image = imgarr[6];
                                havemove = false;
                            }
                            else if (!arr[i, j + 1].Tag.Equals("2")) // move
                            {
                                //nothing front
                                arr[i, j].Tag = "1";
                                arr[i, j].Image = null;
                                arr[i, j + 1].Tag = "5";
                                arr[i, j + 1].Image = imgarr[6];
                                havemove = false;
                            }
                            //dont move
                        }

                    }

                }
            }
        }

        private void moveleft(bool havemove) {

            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    if (havemove) // move once
                    {
                        if (arr[i, j].Tag.Equals("5") && !arr[i, j - 1].Tag.Equals("0")) // not an wall
                        {

                            if (arr[i, j - 1].Tag.Equals("2") && !arr[i, j - 2].Tag.Equals("0") && !arr[i, j - 2].Tag.Equals("2"))// move with box
                            {
                                //move box
                                arr[i, j - 2].Tag = "2";
                                arr[i, j - 2].Image = imgarr[2];
                                //move
                                arr[i, j].Tag = "1";
                                arr[i, j].Image = null;
                                arr[i, j - 1].Tag = "5";
                                arr[i, j - 1].Image = imgarr[7];
                                havemove = false;
                            }
                            else if (!arr[i, j - 1].Tag.Equals("2")) //move
                            {
                                arr[i, j].Tag = "1";
                                arr[i, j].Image = null;
                                arr[i, j - 1].Tag = "5";
                                arr[i, j - 1].Image = imgarr[7];
                                havemove = false;
                            }
                                

                        }
                    }
                }
            }

        }

        private void moveup(bool havemove) {

            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    if (havemove) // move once
                    {
                        if (arr[i, j].Tag.Equals("5") && !arr[i - 1, j].Tag.Equals("0"))//not wall
                        {

                            if (arr[i - 1, j].Tag.Equals("2") && !arr[i - 2, j].Tag.Equals("0") && !arr[i - 2, j].Tag.Equals("2"))// move with box
                            {
                                //move box
                                arr[i - 2, j].Tag = "2";
                                arr[i - 2, j].Image = imgarr[2];
                                //move
                                arr[i, j].Tag = "1";
                                arr[i, j].Image = null;
                                arr[i - 1, j].Tag = "5";
                                arr[i - 1, j].Image = imgarr[9];
                                havemove = false;
                            }
                            else if (!arr[i - 1, j].Tag.Equals("2")) //move
                            {
                                arr[i, j].Tag = "1";
                                arr[i, j].Image = null;
                                arr[i - 1, j].Tag = "5";
                                arr[i - 1, j].Image = imgarr[9];
                                havemove = false;
                            
                            }
                                

                        }
                    }
                }
            }
        }

        private void movedown(bool havemove) {
            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    if (havemove)//move once
                    {
                        if (arr[i, j].Tag.Equals("5") && !arr[i + 1, j].Tag.Equals("0"))//not an wall
                        {
                            if (arr[i + 1, j].Tag.Equals("2") && !arr[i + 2, j].Tag.Equals("0") && !arr[i + 2, j].Tag.Equals("2"))// move with box
                            {
                                //movebox
                                arr[i + 2, j].Tag = "2";
                                arr[i + 2, j].Image = imgarr[2];
                                //move
                                arr[i, j].Tag = "1";
                                arr[i, j].Image = null;
                                arr[i + 1, j].Tag = "5";
                                arr[i + 1, j].Image = imgarr[8];
                                havemove = false;
                            }
                            else if (!arr[i + 1, j].Tag.Equals("2"))//move
                            {
                                arr[i, j].Tag = "1";
                                arr[i, j].Image = null;
                                arr[i + 1, j].Tag = "5";
                                arr[i + 1, j].Image = imgarr[8];
                                havemove = false;
                            }
                                
                        }
                    }
                }

            }
        }
        */

        bool win=true;
        private void wingame()
        {
            win = true; // Initialize to true before checking

            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    if (arr[i, j].Tag.Equals("3") || stepOnDot == true) 
                    {
                        win = false;
                        break; // No need to continue checking once win is false
                    }
                }

                if (!win) // If win is already false, no need to continue checking
                {
                    break;
                }
            }
        }

        
        public void playermovement(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) {
                if (e.KeyCode == Keys.Right)
                {
                    MovePlayer(0, 1, true);

                }
                else if (e.KeyCode == Keys.Left)
                {
                    MovePlayer(0, -1, true);
                }
                else if(e.KeyCode == Keys.Up)
                {
                    MovePlayer(-1, 0, true);

                }
                else if(e.KeyCode == Keys.Down)
                {
                    MovePlayer(1, 0, true);
                }

                everymove.Push(new undoc(everymove.Peek(), stepOnDot, arr));
                undolbl.Visible = true; // we moved so we can undo
                undobtn.Visible = true;
            }
           




            wingame();
            countstepslbl.Text = stepcounter.ToString();
            
            if (!win)
            {
                if (stepcounter == 1 )
                {
                    timer.Start();
                }
            }
            else {
                timer.Stop();
                MessageBox.Show("you won");
                Close();
                if (!useundo) //didnt used undo so you can save
                {
                    Form a = new savescore(stepcounter, timershowlbl.Text, whatlevel, elapsedSeconds);
                    a.ShowDialog();
                }
            }

        }
     

        private void returnbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
            Form a = new thelevels(whatlevel );
            a.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedSeconds);
            timershowlbl.Text = timeSpan.ToString("hh':'mm':'ss");

        }

        private void optionbtn_Click(object sender, EventArgs e)
        {
            Form a = new optionf(Form1.WindowsMediaPlayer);
            a.Show();
        }

        private void undobtn_Click(object sender, EventArgs e)
        {
            
            if (everymove.Count() <= 2) {
                undolbl.Visible = false; // we moved so we can undo
                undobtn.Visible = false;
            }

            useundo = true;
            timer.Stop();
            countstepslbl.Visible = false;
            stepslbl.Visible = false;

            undoc currentposition = everymove.Pop();//pop the current move 
            undoc lastposition = everymove.Peek();//take the last move he did

            int xOffset = currentposition.getplayer().X - lastposition.getplayer().X;
            int yOffset= currentposition.getplayer().Y - lastposition.getplayer().Y;

            //move the player
            if (currentposition.getplayerwasondot())
            {
                arr[currentposition.getplayer().X, currentposition.getplayer().Y].Tag = "3";
                arr[currentposition.getplayer().X, currentposition.getplayer().Y].Image = imgarr[3];
            }
            else
            {
                arr[currentposition.getplayer().X, currentposition.getplayer().Y].Tag = "1";
                arr[currentposition.getplayer().X, currentposition.getplayer().Y].Image = null;
            }

            //if it was stepondot save it
            stepOnDot = lastposition.getplayerwasondot();
           

            arr[lastposition.getplayer().X, lastposition.getplayer().Y].Tag = "5";
            arr[lastposition.getplayer().X, lastposition.getplayer().Y].Image = GetPlayerImage(xOffset, yOffset);


            //move the boxes
            for (int i = 0; i < currentposition.getboxes().Count(); i++) {
                if (currentposition.getboxwasondot()[i]) // if the box was on dot return the dot
                {
                    arr[currentposition.getboxes()[i].X, currentposition.getboxes()[i].Y].Tag = "3";
                    arr[currentposition.getboxes()[i].X, currentposition.getboxes()[i].Y].Image = imgarr[3];
                }
                else {
                    arr[currentposition.getboxes()[i].X, currentposition.getboxes()[i].Y].Tag = "1";
                    arr[currentposition.getboxes()[i].X, currentposition.getboxes()[i].Y].Image = null;
                }

                if (lastposition.getboxwasondot()[i])
                { // return regular box ordotbox
                    arr[lastposition.getboxes()[i].X, lastposition.getboxes()[i].Y].Tag = "4";
                    arr[lastposition.getboxes()[i].X, lastposition.getboxes()[i].Y].Image = imgarr[4];
                }
                else {
                    arr[lastposition.getboxes()[i].X, lastposition.getboxes()[i].Y].Tag = "2";
                    arr[lastposition.getboxes()[i].X, lastposition.getboxes()[i].Y].Image = imgarr[2];
                }
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agent man = new Agent(arr);

            Target t = new Target(0, new Point(4, 1));


            Dictionary<Point, Box> boxes = new Dictionary<Point, Box>();
            Point point1 = new Point(2, 3);
            Box box1 = new Box(0, new Point(2,3), new HashSet<Point>()) ;
            boxes.Add(point1, box1);


            man.evaluateBox(t, boxes,arr);

        }

    }
}
