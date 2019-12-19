﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class Shopper
    {
        private static string[] closestDepartments = { "Butcher", "Baker", "Fruit" };
        private ShoppingList myShoppingList;
        PathNode goal;

        PathNode startingNode;
        PathNode currentNode;

        private MyStack<PathNode> myPath = new MyStack<PathNode>();

        private MyList<PathNode> openList = new MyList<PathNode>();
        private MyList<PathNode> closedList = new MyList<PathNode>();




        public Shopper()
        {
            myShoppingList = new ShoppingList();        
            
            goal = FindGoal();

            myPath.Push(goal);

            Astar();
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
                            foreach (PathNode node2 in openList)
                            {
                                if (node2 != node)
                                {
                                    openList.Add(node);
                                }
                            }
                            node.Parent = currentNode;
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

                closedList.Add(currentNode);
            }           
            ///// WHILE END

            /*foreach (PathNode node in Game1.allPathNodes)
            {
                openList.Add(node);
            }
            while(currentNode.Position != startingNode.Position)
            {
                Vector2 distance = Vector2.Zero;
                foreach (PathNode node in openList)
                {
                    if (node.Type != "unwalkable")
                    {
                        distance = node.Position - currentNode.Position;

                        if (distance.Length() <= 96 && distance != Vector2.Zero)
                        {
                            openList.Remove(node);  
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
                    }

                }

                lowestF.Parent = currentNode;
                Console.WriteLine(lowestF.Position.X.ToString() + "," + lowestF.Position.Y.ToString());
                currentNode = lowestF;
                closedList.Add(currentNode);
            }*/

        }

        private int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return (Math.Abs(targetX - x) + Math.Abs(targetY - y)) / 64 * 10;
        }
    }
}
