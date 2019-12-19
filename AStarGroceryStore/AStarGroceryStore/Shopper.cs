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


        public Shopper(/*string spriteName*/)// : base(spriteName)
        {
            myShoppingList = new ShoppingList();        
            
            goal = FindGoal();

            myPath.Push(goal);
            Thread t = new Thread(Astar);
            t.IsBackground = true;
            t.Start();
        }

        

        private PathNode FindGoal()
        {
            PathNode goal = new PathNode(Vector2.Zero, 0, 0, "");
            string wantedDepartment = "";
            startingNode = new PathNode(new Vector2(1152, 640), 0, 0, "start");

            Vector2 distance = Vector2.Zero;
            float maxdistance = float.MaxValue;
            MyList<PathNode> departmentNodes = new MyList<PathNode>();
            
            foreach (string item in myShoppingList.MyItems)
            {
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
            }

            foreach(PathNode node in departmentNodes)
            {
                distance = node.Position - startingNode.Position;
                if(distance.Length() < maxdistance)
                {
                    maxdistance = distance.Length();
                }
            }

            foreach (PathNode node in departmentNodes)
            {
                distance = node.Position - startingNode.Position;
                if (distance.Length() == maxdistance)
                {
                    goal = node;
                }
            }

            Console.WriteLine(goal.Type);
            currentNode = goal;
            return goal;
        }

        private void Astar()
        {
            openList.Add(currentNode);
            closedList.Add(currentNode);

            ///// WHILE START 
            while(currentNode.Position != startingNode.Position)
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
                            if (!closedList.Contains(node))
                            {
                                node.Parent = currentNode;
                            }

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

                    node.Hpoint1 = ComputeHScore((int)node.Position.X, (int)node.Position.Y, (int)startingNode.Position.X, (int)startingNode.Position.Y);

                    node.Fpoint1 = node.Gpoint1 + node.Hpoint1;

                    if (node.Fpoint1 < lowestF.Fpoint1)
                    {
                        lowestF = node;
                    }
                }

                
                currentNode = lowestF;

                Console.WriteLine(lowestF.Position.X.ToString() + "," + lowestF.Position.Y.ToString());
                //openList.Remove(currentNode);
                closedList.Add(currentNode);
            }
            ///// WHILE END

            Walk();
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
        }
    }
}
