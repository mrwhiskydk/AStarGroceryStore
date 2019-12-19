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
        /// <summary>
        /// The different departments, AI will shuffle randomly, and then pick the first 2 departments
        /// </summary>
        public MyList<Department> Departments { get => departments; set => departments = value; }

        private MyStack<string> myItems;
        /// <summary>
        /// The list of Shop Item objectives, that AI will pick randomly, depending on which departments was chosen
        /// </summary>
        public MyStack<string> MyItems { get => myItems; set => myItems = value; }

        public ShoppingList()
        {
            MyList<Department> tmpDepartments = new MyList<Department>(); // local temporary list, for shuffling departments in 'ShuffleShoppingList' Method

            // all 3 departments are added to temporary list 
            tmpDepartments.Add(new Baker());
            tmpDepartments.Add(new Fruit());
            tmpDepartments.Add(new Butcher());

            ShuffleShoppingList(tmpDepartments); // we're shuffling all 3 departments randomly, and then removes the last one, so AI has 2 departments to visit
            ShuffleShoppintItems(Departments); // we're shuffling all 3 items randomly, for both (2) departments, we just shuffled in method call above
        }

        /// <summary>
        /// Loops through each of the 2 picked departments, and shuffles their shop items randomly, through array, and adds the first shop item in string array to its own MyList of strings
        /// </summary>
        /// <param name="departments">The 2 picked departments, that contains the shop items which we wish to shuffle</param>
        private void ShuffleShoppintItems(MyList<Department> departments)
        {
            MyItems = new MyStack<string>(); // new instantitated Stack, of current AI's shop item objectives

            foreach(Department dep in departments) // Looping through the 2 departments
            {
                for (int i = dep.shopArray.Length - 1; i > 0; i--) // Looping through current department's string array (the shop items), starting from top through to buttom
                {
                    Random random = new Random();
                    int rnd = random.Next(0, i); // random int chosen through remaining shop items to loop through

                    string tmp = dep.shopArray[i]; // we store current shop item

                    dep.shopArray[i] = dep.shopArray[rnd]; // current shop item is set to index, of random chosen number
                    dep.shopArray[rnd] = tmp; // we swap previous item on this index, with the new item on random index
                }

                for (int i = 0; i < 1; i++) // first shop item of array is added to MyList of current AI's shopping item
                {
                    MyItems.Push(dep.shopArray[i]);
                }
            }
        }

        /// <summary>
        /// Shuffles the 3 departements randomly, from temporary list, through array, to actual list of departments 
        /// </summary>
        /// <param name="departments">The temporary list of all 3 departments, that we wish to shuffle</param>
        private void ShuffleShoppingList(MyList<Department> departments)
        {
            Department[] tmpArray = new Department[departments.Count]; // local array of departments, with index length equal to MyList of departments (3) - used for random shuffle (code line84 - 93)

            foreach(Department dep in departments) // we loop through all the departments (3), so that we may add them to the department array
            {
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    if(tmpArray[i] == null) // if current index of array is null (empty) ...
                    {
                        tmpArray[i] = dep; // ... index value is set equal to current department
                        break; // break our of loop, to continue with next department 
                    }
                }
            }

            for (int i = tmpArray.Length - 1; i > 0; i--)
            {
                Random random = new Random();
                int rnd = random.Next(0, i); // random int chosen through remaining departments to loop through

                Department tmp = tmpArray[i];

                tmpArray[i] = tmpArray[rnd];
                tmpArray[rnd] = tmp;
            }

            //for (int i = 0; i < 2; i++)
            //{
            //    if(tmpArray[i].ToString() == "Butcher" && i == 1)
            //    {
            //        Department tmp = tmpArray[0];
            //        tmpArray[i] = tmp;
            //        tmp = tmpArray[1];
            //    }
            //}

            Departments = new MyList<Department>();

            for (int i = 0; i < 2; i++)
            {
                Departments.Add(tmpArray[i]);
            }

            bool containsButcher = false;
            int counter = 0;
            int foundAtIndex = 0;
            foreach (Department item in Departments)
            {
                if (item.ToString() == "Butcher")
                {
                    containsButcher = true;
                    foundAtIndex = counter;
                }

                if (containsButcher && foundAtIndex == 1)
                {
                    Department tmp = Departments.GetElementAt(0);
                    Departments.GetElementAt(0) = Departments.GetElementAt(1);
                    Departments.GetElementAt(1) = tmp;

                }
                counter++;
            }

            if (!containsButcher)
            {
                if (Departments.GetElementAt(0).ToString() != "Baker")
                {
                    Department tmp = Departments.GetElementAt(0);
                    Departments.GetElementAt(0) = Departments.GetElementAt(1);
                    Departments.GetElementAt(1) = tmp;
                }
            }

            // --
        

            
        }
    }
}
