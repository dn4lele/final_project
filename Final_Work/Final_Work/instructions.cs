using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Work
{
    public partial class instructions : Form
    {

        bool stepOnDot = false;
        bool boxstepOnDot = false;

        PictureBox[,] arr; // the map
        Image[] imgarr = new Image[20]; // the images
        int maxx = 7, maxy = 7;

        List<undoc> moves = new List<undoc>();
        int index = 0;
        

        public instructions()
        {
            InitializeComponent();
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

            //arrows
            imgarr[10] = Image.FromFile("./PNG/leftarrowkey.png");
            imgarr[11] = Image.FromFile("./PNG/uparrowkey.png");
            imgarr[12] = Image.FromFile("./PNG/downarrowkey.png");
            imgarr[13] = Image.FromFile("./PNG/rightarrowkey.png");


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



        private void instructions_Load(object sender, EventArgs e)
        {
            LoadImages();
            arr = builderoflevels.Lvl1(this, 7, 7, arr, imgarr); // the first map is 7 on 7
            returnbtn.Location = new Point(10, 10);
            optionbtn.Location = new Point((this.Width - optionbtn.Width) - 10, 10);
            infolbl.Location = new Point((this.Width+ infolbl.Width) / 2 - infolbl.Width, 10);


            keyslbl.Location = new Point((this.Width - keyslbl.Width) / 8, (this.Height- keyslbl.Height) /2 -100);
            buttonpic.Location = new Point((this.Width - buttonpic.Width) / 8, (this.Height - buttonpic.Height) / 2);

            backmove.Location = new Point(100, this.Height - backmove.Height);
            moveslbl.Location = new Point((this.Width - moveslbl.Width) / 2, this.Height - moveslbl.Height);
            forwordbutton.Location = new Point(this.Width - forwordbutton.Width - 100, this.Height - forwordbutton.Height);

            /* old way
            //make the solution in the list
            undoc move = new undoc(arr, false);
            moves.Add(move); // this is the first move 

            undoc newmove1 = new undoc(move);
            newmove1.MovePlayerLeft(arr);
            moves.Add(newmove1);

            undoc newmove2 = new undoc(newmove1);
            newmove2.MovePlayerLeft(arr);
            moves.Add(newmove2);

            undoc newmove3 = new undoc(newmove2);
            newmove3.MovePlayerUp(arr);
            moves.Add(newmove3);

            undoc newmove4 = new undoc(newmove3);
            newmove4.MovePlayerLeft(arr);
            moves.Add(newmove4);

            undoc newmove5 = new undoc(newmove4);
            newmove5.MovePlayerDown(arr);
            moves.Add(newmove5);


            undoc newmove6 = new undoc(newmove5);
            newmove6.MovePlayerRight(arr);
            moves.Add(newmove6);
            */

            // Start with the original position
            undoc currentPosition = new undoc(arr, false);
            moves.Add(currentPosition);  // this is the first move

            // Define a sequence of moves
            List<Action<PictureBox[,], undoc>> moveActions = new List<Action<PictureBox[,], undoc>>
            {
                (arr, obj) => obj.MovePlayerLeft(arr),
                (arr, obj) => obj.MovePlayerLeft(arr),
                (arr, obj) => obj.MovePlayerUp(arr),
                (arr, obj) => obj.MovePlayerLeft(arr),
                (arr, obj) => obj.MovePlayerDown(arr),
                //first box on 0-5 first box 
                (arr, obj) => obj.MovePlayerRight(arr),
                (arr, obj) => obj.MovePlayerRight(arr),
                (arr, obj) => obj.MovePlayerRight(arr),
                (arr, obj) => obj.MovePlayerDown(arr),
                (arr, obj) => obj.MovePlayerDown(arr),
                (arr, obj) => obj.MovePlayerLeft(arr),
                (arr, obj) => obj.MovePlayerLeft(arr),
                //6-12 secound box
            };

            // Generate moves using the list of actions
            foreach (var action in moveActions)
            {
                // Clone the current position to get a new position object
                undoc newPosition = new undoc(currentPosition);

                // Apply the move to the new position
                action(arr, newPosition);

                // Add the new position to the moves list
                moves.Add(newPosition);

                // Update currentPosition to the new position for the next iteration
                currentPosition = newPosition;
            }




            // Update the moves label
            moveslbl.Text = $"{index}/{moves.Count-1}";
        }


        private void optionbtn_Click(object sender, EventArgs e)
        {
            Form a = new optionf(Form1.WindowsMediaPlayer);
            a.Show();
        }

        private void returnbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void forwordbutton_Click(object sender, EventArgs e)
        {

            if(index< moves.Count-1)
            {
                movefunc(moves[index], moves[++index], false);
                moveslbl.Text = $"{index}/{moves.Count - 1}";
            }
            
        }

     
       
        private void backmove_Click_1(object sender, EventArgs e)
        {
            if (index > 0)
            {
                movefunc(moves[index], moves[--index], true);
                moveslbl.Text = $"{index}/{moves.Count - 1}";
            }
        }


        private Image getarrow(int xOffset, int yOffset)
        {
            if (yOffset == 1) return imgarr[13];  // Right
            if (yOffset == -1) return imgarr[10]; // Left
            if (xOffset == 1) return imgarr[12];  // up
            if (xOffset == -1) return imgarr[11]; // down

            // Default image (up) if no valid movement
            return null;
        }

        private void movefunc(undoc currentposition , undoc forwordmove , bool backwords)
        {
            
            int xOffset = forwordmove.getplayer().X - currentposition.getplayer().X ;
            int yOffset = forwordmove.getplayer().Y - currentposition.getplayer().Y ;
            if (backwords) {
                xOffset *= -1;
                yOffset *= -1;
                buttonpic.Image = null;
            }
            else
            {
                buttonpic.Image = getarrow(xOffset, yOffset);
            }

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
            


            arr[forwordmove.getplayer().X, forwordmove.getplayer().Y].Tag = "5";
            arr[forwordmove.getplayer().X, forwordmove.getplayer().Y].Image = GetPlayerImage(xOffset, yOffset);


            //move the boxes
            for (int i = 0; i < currentposition.getboxes().Count(); i++)
            {
                if (currentposition.getboxwasondot()[i]) // if the box was on dot return the dot
                {
                    arr[currentposition.getboxes()[i].X, currentposition.getboxes()[i].Y].Tag = "3";
                    arr[currentposition.getboxes()[i].X, currentposition.getboxes()[i].Y].Image = imgarr[3];
                }
                else
                {
                    if (backwords) { 
                    arr[currentposition.getboxes()[i].X, currentposition.getboxes()[i].Y].Tag = "1";
                    arr[currentposition.getboxes()[i].X, currentposition.getboxes()[i].Y].Image = null;
                    }
                }


                if (forwordmove.getboxwasondot()[i])
                { // return regular box ordotbox
                    arr[forwordmove.getboxes()[i].X, forwordmove.getboxes()[i].Y].Tag = "4";
                    arr[forwordmove.getboxes()[i].X, forwordmove.getboxes()[i].Y].Image = imgarr[4];
                }
                else
                {
                    arr[forwordmove.getboxes()[i].X, forwordmove.getboxes()[i].Y].Tag = "2";
                    arr[forwordmove.getboxes()[i].X, forwordmove.getboxes()[i].Y].Image = imgarr[2];
                }
            }


        }




    }


}

