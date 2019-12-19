using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public abstract class Department
    {
        private MyList<ShopItem> shopItems;
        public MyList<ShopItem> ShopItems { get => shopItems; set => shopItems = value; }

        public string[] shopArray;

        protected Department()
        {
           
        }
       
    }
}
