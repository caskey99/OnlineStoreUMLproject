using System;
using System.Collections.Generic;
using System.Text;
using OnlineStoreUMLproject.Orders;
using OnlineStoreUMLproject.Users;

namespace OnlineStoreUMLproject
{
    class DataStorageSystem
    {
        public List<Order> orderList;
        public List<Cheque> chequeList;
        public List<User> userList;

        public DataStorageSystem()
        {
            orderList = new List<Order>();
            chequeList = new List<Cheque>();
            userList = new List<User>();
        }

        //ADD
        public void addUser(User user)
        {
            userList.Add(user);
        }
        public void addOrder(Order order)
        {
            orderList.Add(order);
        }
        public void addChequer(Cheque cheque)
        {
            chequeList.Add(cheque);
        }

        public void addAdministrator(Administrator admin)
        {
            userList.Add(admin);
        }

        public void addModerator(Moderator moder)
        {
            userList.Add(moder);
        }

        //GET
        public User getUserForLogin(string login)
        {
            User find = userList.Find(x => x.login == login);
            return find;
        }

        public List<Order> getOrdersForUserID(int id)
        {
            List<Order> orders = new List<Order>();
            foreach (var s in orderList)
            {
                if(s.userID == id)
                    orders.Add(s);
            }
            return orders;
        }

        //SET
        public bool setUserForLogin(User us)
        {
            var find = userList.Find(x => x.login == us.login);
            if (find != null)
            {
                int id = userList.IndexOf(find);
                userList[id] = us;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Search

        public bool loginSearch(string login)
        {
            User find = userList.Find(x => x.login == login);
            if (find != null)
                return true;
            else
                return false;
        }


        //Show
        public void showUserList()
        {
            foreach (var s in userList)
            {
                Console.WriteLine(s.getID() + ") LOG: " + s.login + "\nPASS: " + s.password + "\nCAN BAY " + s.canBuy + "\n");
            }
        }

        public void showChequeList()
        {
            foreach (var s in chequeList)
            {
                Console.WriteLine(s.ID + ") OrderID: " + s.orderID + "\nMoney: " + s.amountMoney + "\nCount things: " + s.productList.Count + "\n");
            }
        }

        public void showOrderList()
        {
            foreach (var s in orderList)
            {
                Console.WriteLine(s.ID + ") OrderID: " + s.ID + "\nUserID: " + s.userID + "\nMoney: " + s.price + "\nstatus: " + s.status+ "\nCount things: " + s.productList.Count + "\n");
            }
        }


        public void showUserInfo(User us)
        {
            var find = userList.Find(x => x == us);
            if (find != null)
            {
                Console.Clear();
                Console.WriteLine("Yout ID = " + find.getID() + "\nLogin: " + find.login + "\nMail: " + find.mail + "\nAddress: " + find.address + "\nYou have full acc: ");
            }

        }

        public void showUserOrderList(User us)
        {
            if (orderList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("У вас пока нет закзаов..\n");
                return;
            }
            foreach (var order in orderList)
            {
                if(order.userID == us.getID())
                {
                    var cheque = chequeList.Find(x => x.orderID == order.ID);
                    Console.WriteLine("Заказ: №" + cheque.ID + "");
                    Console.WriteLine("Статус заказа: " + order.status);
                    int counter = 1;
                    Console.WriteLine("Количество оплаченного товара: " + cheque.productList.Count);
                    Console.WriteLine("Список покупок: ");
                    foreach (var s in cheque.productList)
                    {
                        Console.WriteLine(counter + ")" + s.name + ". Цена: " + s.price + " Руб.");
                        counter++;
                    }
                    Console.WriteLine("ИТОГО : " + cheque.amountMoney + " Руб.\n");
                }
            }
        }

    }
}
