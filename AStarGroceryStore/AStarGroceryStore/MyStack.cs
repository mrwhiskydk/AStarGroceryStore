using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    class MyStack<T> : IEnumerable<T>
    {
        Node<T> last;

        private int count = 0;
        public int Count 
        {
            get
            { 
                return count; 
            }
        }

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value);

            if (last != null)
            {
                node.Previous = last;
            }
            
            last = node;
            count++;
        }

        public T Pop()
        {
            if (last == null)
            {
                throw new InvalidOperationException();
            }
            Node<T> tmp = last;
            last = last.Previous;
            count--;
            return tmp.GetValue();
        }

        public T Peek()
        {
            return last.GetValue();
        }

        public IEnumerator GetEnumerator()
        {
            Node<T> current = last;

            while (current != null)
            {
                yield return current.GetValue();
                current = current.Previous;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
