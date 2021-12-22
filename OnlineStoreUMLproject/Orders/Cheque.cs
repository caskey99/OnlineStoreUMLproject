using System;
using System.Collections.Generic;
using System.Text;
using OnlineStoreUMLproject.Products;

namespace OnlineStoreUMLproject.Orders
{
    class Cheque
    {
        public int ID;
        private static int NextID = 1;
        public float amountMoney;
        public int orderID;
        public List<Product> productList;
        
        public Cheque() { ID = 0; amountMoney = 0; productList = new List<Product>();}
        public Cheque(float amMoney, int orID, List<Product> prList)
        {
            ID = NextID;
            NextID++;
            amountMoney = amMoney;
            productList = prList;
            orderID = orID;
        }
        public int getID()
        {
            return ID;
        }
    }
}
