using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayGroung
{
    public class Items
    {
        public int id { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public string type { get; set; }

        public List<Items> GetItemList()
        {

            List<Items> listItems = new List<Items>();

            Items item1 = new Items
            {
                id = 1,
                description = "Pizza",
                price = 159,
                type = "Food"

            };
            listItems.Add(item1);

            Items item2 = new Items
            {
                id = 2,
                description = "Burger",
                price = 100,
                type = "Food"

            };
            listItems.Add(item2);

            Items item3 = new Items
            {
                id = 3,
                description = "Takoyaki",
                price = 28,
                type = "Food"

            };
            listItems.Add(item3);

            Items item4 = new Items
            {
                id = 4,
                description = "Pineapple Juice",
                price = 30,
                type = "Drinks"

            };
            listItems.Add(item4);

            Items item5 = new Items
            {
                id = 5,
                description = "Water",
                price = 20,
                type = "Drinks"

            };
            listItems.Add(item5);


            return listItems;
        }

    }
}