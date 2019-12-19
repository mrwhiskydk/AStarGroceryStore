using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class PathNode
    {
        private int Gpoint;
        private int Hpoint;
        private int Fpoint;

        private Vector2 position;
        public int Gpoint1 { get => Gpoint; set => Gpoint = value; }
        public int Hpoint1 { get => Hpoint; set => Hpoint = value; }
        public int Fpoint1 { get => Fpoint; set => Fpoint = value; }
        public Vector2 Position { get => position;}

        public PathNode(Vector2 pos, int G, int H)
        {
            position = pos;
            Gpoint = G;
            Hpoint = H;
            Fpoint = G + H;
        }

    }
}
