using System;
using System.Collections.Generic;
using System.Text;
using OnlineStoreUMLproject.Orders;

namespace OnlineStoreUMLproject.Delivery
{
    class Storekeeper
    {
        private int ID;
        private static int NextID = 1;
        public List<Order> orderList;
        public Storekeeper() {}
        public Storekeeper(List<Order> OrderList)
        {
            orderList = OrderList;
            ID = NextID;
            NextID++;
        }
    }
}
