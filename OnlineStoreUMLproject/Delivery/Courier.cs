using System;
using System.Collections.Generic;
using System.Text;
using OnlineStoreUMLproject.Orders;

namespace OnlineStoreUMLproject.Delivery
{
    class Courier
    {
        private int ID;
        private static int NextID = 1;
        public List<Order> orderList;

        public Courier() { orderList = new List<Order>(); }

        public Courier(List<Order> OrderList)
        {
            orderList = OrderList;
            ID = NextID;
            NextID++;
        }

        public void addItemOrder(Order order)
        {
            orderList.Add(order);
        }
    }

}
