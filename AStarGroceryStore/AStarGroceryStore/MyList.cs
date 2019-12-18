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
            // If the value, that we're trying to remove, doesn't exist
            if(EqualityComparer<T>.Default.Equals(value, default(T)))
            {
                throw new InvalidOperationException();
            }

            if(EqualityComparer<T>.Default.Equals(value, first.Value)) // if the value we wish to remove is the first element in list
            {
                MyListElement<T> tmp = first.Next;
                first = tmp;
                first.Previous = null;
            }
            else if(EqualityComparer<T>.Default.Equals(value, last.Value)) // if the value we wish to remove is the last element in list
            {
                MyListElement<T> tmp = last.Previous;
                last = tmp;
                last.Next = null;
            }
            else
            {
                MyListElement<T> current = first.Next;

                while(!EqualityComparer<T>.Default.Equals(value, current.GetValue()))
                {
                    current = current.Next;
                }

                MyListElement<T>[] right_left = new MyListElement<T>[2];
                right_left[0] = current.Next;
                right_left[1] = current.Previous;

                right_left[0].Previous = right_left[1];
                right_left[1].Next = right_left[0];

                current = right_left[1].Previous;
            }

            count--;
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
