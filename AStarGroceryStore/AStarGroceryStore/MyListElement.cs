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

        //private T previous;
        //public T Previous { get => previous; set => previous = value; }

        private MyListElement<T> next;
        public MyListElement<T> Next { get => next; set => next = value; }

        public MyListElement(T value)
        {
            this.Value = value;
        }

        public T GetValue()
        {
            if(Value == null)
            {
                Value = default(T);
            }

            return Value;
        }
    }
}
