using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace AStarGroceryStore
{
    public abstract class Department
    {
        private MyList<ShopItem> shopItems;
        /// <summary>
        /// The shop items of this department
        /// </summary>
        public MyList<ShopItem> ShopItems { get => shopItems; set => shopItems = value; }
        /// <summary>
        /// Names of this departments shop items
        /// </summary>
        public string[] shopArray;

        public Vector2 position;

        protected Department()
        {
           
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }

    }
}
