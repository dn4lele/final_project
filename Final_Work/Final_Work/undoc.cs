using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Work
{
    internal class undoc
    {
        private bool playerwasondot;
        private Point player;
        private List<Point> boxes;
        private List<bool> boxwasondot;


        public undoc(PictureBox[,] arr , bool playerwasondot) {
            boxes= new List<Point> ();
            boxwasondot = new List<bool>();

            this.playerwasondot= playerwasondot;

            for (int i = 0; i < arr.GetLength(0); i++) {
                for (int j = 0; j < arr.GetLength(1); j++) {
                    if (arr[i,j].Tag.ToString() == "5")
                        this.player = new Point(i, j);
                    if (arr[i, j].Tag.ToString() == "2") { 
                        this.boxes.Add(new Point(i, j)); // this box dont on dot so it false in the other arr
                        this.boxwasondot.Add(false);
                    }

                    if (arr[i, j].Tag.ToString() == "4") { 
                        this.boxes.Add(new Point(i, j));
                        this.boxwasondot.Add(true);
                    }

                }
            }
        }


        public undoc(undoc other)
        {
            this.playerwasondot = other.playerwasondot;
            this.player = new Point(other.player.X, other.player.Y);

            this.boxes = new List<Point>(other.boxes); // Copy the list
            this.boxwasondot = new List<bool>(other.boxwasondot); // Copy the list
        }

        public undoc(undoc other, bool playerwasondot , PictureBox[,] arr)
        {
            this.playerwasondot = playerwasondot;
            this.player = new Point(other.player.X, other.player.Y);

            this.boxes = new List<Point>(other.boxes); // Copy the list
            this.boxwasondot = new List<bool>(other.boxwasondot); // Copy the list

            Point newplayerpos= player;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j].Tag.ToString() == "5")
                        newplayerpos = new Point(i, j);

                }
            }


            movePlayerAfterArrCahnge(newplayerpos.X-player.X, newplayerpos.Y-player.Y, arr);
        }


        public void movePlayerAfterArrCahnge(int xOffset, int yOffset, PictureBox[,] arr)
        {
            player.Y += yOffset;
            player.X += xOffset;

            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i] == player)
                {
                    Point boxNewPosition = new Point(boxes[i].X + xOffset, boxes[i].Y + yOffset);

                    if (arr[boxNewPosition.X, boxNewPosition.Y].Tag.ToString() == "4")
                    {
                        boxwasondot[i] = true;
                    }
                    else
                    {
                        boxwasondot[i] = false;
                    }

                    boxes[i] = boxNewPosition;
                }
            }
        }


        public void moveplayer(int xOffset, int yOffset , PictureBox[,] arr) {
            player.Y += yOffset;
            player.X += xOffset;

            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i] == player)
                {
                    Point boxNewPosition = new Point(boxes[i].X + xOffset, boxes[i].Y + yOffset);

                    if (arr[boxNewPosition.X, boxNewPosition.Y].Tag.ToString() == "3") 
                    {
                        boxwasondot[i] = true;
                    }
                    else
                    {
                        boxwasondot[i] = false;
                    }

                    boxes[i] = boxNewPosition;
                }
            }
        }

        public void MovePlayerLeft(PictureBox[,] arr)
        {
            moveplayer(0, -1, arr);
        }

        public void MovePlayerRight(PictureBox[,] arr)
        {
            moveplayer(0, 1, arr);
        }

        public void MovePlayerUp(PictureBox[,] arr)
        {
            moveplayer(-1, 0, arr);
        }

        public void MovePlayerDown(PictureBox[,] arr)
        {
            moveplayer(1, 0, arr);
        }







        public Point getplayer() { return player; }
        public List<Point> getboxes() { return boxes; }
        public bool getplayerwasondot() {  return playerwasondot; }

        public List<bool> getboxwasondot() { return boxwasondot; }

    }
}
