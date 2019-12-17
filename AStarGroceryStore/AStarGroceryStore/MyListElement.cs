using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class MyListElement<T>
    {
        private T val;
        public T Value { get => val; set => val = value; }

        private T previous;
        public T Previous { get => previous; set => previous = value; }

        private T next;
        public T Next { get => next; set => next = value; }


        public MyListElement(T value)
        {
            this.Value = value;
        }
    }
}
