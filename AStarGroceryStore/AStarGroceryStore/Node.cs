using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class Node
    {
        private Vector2 position;

        public Vector2 Position { get => position; }

        public Node(Vector2 pos)
        {
            position = pos;
        }
    }
}
