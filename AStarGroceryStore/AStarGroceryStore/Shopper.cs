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
                        goal = node;
                    }
                }

                break;
            }

            return goal;
        }

        private void Astar()
        {
            
        }
    }
}
