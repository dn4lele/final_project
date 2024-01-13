using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Final_Work
{
    
   

    internal class ai_algorithem
    {

        class Node {
            public int x;
            public int y;
            public Node parent=null;
            public bool visited;

            public Node(int x, int y) { 
                this.x = x; this.y = y;
            }
        
        }

        private static Node[,] _nodeMap;
        private static readonly int[] row = { -1, 0, 0, 1 };
        private static readonly int[] col = { 0 ,-1, 1, 0 };

        private static void CreateNodeMap(PictureBox[,] arr) {
            _nodeMap = new Node[arr.GetLength(0), arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(1); i++) {
                for (int j = 0; j < arr.GetLength(0); j++) {
                    _nodeMap[i, j] = new Node(i, j);
                    if (arr[i,j].Tag.ToString() == "0")
                        _nodeMap[i,j].visited = true;
                }
            }


        }

        public static bool IsValid(Point p , PictureBox[,] arr) {
            return p.X > 0 && p.X < arr.GetLength(1) && p.Y > 0 && p.Y < arr.GetLength(0);
        }

        public static List<Point> findpathBFS(Point Start, Point End , PictureBox[,] arr)
        {
            CreateNodeMap(arr);

            Queue<Node> q = new Queue<Node>();
            var start1 = _nodeMap[Start.X, Start.Y];
            q.Enqueue(start1);


            while (q.Count > 0) { 
                Node curr = q.Dequeue();

                if (curr.x == End.X && curr.y == End.Y) {
                    return RetracePath(Start, End , arr);
                }

                for (int i = 0; i < row.Length; i++) { //look all the nighbors
                    int newX = curr.x + row[i];
                    int newY = curr.y + col[i];

                    if (IsValid(new Point(newX, newY), arr) && !_nodeMap[newX, newY].visited) {
                        q.Enqueue(_nodeMap[newX, newY]);
                        _nodeMap[newX, newY].visited = true;
                        _nodeMap[newX, newY].parent = curr;

                    }

                }

            }
            return null;
        }

        private static List<Point> RetracePath(Point start, Point goal, PictureBox[,] arr) { 
            Stack<Point> stack = new Stack<Point>();
            List<Point> result = new List<Point>();

            Node curr = _nodeMap[goal.X, goal.Y];

            while (curr!=null && !(curr.x == start.X && curr.y == start.Y)) {
                //arr[curr.x, curr.y].Image = Image.FromFile("./PNG/Ground_Grass.png");
                stack.Push(new Point(curr.x, curr.y));
                curr = curr.parent;
            }

            while(stack.Count>0) result.Add(stack.Pop());
            return result;
        }


        public static List<Tuple<Point, int>> EvaluateTarget(PictureBox[,] arr)
        {

            List<Tuple<Point, int>> targets = new List<Tuple<Point, int>>();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j].Tag.ToString() == "3")
                    {
                        targets.Add(new Tuple<Point, int>(new Point(i, j), 0));
                    }
                }
            }

            for (int i = 0; i < targets.Count; i++)
            {
                int barrierCount = CalculateBarrierCount(targets[i].Item1, arr);
                targets[i] = new Tuple<Point, int>(targets[i].Item1, barrierCount);
            }

            return targets;

        }


        private static int CalculateBarrierCount(Point target, PictureBox[,] arr)
        {
            int x = target.X;
            int y = target.Y;

            int barrierCount = 0;

            if (IsBarrier(x - 1, y, arr)) barrierCount++;
            if (IsBarrier(x + 1, y, arr)) barrierCount++;
            if (IsBarrier(x, y - 1, arr)) barrierCount++;
            if (IsBarrier(x, y + 1, arr)) barrierCount++;

            return barrierCount;
        }
        private static bool IsBarrier(int x, int y, PictureBox[,] arr)
        {
            return x >= 0 && x < arr.GetLength(0) &&
                   y >= 0 && y < arr.GetLength(1) &&
                   (arr[x, y].Tag.ToString() == "0" || arr[x, y].Tag.ToString() == "2"); //box or wall
        }


        public static List<Tuple<Point, int>> EvaluateBox(Tuple<Point, int> target, PictureBox[,] arr)
        {
            List<Tuple<Point, int>> boxes = new List<Tuple<Point, int>>();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j].Tag.ToString() == "2")
                    {
                        boxes.Add(new Tuple<Point, int>(new Point(i, j), 0));
                    }
                }
            }

            int hitbox=0;
            for (int i = 0; i < boxes.Count; i++)
            {
                hitbox = 0;
                var path = ai_algorithem.findpathBFS(boxes[i].Item1, target.Item1, arr);
                foreach(Point p in path) {
                    if (arr[p.X , p.Y].Tag.ToString() == "2") { 
                        hitbox++; 
                    }
                }

                boxes[i] = new Tuple<Point, int>(boxes[i].Item1, hitbox);
            }

            return boxes;

        }

      

        public static bool boxMove(PictureBox[,] arr , bool plan ) {

            List<Tuple<Point, int>> boxes = null;
            List<Tuple<Point, int>> targets =null;

            if (plan) {
                targets = EvaluateTarget(arr);
                targets = targets.OrderBy(t => t.Item2).ToList();
                //clear something
                //clear something 

                for (int i = 0; i < targets.Count; i++)
                {
                    if (plan) {
                        boxes = ai_algorithem.EvaluateBox(targets[i], arr);
                        boxes = boxes.OrderBy(t => t.Item2).ToList();
                    }
                    foreach (var box in boxes)
                    {


                    }


                }



            }
            return false;

        }


    }
}

