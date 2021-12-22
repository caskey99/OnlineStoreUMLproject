using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStoreUMLproject.Orders
{
    class ByCard
    {
        public int cardDetails;
        public float amountMoney;
        public ByCard()
        {
            cardDetails = -1; amountMoney = 500000; }

        public ByCard(int CardDetails)
        {
            cardDetails = CardDetails; 
        }
    }
}
