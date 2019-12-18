using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class ShoppingList
    {
        private MyList<Department> departments;
        public MyList<Department> Departments { get => departments; set => departments = value; }


        public ShoppingList()
        {
            Departments = new MyList<Department>();

            Departments.Add(new Baker());
            Departments.Add(new Fruit());
            Departments.Add(new Butcher());
        }
    }
}
