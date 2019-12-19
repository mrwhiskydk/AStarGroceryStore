using Microsoft.Xna.Framework;
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

        public Shopper()
        {
            myShoppingList = new ShoppingList();
            
            foreach(string item in myShoppingList.MyItems)
            {
                Console.WriteLine(item);
            }
            
            goal = FindGoal();
        }

        private PathNode FindGoal()
        {
            PathNode goal = new PathNode(Vector2.Zero, 0, 0, "");
            string wantedDepartment = "";
            PathNode startingNode = new PathNode(new Vector2(1152, 640), 0, 0, "start");
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

            return goal;
        }

        private void Astar()
        {
            
        }
    }
}
