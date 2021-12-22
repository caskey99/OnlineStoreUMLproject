using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStoreUMLproject.Products
{
    class Product
    {
        public int ID;
        private static int NextID = 1;
        public string name;
        public string description;
        public float price;

        public Product() { ID = -1; name = "noname"; price = 0; }
        public Product(string Name, float Price)
        {
            ID = NextID;
            NextID++;
            name = Name;
            price = Price;
        }

        public Product(string Name, string Description)
        {
            ID = NextID;
            NextID++;
            name = Name;
            description = Description;
        }

        public void addDescription(string Description)
        {
            description = Description;
        }
    }
}
