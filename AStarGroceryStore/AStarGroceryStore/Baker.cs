using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class Baker : Department
    {       
        public Baker()
        {
            ShopItems = new MyList<ShopItem>();
            shopArray = new string[3] { "Bread", "Cake", "Cookie" };

            for (int i = 0; i < shopArray.Length; i++)
            {
                ShopItem item = new ShopItem(shopArray[i]);
                ShopItems.Add(item);
            }
        }

    }
}
