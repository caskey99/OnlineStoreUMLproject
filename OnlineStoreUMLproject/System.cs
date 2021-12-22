using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OnlineStoreUMLproject.Orders;
using OnlineStoreUMLproject.Products;
using OnlineStoreUMLproject.Users;

namespace OnlineStoreUMLproject
{
    class System : DataStorageSystem
    {

        public void showCatalog(ProductCatalog pc)
        {
            foreach (var s in pc.productList)
            {
                Console.WriteLine(s.ID + ") " +s.name + ". Цена :" + s.price);
            }
        }

        //registration
        public bool registrationUser(string Login, string password)
        {
            User user = new User(Login, password);
            addUser(user);
            return true;
        }

        public bool registrationAdmin(string Login, string password)
        {
            Administrator admin = new Administrator(Login, password);
            addUser(admin);
            return true;
        }

        public bool fooAddMoreInf(User us)
        {
            Console.WriteLine("Введите вашу почту:");
            string Mail = Console.ReadLine();
            Console.WriteLine("Введите ваш адрес:");
            string Address = Console.ReadLine();
            Console.WriteLine("Введите реквизиты вашей карты:");
            int CardDetails = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            us.mail = Mail;
            us.address = Address;
            us.card.cardDetails = CardDetails;
            us.canBuy = true;
            return setUserForLogin(us);
        }


        public bool logInToAcc(string Login, string password)
        {
            if(getUserForLogin(Login) != null) 
                if (loginSearch(Login) & (password == getUserForLogin(Login).password))
                    return true;
                else
                    return false;
            else
                return false;
        }

        public User getUsForLogin(string Login)
        {
            return getUserForLogin(Login);
        }

        // Payment
        public Cheque toPay(User us, List<Product> saleList)
        {
            Order order = new Order(us.getID(), saleList);
            order.addPayment(new Payment(us, order.price));
            addOrder(order);
            Cheque cheque = new Cheque(order.price, order.ID, saleList);
            addChequer(cheque);
            return cheque;
        }

        public void showCheque(Cheque cheque)
        {
            Console.WriteLine("Чек об оплате заказа: №" + cheque.ID + "\n");
            int counter = 1;
            Console.WriteLine("Количество оплаченного товара: " + cheque.productList.Count);
            Console.WriteLine("Список покупок: ");
            foreach (var s in cheque.productList)
            {
                Console.WriteLine(counter+ ")" + s.name + ". Цена: " + s.price + " Руб.\n");
                counter++;
            }
            Console.WriteLine("ИТОГО : " + cheque.amountMoney + " Руб.\n");
        }
        //show 
        public void showUserOrdersList(User us)
        {
            showUserOrderList(us);
        }

        public void showUserInf(User us)
        {
            showUserInfo(us);
        }

        public void showUsersList()
        {
            showUserList();
        }

        public void showChequesList()
        {
            showChequeList();
        }
        public void showOrdersList()
        {
            showOrderList();
        }


    }
}
