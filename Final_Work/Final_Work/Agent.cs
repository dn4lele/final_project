using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;


namespace Final_Work
{

    public class Target
    {
        public int barrier { get; set;  }
        public Point position { get; set; }

        public Target(int bar, Point pos)
        {
            barrier = bar;
            position = pos;
        }
        public bool lessborders(Target a, Target b)
        {
            return a.barrier > b.barrier;
        }
    }


    public class Box
    {
        public int barrier { get; set; }
        public Point position { get; set; }
        public HashSet<Point> explored { get; set; }


        public Box(int barrier, Point position, HashSet<Point> explored)
        {
            this.barrier = barrier;
            this.position = position;
            this.explored = explored;
        }
        public Box(Box other)
        {
            this.barrier = other.barrier;
            this.position = other.position;
            this.explored = new HashSet<Point>(other.explored);
        }

        public bool lessborders(Box a, Box b)
        {
            return a.barrier > b.barrier;
        }


    }

    public class State
    {
        public int action { get; set; }
        public double heuristic { get; set; }
        public Point currentPosition { get; set; }
        public Point boxWantPosition { get; set; }

        public State(){
            action = 0;
            heuristic = 0.0;
            Point temp=new Point(-1,-1);
            currentPosition = temp;
            boxWantPosition = temp;
        }

        public State(double h, Point s )
        {
            action = 0;
            heuristic = h;
            Point temp = new Point(-1, -1);
            currentPosition = s;
            boxWantPosition = temp;
        }


        public State(double h, Point s, Point b, int a = -1 ) { // -1 mean no action
            action = a;
            heuristic = h;
            currentPosition = s;
            boxWantPosition = b;
        }

        public bool lessheuristic(State a, State b)
        {
            return a.heuristic > b.heuristic;
        }

    }


    public class PriorityQueue<T>
    {
        private List<T> heap;
        private readonly Comparison<T> comparison;
        public int Count => heap.Count;


        public PriorityQueue(Comparison<T> comparison)
        {
            this.heap = new List<T>();
            this.comparison = comparison;
        }



        public void push(T item)
        {
            heap.Add(item);
            int currentIndex = heap.Count - 1;
            while (currentIndex > 0)
            {
                int parentIndex = (currentIndex - 1) / 2;
                if (comparison(heap[parentIndex], heap[currentIndex]) > 0)
                {
                    Swap(parentIndex, currentIndex);
                    currentIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }
        public T top()
        {
            if (heap.Count > 0)
            {
                return heap[0];
            }
            throw new InvalidOperationException("PriorityQueue is empty");
        }

        public T pop()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("PriorityQueue is empty");
            }
            T poppedItem = heap[0];
            int lastIndex = heap.Count - 1;
            heap[0] = heap[lastIndex];
            heap.RemoveAt(lastIndex);

            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = 2 * currentIndex + 1;
                int rightChildIndex = 2 * currentIndex + 2;

                if (leftChildIndex >= heap.Count)
                {
                    break;
                }

                int minChildIndex = leftChildIndex;
                if (rightChildIndex < heap.Count &&
                    comparison(heap[rightChildIndex], heap[leftChildIndex]) < 0)
                {
                    minChildIndex = rightChildIndex;
                }

                if (comparison(heap[currentIndex], heap[minChildIndex]) > 0)
                {
                    Swap(currentIndex, minChildIndex);
                    currentIndex = minChildIndex;
                }
                else
                {
                    break;
                }
            }

            return poppedItem;
        }

