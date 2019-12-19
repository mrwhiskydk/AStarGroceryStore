using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class Fruit : Department
    {
        public Fruit()
        {
            ShopItems = new MyList<ShopItem>();
            shopArray = new string[3] { "Apple", "Banana", "Orange" };

            for (int i = 0; i < shopArray.Length; i++)
            {
                ShopItem item = new ShopItem(shopArray[i]);
                ShopItems.Add(item);
            }
        }

        public override void ShuffleItems()
        {
            throw new NotImplementedException();
        }
    }
}
