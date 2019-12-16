using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class MyList<T> : IEnumerable
    {
        private T first;
        /// <summary>
        /// Proberty that gets and sets the first value type, in current list
        /// </summary>
        private T First { get => first; set => first = value; }

        private T last;
        /// <summary>
        /// Proberty that gets and sets the last value type, in current list
        /// </summary>
        private T Last { get => last; set => last = value; }

        private T next;
        public T Next { get => next; set => next = value; }

        private T previous;
        public T Previous { get => previous; set => previous = value; }





        public void Add(T value)
        {
            if(first == null) // if list is empty
            {
                First = value; // First value of list is set to value type
            }
            else // if list contains at least 1 element
            {
                if(Last == null) // if list contains only 1 element
                {
                    Last = value; // Last element is set to value added to list
                    Previous = First; // previous element of last element, is set to value of first element, because list contains only 2 elements
                }
                else // if list contains at least 2 elements
                {
                    T tmp = Last; // we store the value of Last element
                    Last = value; // last element is set to value, since its the newest element added to list
                    Previous = tmp; // Previous element is set to stored value of previously last element in list
                }

            }
        }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
