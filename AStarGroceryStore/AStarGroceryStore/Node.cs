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

        private bool walkableNode = true;

        public Vector2 Position { get => position; }
        public bool Walkable { get => walkableNode; }

        public Node(Vector2 pos, bool walkable)
        {
            position = pos;
            walkableNode = walkable;
        }
    }
}
