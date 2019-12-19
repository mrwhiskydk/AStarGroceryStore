using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AStarGroceryStore
{
    public class Node<T>
    {

        private Vector2 position;

        T value;

        public Node<T> Previous { get; set; }
        public Vector2 Position { get => position; }

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
