using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AStarGroceryStore
{
    public class Node<T>
    {
        
        
        T value;

        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            this.value = value;
        }

        public T GetValue()
        {
            if (value == null)
            {
                value = default(T);
            }
            return value;
        }
    }
}
