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
        private MyListElement<T> first;
        public MyListElement<T> First { get => first; set => first = value; }

        private MyListElement<T> last;
        public MyListElement<T> Last { get => last; set => last = value; }


        public void Add(T value)
        {
            MyListElement<T> newElement = new MyListElement<T>(value);

            if(First == null)
            {
                First = newElement;
                //Last = newElement;

                First.Next = default(T);
                First.Previous = default(T);

                //Last.Next = default(T);
                //Last.Previous = default(T);
            }
            else
            {
                if(EqualityComparer<T>.Default.Equals(First.Next, default(T)))
                {
                    Last = newElement;
                    Last.Next = default(T);
                    Last.Previous = First.Value;
                    First.Next = Last.Value;
                }
                else if(EqualityComparer<T>.Default.Equals(Last.Previous, First.Value))
                {
                    MyListElement<T> tmp = Last;
                    Last = newElement;
                    Last.Next = default(T);
                    Last.Previous = tmp.Value;
                    tmp.Next = Last.Value;
                    tmp.Previous = First.Value;
                    First.Next = tmp.Value;
                }
                else
                {
                    MyListElement<T> tmp = Last;       

                    Last = newElement;
                    Last.Next = default(T);
                    Last.Previous = tmp.Value;
                    tmp.Next = Last.Value;
                    tmp.Previous = tmp.Previous;
                }

                //MyListElement<T> tmp = Last;
                //Last = newElement;
                //Last.Previous = tmp.Value;
                //tmp.Next = Last.Value;

                //if(EqualityComparer<T>.Default.Equals(Last.Previous, default(T))) // if list contains only 1 element
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            MyListElement<T> current = First;

            while(!EqualityComparer<T>.Default.Equals(current.Value, default(T)))
            {
             
                if(EqualityComparer<T>.Default.Equals(current.Value, First.Value))
                {
                    current.Value = First.Next;
                }
                else if(EqualityComparer<T>.Default.Equals(current.Value, First.Next))
                {
                    MyListElement<T> tmp = First;
                    tmp.Next = first.Next;
                    tmp.Next = tmp.Next;
                    current.Value = tmp.Next;
                }
                else
                {
                    MyListElement<T> tmp = current;
                    tmp.Next = current.Next;
                    tmp.Next = tmp.Next;
                    current.Value = tmp.Next;
                }

                yield return current.Value;

            }           
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
