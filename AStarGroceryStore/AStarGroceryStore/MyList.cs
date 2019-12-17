using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class MyList<T> : IEnumerable<T>
    {
        MyListElement<T> first;

        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        //private MyListElement<T> first;
        //public MyListElement<T> First { get => first; set => first = value; }

        //private MyListElement<T> last;
        //public MyListElement<T> Last { get => last; set => last = value; }


        public void Add(T value)
        {
            MyListElement<T> element = new MyListElement<T>(value);

            if(first != null)
            {
                element.Next = first; 
            }

            first = element;
            count++;
        }

        public IEnumerator GetEnumerator()
        {
            MyListElement<T> current = first;
            
            while(current != null)
            {
                yield return current.GetValue();
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
