﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Work
{
    internal static class builderoflevels
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


        public static PictureBox[,] Lvl0(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            try
            {
                FileStream f = new FileStream("levelsaved.dangame", FileMode.Open);
                BinaryReader sr = new BinaryReader(f);
                int choice;
                maxx = sr.ReadInt32();
                maxy = sr.ReadInt32();


                int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
                int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

                arr = new PictureBox[maxx, maxy];
                for (int i = 0; i < maxx; i++)
                {
                    for (int j = 0; j < maxy; j++)
                    {
                        arr[i, j] = new PictureBox();
                        arr[i, j].Size = new Size(65, 65);
                        arr[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                        arr[i, j].Location = new Point(xx, yy);

                        //read the file
                        choice = Int32.Parse(sr.ReadString());
                        arr[i, j].Tag = choice.ToString();
                        arr[i, j].BackgroundImage = imgarr[choice];




                        if (choice >= 2)
                        {
                            arr[i, j].BackgroundImage = imgarr[1];
                            arr[i, j].Image = imgarr[choice];
                        }

                        arr[i, j].BackColor = Color.Transparent;
                        form.Controls.Add(arr[i, j]);

                        xx += 65;
                    }
                    yy += 65;
                    xx = (form.ClientSize.Width - (maxx * 65)) / 2;
                }

                sr.Close();
                f.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            return arr;


        }

        public static PictureBox[,] Midgamesaved(Form form, int levelnum ,int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            try
            {
                FileStream f = new FileStream("lvl" + levelnum+ "save.cool", FileMode.Open);
                BinaryReader sr = new BinaryReader(f);
                int choice;
                maxx = sr.ReadInt32();
                maxy = sr.ReadInt32();


                int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
                int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

                arr = new PictureBox[maxx, maxy];
                for (int i = 0; i < maxx; i++)
                {
                    for (int j = 0; j < maxy; j++)
                    {
                        arr[i, j] = new PictureBox();
                        arr[i, j].Size = new Size(65, 65);
                        arr[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                        arr[i, j].Location = new Point(xx, yy);

                        //read the file
                        choice = Int32.Parse(sr.ReadString());
                        arr[i, j].Tag = choice.ToString();
                        arr[i, j].BackgroundImage = imgarr[choice];




                        if (choice >= 2)
                        {
                            arr[i, j].BackgroundImage = imgarr[1];
                            arr[i, j].Image = imgarr[choice];
                        }

                        arr[i, j].BackColor = Color.Transparent;
                        form.Controls.Add(arr[i, j]);

                        xx += 65;
                    }
                    yy += 65;
                    xx = (form.ClientSize.Width - (maxx * 65)) / 2;
                }

                sr.Close();
                f.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            return arr;


        }


        public static PictureBox[,] Lvl1(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr) {


            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

            arr = new PictureBox[maxx, maxy];
            for (int i = 0; i < maxy; i++)
            {
                for (int j = 0; j < maxx; j++)
                {
                    arr[i, j] = new PictureBox();
                    arr[i, j].Size = new Size(65, 65);
                    arr[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    arr[i, j].Location = new Point(xx, yy);
                    if (i == 0 || i == 6 || j == 0 || j == 6)
                    {
                        arr[i, j].Tag = "0";
                        arr[i, j].BackgroundImage = imgarr[0];
                    }
                    else
                    {
                        arr[i, j].Tag = "1";
                        arr[i, j].BackgroundImage = imgarr[1];

                    }

                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }

            //player
            arr[2,5].Tag = "5";
            arr[2,5].Image = imgarr[5];

            //box
            arr[2, 4].Tag = "2";
            arr[2, 4].Image = imgarr[2];

            arr[4, 4].Tag = "2";
            arr[4, 4].Image = imgarr[2];

            //targets

            arr[3, 2].Tag = "3";
            arr[3, 2].Image = imgarr[3];

            arr[4, 2].Tag = "3";
            arr[4, 2].Image = imgarr[3];




            return arr;
        }


        public static PictureBox[,] Lvl2(Form form, int maxx, int maxy , PictureBox[,] arr , Image[] imgarr) {


            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

            arr = new PictureBox[maxx, maxy];
            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    arr[i, j] = new PictureBox();
                    arr[i, j].Size = new Size(65, 65);
                    arr[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    arr[i, j].Location = new Point(xx, yy);
                    if (i == 0 || i == maxx - 1 || j == 0 || j == maxy - 1)
                    {
                        arr[i, j].Tag = "0"; // Wall
                        arr[i, j].BackgroundImage = imgarr[0];
                    }
                    else
                    {
                        arr[i, j].Tag = "1"; // Floor
                        arr[i, j].BackgroundImage = imgarr[1];
                    }

                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }

            //walls
            arr[1, 1].Tag = "0"; 
            arr[1, 1].BackgroundImage = imgarr[0];

            arr[2, 1].Tag = "0";
            arr[2, 1].BackgroundImage = imgarr[0];

            arr[2, 2].Tag = "0";
            arr[2, 2].BackgroundImage = imgarr[0];

            arr[4, 4].Tag = "0";
            arr[4, 4].BackgroundImage = imgarr[0];

            arr[5, 4].Tag = "0";
            arr[5, 4].BackgroundImage = imgarr[0];

            //boxes
            arr[3, 2].Tag = "2";
            arr[3, 2].Image = imgarr[2];

            arr[4, 2].Tag = "2";
            arr[4, 2].Image = imgarr[2];


            //targets
            arr[1, 2].Tag = "3";
            arr[1, 2].Image = imgarr[3];

            arr[1, 3].Tag = "3";
            arr[1, 3].Image = imgarr[3];

            //player
            arr[5, 2].Tag = "5";
            arr[5, 1].Image= imgarr[5];






            return arr;
        }


        public static PictureBox[,] Lvl3(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

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
                    }

                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }

            //person
            arr[5, 4].Tag = "5";
            arr[5, 4].Image = imgarr[5];


            

            //walls
            arr[3,2].Tag = "0"; // Wall
            arr[3,2].BackgroundImage = imgarr[0];

            arr[3, 4].Tag = "0"; // Wall
            arr[3, 4].BackgroundImage = imgarr[0];



            //box
            arr[3,3].Tag = "2";
            arr[3,3].Image = imgarr[2];

            arr[4, 2].Tag = "2";
            arr[4, 2].Image = imgarr[2];

            //targets
            arr[1,3].Tag = "3";
            arr[1, 3].Image = imgarr[3];

            arr[1, 4].Tag = "3";
            arr[1, 4].Image = imgarr[3];



            return arr;
        }



        public static PictureBox[,] Lvl4(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

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
                    }

                    


                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }
            //person
            arr[1, 3].Tag = "5";
            arr[1, 3].Image = imgarr[5];

            //walls
            arr[1,1].Tag = "0"; // Wall
            arr[1,1].BackgroundImage = imgarr[0];

            arr[1, 2].Tag = "0"; // Wall
            arr[1, 2].BackgroundImage = imgarr[0];

            arr[2, 2].Tag = "0"; // Wall
            arr[2, 2].BackgroundImage = imgarr[0];

            arr[2, 1].Tag = "0"; // Wall
            arr[2, 1].BackgroundImage = imgarr[0];

            arr[1, 4].Tag = "0"; // Wall
            arr[1, 4].BackgroundImage = imgarr[0];


            //box
            arr[2,3].Tag = "2";
            arr[2,3].Image = imgarr[2];

            arr[3,2].Tag = "2";
            arr[3,2].Image = imgarr[2];

            arr[4,4].Tag = "2";
            arr[4,4].Image = imgarr[2];

            //targets
            arr[2, 4].Tag = "3";
            arr[2, 4].Image = imgarr[3];

            arr[4, 2].Tag = "3";
            arr[4, 2].Image = imgarr[3];

            arr[4, 5].Tag = "3";
            arr[4, 5].Image = imgarr[3];

            return arr;
        }

        public static PictureBox[,] Lvl5(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

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
                    }

                    if (i == 1 && j <= 2) {//walls
                        arr[i, j].Tag = "0"; 
                        arr[i, j].BackgroundImage = imgarr[0];
                    }

                    if(i==6 && j>=5){//walls
                        arr[i, j].Tag = "0";
                        arr[i, j].BackgroundImage = imgarr[0];
                    }

                    if (j == 1 && i >= 5) {
                        arr[i, j].Tag = "0";
                        arr[i, j].BackgroundImage = imgarr[0];
                    }

                    if (j == 6 && i <= 2)
                    {
                        arr[i, j].Tag = "0";
                        arr[i, j].BackgroundImage = imgarr[0];
                    }



                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }
            //person
            arr[6, 2].Tag = "5";
            arr[6, 2].Image = imgarr[5];

            //walls
            arr[3,2].Tag = "0";
            arr[3,2].BackgroundImage = imgarr[0];

            arr[5,3].Tag = "0";
            arr[5,3].BackgroundImage = imgarr[0];

            arr[2,4].Tag = "0";
            arr[2,4].BackgroundImage = imgarr[0];

            arr[4,5].Tag = "0";
            arr[4,5].BackgroundImage = imgarr[0];

            //box
            arr[2, 2].Tag = "2";
            arr[2, 2].Image = imgarr[2];

            arr[5, 2].Tag = "2";
            arr[5, 2].Image = imgarr[2];

            //targets
            arr[3, 5].Tag = "3";
            arr[3, 5].Image = imgarr[3];

            arr[5, 4].Tag = "3";
            arr[5, 4].Image = imgarr[3];


            return arr;
        }

        public static PictureBox[,] Lvl6(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

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
                    }

                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }
            //person
            arr[5, 3].Tag = "5";
            arr[5, 3].Image = imgarr[5];


            //box
            arr[3, 2].Tag = "2";
            arr[3, 2].Image = imgarr[2];

            arr[2, 2].Tag = "2";
            arr[2, 2].Image = imgarr[2];

            arr[3, 4].Tag = "2";
            arr[3, 4].Image = imgarr[2];

            //targets
            arr[4, 1].Tag = "3";
            arr[4, 1].Image = imgarr[3];

            arr[4, 2].Tag = "3";
            arr[4, 2].Image = imgarr[3];

            arr[5, 2].Tag = "3";
            arr[5, 2].Image = imgarr[3];


            //walls
            arr[1, 3].Tag = "0";
            arr[1, 3].BackgroundImage = imgarr[0];

            arr[1, 4].Tag = "0";
            arr[1, 4].BackgroundImage = imgarr[0];

            arr[1, 5].Tag = "0";
            arr[1, 5].BackgroundImage = imgarr[0];

            arr[2, 4].Tag = "0";
            arr[2, 4].BackgroundImage = imgarr[0];

            arr[2, 5].Tag = "0";
            arr[2, 5].BackgroundImage = imgarr[0];

            arr[4, 4].Tag = "0";
            arr[4, 4].BackgroundImage = imgarr[0];

            arr[5,1].Tag = "0";
            arr[5, 1].BackgroundImage = imgarr[0];

            return arr;
        }

        public static PictureBox[,] Lvl7(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

            arr = new PictureBox[maxx, maxy];
            for (int i = 0; i < maxx; i++)
            {
                for (int j = 0; j < maxy; j++)
                {
                    arr[i, j] = new PictureBox();
                    arr[i, j].Size = new Size(65, 65);
                    arr[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    arr[i, j].Location = new Point(xx, yy);

                    if (i == 0 || i == maxx - 1 || j == 0 || j == maxy - 1)
                    {
                        arr[i, j].Tag = "0"; // Wall
                        arr[i, j].BackgroundImage = imgarr[0];
                    }
                    else
                    {
                        arr[i, j].Tag = "1"; // Floor
                        arr[i, j].BackgroundImage = imgarr[1];
                    }


                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }
            //person
            arr[2 ,5].Tag = "5";
            arr[2, 5].Image = imgarr[5];

            //walls    
            arr[3, 1].Tag = "0";
            arr[3, 1].BackgroundImage = imgarr[0];

            arr[4, 1].Tag = "0";
            arr[4, 1].BackgroundImage = imgarr[0];

            arr[5, 1].Tag = "0";
            arr[5, 1].BackgroundImage = imgarr[0];

            arr[3, 3].Tag = "0";
            arr[3, 3].BackgroundImage = imgarr[0];

            arr[3, 5].Tag = "0";
            arr[3, 5].BackgroundImage = imgarr[0];

            arr[4, 5].Tag = "0";
            arr[4, 5].BackgroundImage = imgarr[0];

            arr[5, 5].Tag = "0";
            arr[5, 5].BackgroundImage = imgarr[0];

            arr[5, 4].Tag = "0";
            arr[5, 4].BackgroundImage = imgarr[0];



            //box
            arr[4, 2].Tag = "2";
            arr[4, 2].Image = imgarr[2];

            arr[1, 3].Tag = "2";
            arr[1, 3].Image = imgarr[2];


            //targets
            arr[1,5].Tag = "3";
            arr[1,5].Image = imgarr[3];

            arr[3,4].Tag = "3";
            arr[3,4].Image = imgarr[3];


            


            return arr;
        }

        public static PictureBox[,] Lvl8(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

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
                    }



                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }
            //person
            arr[4, 6].Tag = "5";
            arr[4, 6].Image = imgarr[5];

            
            //walls
            arr[4, 1].Tag = "0";
            arr[4, 1].BackgroundImage = imgarr[0];

            arr[5, 1].Tag = "0";
            arr[5, 1].BackgroundImage = imgarr[0];

            arr[2, 2].Tag = "0";
            arr[2, 2].BackgroundImage = imgarr[0];

            arr[4, 3].Tag = "0";
            arr[4, 3].BackgroundImage = imgarr[0];

            arr[4, 5].Tag = "0";
            arr[4, 5].BackgroundImage = imgarr[0];

            arr[1, 5].Tag = "0";
            arr[1, 5].BackgroundImage = imgarr[0];


            //box
            arr[4, 2].Tag = "2";
            arr[4, 2].Image = imgarr[2];

            arr[3, 2].Tag = "2";
            arr[3, 2].Image = imgarr[2];

            arr[3, 4].Tag = "2";
            arr[3, 4].Image = imgarr[2];

            //targets
            arr[1, 6].Tag = "3";
            arr[1, 6].Image = imgarr[3];

            arr[2, 3].Tag = "3";
            arr[2, 3].Image = imgarr[3];

            arr[2, 6].Tag = "3";
            arr[2, 6].Image = imgarr[3];




            return arr;
        }

        public static PictureBox[,] Lvl9(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

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
                    }



                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }
            //person
            arr[3,3].Tag = "5";
            arr[3,3].Image = imgarr[5];

            //walls
            arr[1, 1].Tag = "0";
            arr[1, 1].BackgroundImage = imgarr[0];

            arr[1, 2].Tag = "0";
            arr[1, 2].BackgroundImage = imgarr[0];

            arr[3, 1].Tag = "0";
            arr[3, 1].BackgroundImage = imgarr[0];

            arr[2, 1].Tag = "0";
            arr[2, 1].BackgroundImage = imgarr[0];


            //box
            arr[2, 3].Tag = "2";
            arr[2, 3].Image = imgarr[2];

            arr[3, 2].Tag = "2";
            arr[3, 2].Image = imgarr[2];

            arr[4, 3].Tag = "2";
            arr[4, 3].Image = imgarr[2];

            //targets
            arr[4, 1].Tag = "3";
            arr[4, 1].Image = imgarr[3];

            arr[4, 2].Tag = "3";
            arr[4, 2].Image = imgarr[3];

            arr[2, 2].Tag = "3";
            arr[2, 2].Image = imgarr[3];






            return arr;
        }

        public static PictureBox[,] Lvl10(Form form, int maxx, int maxy, PictureBox[,] arr, Image[] imgarr)
        {
            int xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            int yy = (form.ClientSize.Height - (maxy * 65)) / 2;

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
                    }



                    arr[i, j].BackColor = Color.Transparent;
                    form.Controls.Add(arr[i, j]);
                    xx += 65;
                }
                yy += 65;
                xx = (form.ClientSize.Width - (maxx * 65)) / 2;
            }
            //person
            arr[3, 3].Tag = "5";
            arr[3, 3].Image = imgarr[5];

            //walls
            arr[1, 4].Tag = "0";
            arr[1, 4].BackgroundImage = imgarr[0];

            arr[1, 5].Tag = "0";
            arr[1, 5].BackgroundImage = imgarr[0];


            arr[4, 5].Tag = "0";
            arr[4, 5].BackgroundImage = imgarr[0];

            arr[5, 5].Tag = "0";
            arr[5, 5].BackgroundImage = imgarr[0];


            arr[5, 2].Tag = "0";
            arr[5, 2].BackgroundImage = imgarr[0];

            arr[5, 1].Tag = "0";
            arr[5, 1].BackgroundImage = imgarr[0];

            

            arr[6, 5].Tag = "0";
            arr[6, 5].BackgroundImage = imgarr[0];

            //box
            arr[3, 4].Tag = "2";
            arr[3, 4].Image = imgarr[2];

            arr[4, 4].Tag = "2";
            arr[4, 4].Image = imgarr[2];

            arr[2, 2].Tag = "2";
            arr[2, 2].Image = imgarr[2];

            //targets
            arr[4, 2].Tag = "3";
            arr[4, 2].Image = imgarr[3];

            arr[4, 3].Tag = "3";
            arr[4, 3].Image = imgarr[3];

            arr[2, 3].Tag = "3";
            arr[2, 3].Image = imgarr[3];

            return arr;
        }


    }
}
