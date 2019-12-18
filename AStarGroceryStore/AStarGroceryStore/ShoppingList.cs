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
            MyList<Department> tmpDepartments = new MyList<Department>();

            tmpDepartments.Add(new Baker());
            tmpDepartments.Add(new Fruit());
            tmpDepartments.Add(new Butcher());

            ShuffleShoppingList(tmpDepartments); // we're shuffling all 3 departments randomly, and then removes the last one, so AI has 2 departments to visit
            ShuffleShoppintItems(Departments); // we're shuffling all 3 items randomly, for each department to visit
        }

        private void ShuffleShoppintItems(MyList<Department> departments)
        {
            
        }

        /// <summary>
        /// Shuffles the 3 departements randomly, from temporary list, through array, to actual list of departments 
        /// </summary>
        /// <param name="departments"></param>
        private void ShuffleShoppingList(MyList<Department> departments)
        {
            Department[] tmpArray = new Department[departments.Count];

            foreach(Department dep in departments)
            {
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    if(tmpArray[i] == null)
                    {
                        tmpArray[i] = dep;
                        break;
                    }
                }
            }

            for (int i = tmpArray.Length - 1; i > 0; i--)
            {
                Random random = new Random();
                int rnd = random.Next(0, i);

                Department tmp = tmpArray[i];

                tmpArray[i] = tmpArray[rnd];
                tmpArray[rnd] = tmp;
            }

            Departments = new MyList<Department>();

            for (int i = 0; i < 2; i++)
            {
                Departments.Add(tmpArray[i]);
            }
        }
    }
}
