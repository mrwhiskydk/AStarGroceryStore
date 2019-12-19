using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarGroceryStore
{
    public class Butcher : Department
    {
        int b = 3 + 2;
        public Butcher()
        {
            ShopItems = new MyList<ShopItem>();
            shopArray = new string[3] { "Beef", "Chicken", "Fish" };

            for (int i = 0; i < shopArray.Length; i++)
            {
                ShopItem item = new ShopItem(shopArray[i]);
                ShopItems.Add(item);
            }

            position = new Vector2(1216, 0);
            
        }
    }
}
