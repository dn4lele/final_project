using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;


namespace Final_Work
{

    public class Target
    {
        public int barrier { get; set; }
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

        public static bool lessborders(Box a, Box b)
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

        public State()
        {
            action = 0;
            heuristic = 0.0;
            Point temp = new Point(0, 0);
            currentPosition = temp;
            boxWantPosition = temp;
        }

        public State(double h, Point s)
        {
            action = 0;
            heuristic = h;
            Point temp = new Point(0, 0);
            currentPosition = s;
            boxWantPosition = temp;
        }


        public State(double h, Point s, Point b, int a = -1)
        { // -1 mean no action
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

        private static readonly List<Point> possibleAction = new List<Point> { new Point(0, -1), new Point(0, 1), new Point(-1, 0), new Point(1, 0) };

        Point mapSize;
        Point agentPos;

        List<List<int>> agentView = new List<List<int>>();
        List<List<int>> boxView = new List<List<int>>();
        List<Point> targetVector = new List<Point>();
        List<Point> boxVector = new List<Point>();
        LinkedList<int> actionStack = new LinkedList<int>();

        public Agent(PictureBox[,] arr)
        {
            setConfig(arr);
        }

        public void setConfig(PictureBox[,] arr)
        {
            this.mapSize.Y = (arr.GetLength(0));
            this.mapSize.X = (arr.GetLength(1));


            for (int i = 0; i < arr.GetLength(0); i++)
            {
                List<int> col = new List<int>();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j].Tag.ToString() == "0")//wall
                    {
                        col.Add(3);
                    }
                    else if (arr[i, j].Tag.ToString() == "1")//floor
                    {
                        col.Add(0);
                    }
                    else if (arr[i, j].Tag.ToString() == "2")//box
                    {
                        boxVector.Add(new Point(j, i));
                        col.Add(0);
                    }
                    else if (arr[i, j].Tag.ToString() == "3")//target
                    {
                        targetVector.Add(new Point(j, i));
                        col.Add(0);
                    }
                    else if (arr[i, j].Tag.ToString() == "4")//box on target idk < ----- check after
                    {
                        boxVector.Add(new Point(j, i));
                        col.Add(0);
                    }
                    else if (arr[i, j].Tag.ToString() == "5")//player
                    {
                        agentPos.X = j;
                        agentPos.Y = i;
                        col.Add(1);

                    }


                }

                agentView.Add(col);
            }

