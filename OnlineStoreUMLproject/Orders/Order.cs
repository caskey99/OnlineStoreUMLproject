using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Schema;
using OnlineStoreUMLproject.Products;
using OnlineStoreUMLproject.Users;

namespace OnlineStoreUMLproject.Orders
{
    class Order
    {
        public int ID;
        private static int NextID = 1;
        public DateTime date;
        public int userID;
        public List<Product> productList;
        public string description;
        public float price;
        public string status;
        public Payment payment;
        public bool paid;
        public enum state
        {
            isReady,
            notReady,
            inProgress
        }
        public Order() { status = state.notReady.ToString(); paid = false; }
        public Order(int UserID, List<Product> prList)
        {
            userID = UserID;
            date = DateTime.Now;
            ID = NextID;
            NextID++;
            productList = prList;
            float counter = 0;
            foreach (var s in prList)
            {
                counter += s.price;
            }
            price = counter;
            status = state.inProgress.ToString();
        }

        public void addDescription(string Description)
        {
            description = Description;
        }

        public void addPayment(Payment paym)
        {
            payment = paym;
            paid = true;
        }

    }
}
