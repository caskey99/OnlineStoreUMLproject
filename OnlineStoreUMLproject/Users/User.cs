using System;
using System.Collections.Generic;
using System.Text;
using OnlineStoreUMLproject.Orders;

namespace OnlineStoreUMLproject.Users
{
    class User
    {
        public bool canBuy = false;
        private int ID;
        public static int NextID = 1;
        public string login;
        public string password;
        public string mail;
        public int phoneNumber;
        public string address;
        public ByCard card;


        public User(){ ID = -1; phoneNumber = -1; card = new ByCard(); }

        public User(string Login, string Password)
        {
            ID = NextID;
            NextID++;
            login = Login;
            password = Password;
            card = new ByCard();
        }

        //add more inf
        public void addMail(string Mail)
        {
            if(Mail != null) 
                mail = Mail;
            else
                throw new Exception("Mail = null");
            if (address != null & card.cardDetails != -1)
                canBuy = true;
        }

        public void addPhoneNumber(int PhoneNumber)
        {
            phoneNumber = PhoneNumber;
            if (address != null & card.cardDetails != -1)
                canBuy = true;
        }

        public void addAddress(string Address)
        {
            if (Address != null)
                address = Address;
            else
                throw new Exception("Address = null");
            if ((card.cardDetails != -1) & (phoneNumber != -1 || mail != null))
                canBuy = true;
        }
        public void addCardDetails(int CardDetails)
        {

            card.cardDetails = CardDetails;
            if ((address != null) & (phoneNumber != -1 || mail != null))
                canBuy = true;
        }

        public int getID()
        {
            return ID;
        }

        public void setID(int id)
        {
            ID = id;
        }

    }
}
