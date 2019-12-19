using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class Butcher : Department
    {
        public Butcher()
        {
            ShopItems = new MyList<ShopItem>();
            shopArray = new string[3] { "Beef", "Chicken", "Fish" };

            for (int i = 0; i < shopArray.Length; i++)
            {
                ShopItem item = new ShopItem(shopArray[i]);
                ShopItems.Add(item);
            }
        }
    }
}
