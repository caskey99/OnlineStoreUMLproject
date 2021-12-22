using System;
using System.Collections.Generic;
using System.Text;
using OnlineStoreUMLproject.Users;

namespace OnlineStoreUMLproject.Orders
{
    class Payment
    {
        public int ID;
        private static int NextID = 1;
        public float totalPrice;
        public User user;

        public Payment(User us, float Price)
        {
            ID = NextID;
            NextID++;
            user = us;
            totalPrice = Price;
        }
    }
}