        public bool empty()
        {
            return heap.Count == 0;
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }



    }


        internal class Agent
        {

        private static readonly List<Point> possibleAction = new List<Point>{new Point(0, -1),new Point(0, 1),new Point(-1, 0),new Point(1, 0)};

        private Point mapSize;
        private Point agentPos;
        private int[,] agentView; //0 is floor  1 is player   3 is wall
        private int[,] boxView;
        private List<Point> targetList;
        private List<Point> boxList;
        private LinkedList<int> actionStack;



        public Agent(PictureBox[,] arr)
        {
            targetList =new List<Point>();
            boxList = new List<Point>();


            agentView = new int[arr.GetLength(0), arr.GetLength(1)];

            mapSize.X = arr.GetLength(0);
            mapSize.Y = arr.GetLength(1);

            for (int i = 0; i < arr.GetLength(0); i++) {
                for (int j = 0; j < arr.GetLength(1); j++) {
                    if (arr[i, j].Tag.ToString() == "5") { //get player
                        agentPos.X = i;
                        agentPos.Y = j;
                        agentView[i, j] = 1;
                    }
                    else if (arr[i, j].Tag.ToString() == "3") {//get targets
                        targetList.Add(new Point(i, j));
                        agentView[i, j] = 0;
                    }
                    else if (arr[i, j].Tag.ToString() == "2")//get boxses
                    {//get targets
                        boxList.Add(new Point(i, j));
                        agentView[i, j] = 0;
                    }
                    else if (arr[i, j].Tag.ToString() == "0") {//if it an wall
                        agentView[i, j] = 3;
                    }
                    else if (arr[i, j].Tag.ToString() == "1"){//if it an floor
                        agentView[i, j] = 0;
                    }
                    else if (arr[i, j].Tag.ToString() == "4")//if it an boxontarget
                    {
                        agentView[i, j] = 0;
                    }
                }
            }

            this.boxView = this.agentView;
        }

        public void EvaluateTargets(List<Target> aims, Dictionary<Point, Box> boxes)
        {
            foreach (var boxEntry in boxes)
            {
                Point boxPosition = boxEntry.Key;
                boxView[boxPosition.X, boxPosition.Y] = 2;
            }

            foreach (Target aim in aims)
            {
                int barrier = 0;

                foreach (Point p in possibleAction)
                {
                    int newY = aim.position.Y + p.Y;
                    int newX = aim.position.X + p.X;

                    if (newY >= 0 && newY < mapSize.Y && newX >= 0 && newX < mapSize.X && agentView[newX, newY] >= 2)
                    {
                        barrier++;
                    }
                }

                aim.barrier = barrier;
            }

            foreach (var boxEntry in boxes)
            {
                Point boxPosition = boxEntry.Key;
                boxView[boxPosition.X, boxPosition.Y] = 0;
            }
        }

        private static double manhattanDistance(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }
        private static double euclideanDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public void evaluateBox(Target aim, Dictionary<Point, Box> boxes , PictureBox[,] arr) {
            int barrier;

            foreach (var boxEntry in boxes)
            {
                Point boxPosition = boxEntry.Key;
                boxView[boxPosition.X, boxPosition.Y] = 2;
            }


            foreach (var box in boxes) {
                if (box.Value.barrier == -1) 
                    continue;


                // a* algorithem 
                PriorityQueue<State> frontier = new PriorityQueue<State>((a, b) => a.heuristic.CompareTo(b.heuristic));
                Dictionary<Point, Point> explored = new Dictionary<Point, Point>();

                State currentState = new State(manhattanDistance(box.Key , box.Key)+euclideanDistance(box.Key, aim.position), box.Key );

                explored[currentState.currentPosition] = currentState.currentPosition;//add that to explored

                frontier.push(currentState);

                while (!frontier.empty()) {
                    currentState = frontier.top();
                    frontier.pop();

                    if (currentState.currentPosition == aim.position)
                        break;

                    Point nextPosition=new Point(0,0);//initialize
                    foreach( Point act in possibleAction ) { // Get next state
                        nextPosition.X=currentState.currentPosition.X + act.X;
                        nextPosition.Y=currentState.currentPosition.Y + act.Y;

                        if ((!(explored.ContainsKey(nextPosition))) && boxView[nextPosition.X , nextPosition.Y] < 3 && boxView[currentState.currentPosition.X - act.X , currentState.currentPosition.Y - act.Y] != 3)
                        {
                            explored[nextPosition] = currentState.currentPosition;
                            State nextState = new State(manhattanDistance(box.Key, nextPosition) +euclideanDistance(nextPosition, aim.position), nextPosition );
                            frontier.push(nextState);
                        }
                    }

                }

                //RETRACE THE PATH
                Point current = currentState.currentPosition;
                Point origin = box.Key;
                barrier = 0;
                while (current != origin)
                {
                    if (boxView[current.X , current.Y] == 2)
                        barrier++;
                    current = explored[current];
                    arr[current.X, current.Y].Image = Image.FromFile("./PNG/Ground_Grass.png");

                }
                box.Value.barrier = barrier;


            }


            foreach (var boxEntry in boxes)
            {
                Point boxPosition = boxEntry.Key;
                boxView[boxPosition.X, boxPosition.Y] = 0;
            }
        }




    }
}
