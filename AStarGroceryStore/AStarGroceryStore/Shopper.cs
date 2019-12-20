using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class Shopper// : GameObject
    {
        private static string[] closestDepartments = { "Butcher", "Baker", "Fruit" };
        private ShoppingList myShoppingList;
        PathNode goal;

        PathNode startingNode;
        PathNode currentNode;

        private MyStack<PathNode> myPath = new MyStack<PathNode>();

        private MyList<PathNode> openList = new MyList<PathNode>();
        private MyList<PathNode> closedList = new MyList<PathNode>();

        public Vector2 position = new Vector2(1152, 640);

        Thread starThread;


        public Shopper(/*string spriteName*/)// : base(spriteName)
        {
            myShoppingList = new ShoppingList();        
           

            starThread = new Thread(AllTheMethods);
            starThread.IsBackground = true;
            starThread.Start();
        }

        private void AllTheMethods()
        {
            for (int i = 0; i < 3; i++)
            {
                goal = FindGoal();
                Astar();
                Walk();
            }
        }
        

        private PathNode FindGoal()
        {           
            PathNode goal = new PathNode(Vector2.Zero, 0, 0, "");
            string wantedDepartment = "";
            
            Vector2 distance = Vector2.Zero;
            float maxdistance = float.MaxValue;
            MyList<PathNode> departmentNodes = new MyList<PathNode>();

            if (myShoppingList.MyItems.Count > 0)
            {
                string item = myShoppingList.MyItems.Pop();

                if (item == "Beef" || item == "Chicken" || item == "Fish")
                {
                    wantedDepartment = "butcher";
                }
                else if (item == "Cookie" || item == "Bread" || item == "Cake")
                {
                    wantedDepartment = "baker";
                }
                else
                {
                    wantedDepartment = "fruit";
                }

                foreach (PathNode node in Game1.allPathNodes)
                {
                    if (node.Type == wantedDepartment)
                    {
                        departmentNodes.Add(node);
                    }
                }


                foreach (PathNode node in departmentNodes)
                {
                    distance = node.Position - position;
                    if (distance.Length() < maxdistance)
                    {
                        maxdistance = distance.Length();
                    }
                }

                foreach (PathNode node in departmentNodes)
                {
                    distance = node.Position - position;
                    if (distance.Length() == maxdistance)
                    {
                        goal = node;
                    }
                }
            }
            else
            {
                foreach (PathNode node in Game1.allPathNodes)
                {
                    if (node.Type == "register")
                    {
                        goal = node;
                    }
                }
            }

            Console.WriteLine(goal.Type);
            currentNode = goal;
            return goal;
        }

        private void Astar()
        {
            openList = new MyList<PathNode>();
            closedList = new MyList<PathNode>();
            openList.Add(currentNode);
            closedList.Add(currentNode);

            ///// WHILE START 
            while(currentNode.Position != position)
            {
                PathNode lowestF = new PathNode(Vector2.Zero, 0, 0, "");
                lowestF.Fpoint1 = int.MaxValue;
                Vector2 distance = Vector2.Zero;

                foreach (PathNode node in Game1.allPathNodes)
                {
                    if (node.Type != "unwalkable")
                    {
                        distance = node.Position - currentNode.Position;

                        if (distance.Length() <= 96 && distance != Vector2.Zero)
                        {
                            if(openList.Count > 0)
                            {
                                if (!openList.Contains(node))
                                {
                                    openList.Add(node);
                                }
                            }
                           
                        }
                    }
                }

                foreach (PathNode node in openList)
                {
                    distance = node.Position - currentNode.Position;

                    if (distance.Length() <= 65)
                    {
                        node.Gpoint1 = 10;
                    }
                    else
                    {
                        node.Gpoint1 = 14;
                    }

                    node.Hpoint1 = ComputeHScore((int)node.Position.X, (int)node.Position.Y, (int)position.X, (int)position.Y);

                    node.Fpoint1 = node.Gpoint1 + node.Hpoint1;

                    if (node.Fpoint1 < lowestF.Fpoint1)
                    {
                        lowestF = node;
                    }
                }

                lowestF.Parent = currentNode;
                currentNode = lowestF;

                Console.WriteLine(lowestF.Position.X.ToString() + "," + lowestF.Position.Y.ToString());
                //openList.Remove(currentNode);
                closedList.Add(currentNode);
            }
            ///// WHILE END
        }

        private int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return (Math.Abs(targetX - x) + Math.Abs(targetY - y)) / 64 * 10;
        }

        private void Walk()
        {
            while(position != goal.Position)
            {
                position = currentNode.Parent.Position;

                currentNode = currentNode.Parent;
                Thread.Sleep(500);
            }

            if (position == new Vector2(64, 640))
            {
                Game1.shoppers.Remove(this);
            }

        }
    }
}
