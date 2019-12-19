using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class ShopItem
    {
        private string itemType;
        public string ItemType { get => itemType; set => itemType = value; }

        public ShopItem(string itemType)
        {
            this.ItemType = itemType;
        }

       
    }
}
