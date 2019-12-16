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





        public T Add(T value)
        {
            if(first == null)
            {
                First = value;
                Last = value;

                Next = default(T);
            }
            else
            {
                T tmp = Last;
                value = Last;
            }

            return value;
        }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
