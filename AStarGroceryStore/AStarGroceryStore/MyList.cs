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
        MyListElement<T> last;

        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }


        public void Add(T value)
        {
            MyListElement<T> element = new MyListElement<T>(value);

            if(first != null)
            {
                MyListElement<T> tmp = last;
                last = element;
                last.Previous = tmp;
                tmp.Next = last;
            }
            else if(first == null)
            {
                first = element;
                last = element;
            }
           
            count++;
        }

        public void Remove(T value)
        {

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