            CopyListContents(agentView, boxView);

        }
        public static void CopyListContents(List<List<int>> source, List<List<int>> destination)
        {
            foreach (var sublist in source)
            {
                List<int> newSublist = new List<int>(sublist);
                destination.Add(newSublist);
            }
        }

        public int getAction()
        {
            foreach (var a in actionStack) {
                Console.Write(a);
            }
            Console.WriteLine();
            if (actionStack.Count() > 0)
            {
                int action = actionStack.First();
                actionStack.RemoveFirst();
                return action;
            }
            else
            {
                return -1;
            }
        }


        public void edgeScan()
        {
            List<Point> nextAction = new List<Point> { new Point(0, -1), new Point(1, 0), new Point(0, 1), new Point(-1, 0) };
            HashSet<Point> explored = new HashSet<Point>();
            Queue<Point> frontier = new Queue<Point>();

            foreach (Point p in targetVector)
            { // explicit annotate target
                if (boxView[p.Y][p.X] != 2 && boxView[p.Y][p.X] != 1)
                    boxView[p.Y][p.X] = 5;
                explored.Add(p); // insert targets into explored set
            }
            frontier.Enqueue(agentPos); // begin at agent position
            explored.Add(agentPos); // add begin position into frontier
            Point currentState, nextState = new Point(0, 0);
            while (frontier.Count() > 0)
            {
                currentState = frontier.First();
                frontier.Dequeue();
                foreach (Point  p in nextAction )
                {
                    nextState.X=p.X + currentState.X;
                    nextState.Y=p.Y + currentState.Y;
                    if ((boxView[nextState.Y][nextState.X] == 0 || boxView[nextState.Y][nextState.X] == 2)
                        && !explored.Contains(nextState) )
                    {
                        frontier.Enqueue(nextState);
                        explored.Add(nextState);
                    }
                }

                for (int it = 0; it < nextAction.Count(); ++it)
                {
                    if (boxView[currentState.Y + nextAction[it].Y][currentState.X + nextAction[it].X] == 3 // check L region
                    && boxView[currentState.Y + nextAction[(it + 1) % 4].Y][currentState.X + nextAction[(it + 1) % 4].X] == 3)
                    {
                        if (boxView[currentState.Y][currentState.X] == 0 || boxView[currentState.Y][currentState.X] == 1)
                        {
                            boxView[currentState.Y][currentState.X] = 8;
                            break;
                        }
                        else if (boxView[currentState.Y][currentState.X] == 2)
                        {
                            Console.WriteLine("The game has no solutions");
                            break;
                        }
                    }
                }

                for (int it = 0; it != nextAction.Count(); ++it)
                {
                    if (boxView[currentState.Y + nextAction[it].Y][currentState.X + nextAction[it].X] == 3)
                    { // Only one side has wall
                        Point w_side= new Point(nextAction[it].X, nextAction[it].Y); // wall side
                        Point a_side=new Point(nextAction[(it + 1) % 4].X, nextAction[(it + 1) % 4].Y); // forward side
                        Point b_side=new Point(nextAction[(it + 3) % 4].X, nextAction[(it + 3) % 4].Y); // backward side

                        bool has_open = false;
                        int x = currentState.X, y = currentState.Y;
                        while (boxView[y][x] != 3 && !has_open)
                        {
                            if (boxView[y + w_side.Y][x + w_side.X] == 0 || boxView[y + a_side.Y][x + a_side.X] == 5 || boxView[y + w_side.Y][x + w_side.X] == 8 || boxView[y + w_side.Y][x + w_side.X] == 2)
                            {
                                has_open = true;
                                break;
                            }
                            x += a_side.X;
                            y += a_side.Y;
                        }

                        x = currentState.X; y = currentState.Y;
                        while (boxView[y][x] != 3 && !has_open)
                        {
                            if (boxView[y + w_side.Y][x + w_side.X] == 0 || boxView[y + b_side.Y][x + b_side.X] == 5 || boxView[y + w_side.Y][x + w_side.X] == 8 || boxView[y + w_side.Y][x + w_side.X] == 2)
                            {
                                has_open = true;
                                break;
                            }
                            x += b_side.X;
                            y += b_side.Y;
                        }
                        if (!has_open)
                            boxView[currentState.Y][currentState.X] = 8;
                    }
                }
            }


            foreach (Point p in targetVector ) {
                if (boxView[p.Y][p.X] == 5)
                    boxView[p.Y][p.X] = 0;
            }


        }


        public bool planAction() {
            edgeScan();
            List<Target> aims = new List<Target>();
            Dictionary<Point, Box> cargos = new Dictionary<Point, Box>();
            while (actionStack.Count > 0)
            {
                actionStack.Remove(actionStack.Count - 1);
            }
            for (int i = 0; i < targetVector.Count; i++)
            {
                Target temp = new Target(0, targetVector[i]);
                aims.Add(temp);
            }
            for (int i = 0; i < boxVector.Count; i++)
            {
                HashSet<Point> new_explored = new HashSet<Point>();
                Box temp = new Box(0, boxVector[i], new_explored);
                cargos[temp.position] = temp;
            }

            evaluateTarget(aims, cargos);
            evaluateBox(aims[0], cargos);


            HashSet<Point> second=new HashSet<Point>();
            State first=new State();
            bool has_sol = boxTurn(aims, cargos, agentPos, true, first, second);
            return has_sol;

        }

        void showMaze(List<List<int>> View)
        {
            foreach (Point p in targetVector)
            {
                if (View[p.Y][p.X] != 2 && View[p.Y][p.X] != 1)
                    View[p.Y][p.X] = 5;
            }
            foreach (List<int> temp in View)
            {
                foreach (int number in temp)
                {
                    switch (number)
                    {
                        case 0:
                            Console.Write("  ");
                            break;
                        case 4:
                            Console.Write(" .");
                            break;
                        case 1:
                            Console.Write(" !");
                            break;
                        case 2:
                            Console.Write(" ^");
                            break;
                        case 3:
                            Console.Write(" #");
                            break;
                        case 5:
                            Console.Write(" @");
                            break;
                        case 8:
                            Console.Write(" X");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
            foreach (Point p in targetVector)
            {
                if (View[p.Y][p.X] == 5)
                    View[p.Y][p.X] = 0;
            }
        }

        public bool boxTurn(List<Target> caims, Dictionary<Point, Box> cboxes, Point cagentPos, bool plan, State agentWantState, HashSet<Point> CagentExplored)
        {

            List<Target> aims = new List<Target>(caims);

            Dictionary<Point, Box> boxes = new Dictionary<Point, Box>(); ;
            foreach (var boxEntry in cboxes)
            {
                boxes.Add(new Point(boxEntry.Key.X, boxEntry.Key.Y), new Box(boxEntry.Value));
            }

            Point agentPos = new Point(cagentPos.X, cagentPos.Y);
            HashSet<Point> agentExplored = new HashSet<Point>(CagentExplored);

            /*
            Console.WriteLine("************Box Turn**************");
            agentView[agentPos.Y][ agentPos.X] = 1;
            foreach (Target t in aims)
            {
                agentView[t.position.Y][ t.position.X] = 5;
            }
            foreach (var boxEntry in boxes)
            {
                Point boxPosition = boxEntry.Key;
                agentView[boxPosition.Y][ boxPosition.X] = 2;
            }

            showMaze(agentView);
            //need to show the maze

            agentView[agentPos.Y][ agentPos.X] = 0;
            foreach (Target t in aims)
            {
                agentView[t.position.Y][ t.position.X] = 0;
            }
            foreach (var boxEntry in boxes)
            {
                Point boxPosition = boxEntry.Key;
                agentView[boxPosition.Y][ boxPosition.X] = 0;
            }

            Console.WriteLine("TARGET:");

            foreach (Target t in aims)
            {
                Console.WriteLine($"Priority: {t.barrier} Position: ( {t.position.X} , {t.position.Y} )");
            }

            Console.WriteLine("BOXES:");

            foreach (var kvp in boxes)
            {
                Console.WriteLine($"Priority: {kvp.Value.barrier} Position: ( {kvp.Key.X} , {kvp.Key.Y} )");
            }
            */

            if (plan)
            {
                if (aims.Count() == 0) // find the solution
                    return true;
                evaluateTarget(aims, boxes);
                aims = aims.OrderByDescending(target => target.barrier).ToList();
                agentExplored.Clear();
            }
            for(int i2 = 0; i2 <aims.Count(); i2++) { 
                if (plan)
                    evaluateBox(aims[i2], boxes);
                List<Box> boxList = new List<Box>();
                foreach (var boxEntry in boxes)
                {
                    if (boxEntry.Value.barrier > -1)
                    {
                        boxList.Add(boxEntry.Value);
                    }
                }
                boxList = boxList.OrderByDescending(tbox => tbox.barrier).ToList();
                for (int i = 0; i < boxList.Count(); i++)
                {
                    // aging
                    for (int j = 0; j < i; j++)
                    {
                        boxes[boxList[j].position].barrier = boxList[i].barrier + 1;
                    }

                    List<State> nextState = new List<State>();
                    Point nextPosition = new Point(0, 0);
                    Point actionPosition = new Point(0, 0);
                    boxes[boxList[i].position].explored.Add(boxList[i].position);
                    for (int j = 0; j < possibleAction.Count(); j++)
                    {
                        nextPosition.X = boxList[i].position.X + possibleAction[j].X;
                        nextPosition.Y = boxList[i].position.Y + possibleAction[j].Y;

                        actionPosition.X = boxList[i].position.X - possibleAction[j].X;
                        actionPosition.Y = boxList[i].position.Y - possibleAction[j].Y;

                        if (boxView[nextPosition.Y][nextPosition.X] < 2 &&
                            agentView[actionPosition.Y][actionPosition.X] < 2 &&
                             !boxes.ContainsKey(actionPosition) &&
                             !boxes[boxList[i].position].explored.Contains(nextPosition) &&
                             !boxes.ContainsKey(nextPosition))
                        {
                            State temp = new State(manhattanDistance(nextPosition, aims[i2].position), boxList[i].position, aims[i2].position, j);
                            nextState.Add(temp);
                        }
                    }
                    nextState = nextState.OrderBy(tstate => tstate.heuristic).ToList();

                    foreach (State s in nextState)
                    {
                        Point nextPosition1 = new Point(possibleAction[s.action].X + s.currentPosition.X, possibleAction[s.action].Y + s.currentPosition.Y);

                        boxes[boxList[i].position].explored.Add(nextPosition1);
                        if (agentTurn(aims, boxes, agentPos, s, agentExplored))
                        {
                            return true;
                        }
                        else
                        {
                            boxes[boxList[i].position].explored.Remove(nextPosition1);
                        }
                    }
                }
            }
            return false;

        }

        public bool agentTurn( List<Target> caims, Dictionary<Point, Box> cboxes, Point cagentPos, State agentWantState, HashSet<Point> CagentExplored)
        {
            List<Target> aims = new List<Target>(caims);
            Dictionary<Point, Box> boxes = new Dictionary<Point, Box>(); ;
            foreach(var boxEntry in cboxes) {
                boxes.Add(new Point(boxEntry.Key.X , boxEntry.Key.Y), new Box(boxEntry.Value));
            }
            Point agentPos = new Point(cagentPos.X,cagentPos.Y);
            HashSet<Point> agentExplored = new HashSet<Point>(CagentExplored);

            /*
            Console.WriteLine("************agent Turn**************");
            agentView[agentPos.Y][agentPos.X] = 1;
            foreach (Target t in aims)
            {
                agentView[t.position.Y][t.position.X] = 5;
            }
            foreach (var boxEntry in boxes)
            {
                Point boxPosition = boxEntry.Key;
                agentView[boxPosition.Y][boxPosition.X] = 2;
            }

            showMaze(agentView);

            //need to show the maze

            agentView[agentPos.Y][agentPos.X] = 0;
            foreach (Target t in aims)
            {
                agentView[t.position.Y][t.position.X] = 0;
            }
            foreach (var boxEntry in boxes)
            {
                Point boxPosition = boxEntry.Key;
                agentView[boxPosition.Y][boxPosition.X] = 0;
            }

            Console.WriteLine("TARGET:");

            foreach (Target t in aims)
            {
                Console.WriteLine($"Priority: {t.barrier} Position: ( {t.position.X} , {t.position.Y} )");
            }

            Console.WriteLine("WANTED STATE:");
            Console.WriteLine($"Wanted Action: {agentWantState.action} Heuristic: {agentWantState.heuristic}");
            Console.WriteLine($"boxCurrentPosition: ( {agentWantState.currentPosition.X} , {agentWantState.currentPosition.Y} )");
            Console.WriteLine($"boxWantPosition: ( {agentWantState.boxWantPosition.X} , {agentWantState.boxWantPosition.Y} )");
            Console.WriteLine($"agentWantPosition: ( {agentWantState.currentPosition.X - possibleAction[agentWantState.action].X} , {agentWantState.currentPosition.Y - possibleAction[agentWantState.action].Y} )");
            Console.WriteLine($"AGENTPOS: ( {agentPos.X} , {agentPos.Y} )");
            foreach (int item in actionStack)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            */
            Point dst = new Point(agentWantState.currentPosition.X - possibleAction[agentWantState.action].X, agentWantState.currentPosition.Y - possibleAction[agentWantState.action].Y);

            if (dst == agentPos)
            {
                actionStack.AddLast(agentWantState.action);
                agentPos.X = agentPos.X + possibleAction[agentWantState.action].X;
                agentPos.Y = agentPos.Y + possibleAction[agentWantState.action].Y;
                Box temp = boxes[agentWantState.currentPosition];
                boxes.Remove(agentWantState.currentPosition);
                dst.X = agentWantState.currentPosition.X + possibleAction[agentWantState.action].X;
                dst.Y = agentWantState.currentPosition.Y + possibleAction[agentWantState.action].Y;
                agentWantState.currentPosition = dst;
                temp.position = dst;
                boxes[dst] = temp;
                agentExplored.Clear();
                bool match_target = false;
                if (boxes.ContainsKey(agentWantState.boxWantPosition))
                {
                    foreach (Target a in aims)
                    {
                        if (a.position == agentWantState.boxWantPosition)
                        {
                            boxes[agentWantState.boxWantPosition].barrier = -1; // -1 means that the box doesn't need plan
                            aims.Remove(a);
                            match_target = true;
                            break;
                        }
                    }
                }

                if ((match_target ? boxTurn(aims, boxes, agentPos, true, agentWantState, agentExplored) : boxTurn(aims, boxes, agentPos, false, agentWantState, agentExplored)))
                {
                    return true;
                }
                else
                {
                    actionStack.RemoveLast();
                    return false;
                }
            }
            else
            {
                agentExplored.Add(agentPos);
                List<State> nextState = new List<State>();
                for (int i = 0; i < possibleAction.Count(); i++)
                {
                    Point temp = new Point(agentPos.X + possibleAction[i].X, agentPos.Y + possibleAction[i].Y);
                    if (!boxes.ContainsKey(temp) &&
                        agentView[agentPos.Y + possibleAction[i].Y][agentPos.X + possibleAction[i].X] < 2 &&
                        !agentExplored.Contains(temp))
                    {
                        State newState = new State(manhattanDistance(temp, dst), temp, agentWantState.boxWantPosition, i);
                        nextState.Add(newState);
                    }
                }

                if (nextState.Count() == 0)
                {
                    return false;
                }
                else
                {
                    nextState = nextState.OrderBy(tstate => tstate.heuristic).ToList();
                    foreach (State s in nextState)
                    {
                        actionStack.AddLast(s.action);
                        if (agentTurn(aims, boxes, s.currentPosition, agentWantState, agentExplored))
                        {
                            return true;
                        }
                        else
                        {
                            actionStack.RemoveLast();
                        }
                    }
                    return false;
                }
            }

        }



        public float manhattanDistance(Point src, Point dst)
        {
            return Math.Abs(dst.X - src.X) + Math.Abs(dst.Y - src.Y);
        }

        public float euclideanDistance(Point src, Point dst)
        {
            float x_distance = dst.X - src.X;
            float y_distance = dst.Y - src.Y;
            return (float)Math.Sqrt(x_distance * x_distance + y_distance * y_distance);
        }
        

        void evaluateBox(Target aim, Dictionary<Point, Box> boxes)
        {
            int barrier;
            foreach (KeyValuePair<Point, Box> pair in boxes)
            {
                boxView[pair.Key.Y][pair.Key.X] = 2;
            }
            foreach (KeyValuePair<Point, Box> pair in boxes)
            {
                if (pair.Value.barrier == -1)
                    continue;
                PriorityQueue<State> frontier = new PriorityQueue<State>((a, b) => b.heuristic.CompareTo(a.heuristic));
                Dictionary<Point, Point> explored = new Dictionary<Point, Point>();
                State currentState = new State(manhattanDistance(pair.Key, pair.Key) + euclideanDistance(pair.Key, aim.position), pair.Key);
                explored[currentState.currentPosition] = currentState.currentPosition;
                frontier.push(currentState);
                while (frontier.Count > 0)
                {
                    currentState = frontier.pop();
                    if (currentState.currentPosition == aim.position)
                        break;
                    Point nextPosition=new Point();
                    foreach (Point act in possibleAction)
                    {
                        nextPosition.X = currentState.currentPosition.X + act.X;
                        nextPosition.Y = currentState.currentPosition.Y + act.Y;
                        if (!explored.ContainsKey(nextPosition) &&
                            boxView[nextPosition.Y][nextPosition.X] < 3 &&
                            boxView[currentState.currentPosition.Y - act.Y][currentState.currentPosition.X - act.X] != 3)
                        {
                            explored[nextPosition] = currentState.currentPosition;
                            State nextState = new State(manhattanDistance(pair.Key, nextPosition) + euclideanDistance(nextPosition, aim.position), nextPosition);
                            frontier.push(nextState);
                        }
                    }
                }
                Point current = currentState.currentPosition;
                Point origin = pair.Key;
                barrier = 0;
                while (current != origin)
                {
                    if (boxView[current.Y][current.X] == 2)
                        barrier++;
                    current = explored[current];
                }
                pair.Value.barrier = barrier;
            }
            foreach (KeyValuePair<Point, Box> pair in boxes)
            {
                boxView[pair.Key.Y][pair.Key.X] = 0;
            }
        }


        void evaluateTarget(List<Target> aims, Dictionary<Point, Box> boxes)
        {
            int barrier;
            foreach (KeyValuePair<Point, Box> pair in boxes)
            {
                boxView[pair.Key.Y][pair.Key.X] = 2;
            }
            for (int i = 0; i < aims.Count; i++)
            {
                barrier = 0;
                foreach (Point p in possibleAction)
                {
                    if (agentView[aims[i].position.Y + p.Y][aims[i].position.X + p.X] >= 2)
                    {
                        barrier++;
                    }
                }
                aims[i].barrier = barrier;
            }
            foreach (KeyValuePair<Point, Box> pair in boxes)
            {
                boxView[pair.Key.Y][pair.Key.X] = 0;
            }
        }

















    }

}
