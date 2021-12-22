using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using OnlineStoreUMLproject.Orders;
using OnlineStoreUMLproject.Products;
using OnlineStoreUMLproject.Users;


namespace OnlineStoreUMLproject
{
    class Program
    {
        static void Main(string[] args)
        {
            System system = new System();
            DataStorageSystem data = new DataStorageSystem();
            ProductCatalog productCatalog = new ProductCatalog();
            productCatalog.addItem(new Product("MSI Pulse", 145000));
            productCatalog.addItem(new Product("Lenovo IdeaPad 3", 94000));
            productCatalog.addItem(new Product("ASUS TUF F15", 102000));
            productCatalog.addItem(new Product("Apple MacBook Air 13", 83000));
            productCatalog.addItem(new Product("MSI GeForce GTX 1050", 25000));
            productCatalog.addItem(new Product("Asus GTX1050 Ti", 27000));
            productCatalog.addItem(new Product("Palit GeForce GTX 1050", 25794));
            system.registrationAdmin("admin", "admin");
            //data.addUser(new Administrator("admin", "admin"));




            User activeUser = new User();
            string login, password, address, mail;
            int phoneNumber, cardDetails;
            
            activeUser = system.getUserForLogin("admin");

            Console.WriteLine("Добро пожаловать в онлайн магазин Caskey!");
            while (true)
            {
                Console.WriteLine("Выберете дальнейшее действие :\n");
                Console.WriteLine("1. Просмотреть каталог");
                Console.WriteLine("2. Войти в аккаунт");
                Console.WriteLine("3. Зарегистрировать новый аккаунт");
                if(activeUser != null) 
                    Console.WriteLine("4. Личный кабинет");
                if(activeUser != null) 
                    if(activeUser.GetType() == typeof(Administrator))
                        Console.WriteLine("5. Меню Админа");
                int action1 = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (action1)
                {
                    case 1:
                        system.showCatalog(productCatalog);
                        Console.WriteLine("\nВыберете дальнейшее действие :\n");
                        Console.WriteLine("1. Добавить в корзину");
                        Console.WriteLine("2. Выйти");
                        int action1_1 = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (action1_1)
                        {
                            case 1:
                                if (activeUser == null)
                                {
                                    Console.WriteLine("Вам необходимо войти в аккаунт\n");
                                    Console.WriteLine("1. Войти");
                                    Console.WriteLine("2. Зарегистрироваться");
                                    Console.WriteLine("3. Не сейчас");
                                    int choice1 = Convert.ToInt32(Console.ReadLine());
                                    switch (choice1)
                                    {
                                        case 1:
                                            if (fooLog())
                                                activeUser = data.getUserForLogin(login);
                                            break;
                                        case 2:
                                            Console.Clear();
                                            fooReg();
                                            Console.Clear();
                                            Console.WriteLine("Вы успешно зарегистрированы!\n");
                                            break;
                                        case 3:
                                            break;
                                        default:
                                            Console.WriteLine("Нет такого действия");
                                            break;
                                    }

                                }
                                else if (!activeUser.canBuy) //activeUser.address == null | activeUser.mail == null | 
                                {
                                    //AddMoreInf
                                    Console.WriteLine("Не заполнена необходимая информация для покупок\n");
                                    Console.WriteLine("1. Заполнить сейчас?");
                                    Console.WriteLine("2. Заполнить потом?");
                                    int choice11 = Convert.ToInt32(Console.ReadLine());
                                    if (choice11 == 1)
                                    {
                                        system.fooAddMoreInf(activeUser);
                                    }

                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Выберете товар:\n");
                                    system.showCatalog(productCatalog);
                                    int choice1_1 = Convert.ToInt32(Console.ReadLine());
                                    if (choice1_1 > 0 & choice1_1 < productCatalog.numProducts + 1)
                                    {
                                        List<Product> saleList = new List<Product>();
                                        saleList.Add(productCatalog.getItem(choice1_1));
                                        while (true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("1. Чтонибуть еще?");
                                            Console.WriteLine("2. На этом все");
                                            int choice1_2 = Convert.ToInt32(Console.ReadLine());
                                            if (choice1_2 == 1)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Выберете товар:");
                                                system.showCatalog(productCatalog);
                                                int choice2_1 = Convert.ToInt32(Console.ReadLine());
                                                if (choice2_1 > 0 & choice1_1 < productCatalog.numProducts)
                                                {
                                                    saleList.Add(productCatalog.getItem(choice2_1));
                                                }
                                            }
                                            else
                                                break;
                                        }
                                        Console.Clear();
                                        Console.WriteLine("1. Оплатить?");
                                        Console.WriteLine("2. Отменить заказ?");
                                        int choice1_2_1 = Convert.ToInt32(Console.ReadLine());
                                        switch (choice1_2_1)
                                        {
                                            case 1:
                                                float couter = 0;
                                                foreach (var s in saleList)
                                                    couter += s.price;
                                                Console.Clear();
                                                Console.WriteLine("1. Списать с вашей карты: " + couter + " ?");
                                                Console.WriteLine("2. Отказаться от покупки");
                                                int choice1_2_1_1 = Convert.ToInt32(Console.ReadLine());
                                                switch (choice1_2_1_1)
                                                {
                                                    case 1:
                                                        if (activeUser.card.amountMoney - couter >=0)
                                                        {
                                                            activeUser.card.amountMoney -= couter;
                                                            Cheque cheque = system.toPay(activeUser, saleList);
                                                            Console.Clear();
                                                            system.showCheque(cheque);
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Недостаточно средств!\n");
                                                        }
                                                        break;
                                                    case 2:
                                                        Console.WriteLine("Заказ отменен!");
                                                        break;
                                                    default:
                                                        Console.WriteLine("Нет такого действия");
                                                        break;
                                                }


                                                break;
                                            case 2:
                                                Console.WriteLine("Заказ отменен!");
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Товар кончился!");
                                    }
                                            
                                }

                                break;
                            case 2:
                                break;
                            default:
                                Console.WriteLine("Нет такого действия");
                                break;
                        }

                        break;
                    case 2:
                        // log
                        if (activeUser == null)
                        {
                            Console.Write("Введите ваш логин : ");
                            login = Console.ReadLine();
                            Console.Write("Введите ваш пароль: ");
                            password = Console.ReadLine();
                            Console.Clear();
                            if (system.logInToAcc(login, password))
                            {
                                Console.Clear();
                                Console.WriteLine("Вы успешно вошли!\n");
                                activeUser = system.getUsForLogin(login);
                            }
                            else
                                Console.WriteLine("Неверный логин или пароль!");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Вы уже авторизованы!\n");
                            Console.WriteLine("1. Хотите выйти?");
                            Console.WriteLine("2. Оставить этот аккаунт");
                            int choice22 = Convert.ToInt32(Console.ReadLine());
                            if (choice22 == 1)
                            {
                                Console.Clear();
                                Console.Write("Вы вышли из аккаунта!\n");
                                activeUser = null;
                            }
                        }
                        

                        break;
                    case 3:
                        //reg
                        fooReg();
                        Console.Clear();
                        Console.WriteLine("Вы успешно зарегистрированы!\n");
                        break;

                    case 4:
                        if (activeUser != null)
                        {
                            //Personal account
                            Console.Clear();
                            Console.WriteLine("Вы вошли в свой личнй кабинет!\n");
                            Console.WriteLine("Выберете дальнейшее действие :");
                            Console.WriteLine("1. Мои заказы");
                            Console.WriteLine("2. Мои данные");
                            Console.WriteLine("3. Изменть мои данные");
                            int action4 = Convert.ToInt16(Console.ReadLine());
                            switch (action4)
                            {
                                case 1:
                                    Console.Clear();
                                    system.showUserOrdersList(activeUser);
                                    break;
                                case 2:
                                    Console.Clear();
                                    system.showUserInf(activeUser);
                                    break;
                                case 3:
                                    Console.Clear();
                                    system.fooAddMoreInf(activeUser);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                            break;
                        

                        break;
                    case 5:
                    {
                        if (activeUser != null)
                                if (activeUser.GetType() == typeof(Administrator))
                                {
                                    Console.WriteLine("Выберете дальнейшее действие :");
                                    Console.WriteLine("1. Просмотреть список Users");
                                    Console.WriteLine("2. Просмотреть список Sales");
                                    Console.WriteLine("3. Просмотреть список Products");
                                    Console.WriteLine("4. Добавить товар");
                                    Console.WriteLine("5. Убрать товар");
                                    int action5 = Convert.ToInt16(Console.ReadLine());
                                    switch (action5)
                                    {
                                        case 1:
                                            Console.Clear();
                                            system.showUsersList();
                                            break;
                                        case 2:
                                            Console.Clear();
                                            system.showOrderList();
                                            break;
                                        case 3:
                                            Console.Clear();
                                            system.showCatalog(productCatalog);
                                            break;
                                        case 4:
                                            Console.Clear();
                                            Console.WriteLine("Введите название продукта");
                                            string name = Console.ReadLine();
                                            Console.WriteLine("Введите цену продукта");
                                            float price = float.Parse(Console.ReadLine());
                                            productCatalog.addItem(new Product(name, price));
                                            Console.Clear();
                                            Console.WriteLine("Продукт успешно добавлен!\n");
                                            break;
                                        case 5:
                                            Console.WriteLine("Введите id: \n");
                                            int id = Convert.ToInt32(Console.ReadLine());
                                            productCatalog.remItem(id);
                                            break;
                                        default:
                                            break;
                                    }

                                }
                                else
                                    break;
                        break;
                    }
                    default:
                        Console.WriteLine("Нет такого действия");
                        break;

                }
                Console.WriteLine("Выберете дальнейшее действие :\n");
                Console.WriteLine("1. На главную страницу");
                Console.WriteLine("2. Выйти с сайта?");
                int actionBack = Convert.ToInt16(Console.ReadLine());
                if (actionBack == 2)
                    break;
                else if (actionBack == 1)
                    actionBack = 1;
                else if (actionBack != 1)
                {
                    Console.WriteLine("Нет такого действия");
                }
                Console.Clear();
            }




            bool fooReg()
            {
                Console.Write("Придумайте ваш логин : ");
                login = Console.ReadLine();
                Console.Write("Придумайте ваш пароль : ");
                password = Console.ReadLine();
                if (login != null & password != null)
                {
                    system.registrationUser(login, password);
                    return true;
                }
                else
                {
                    Console.Write("Поле не может быть пустым!");
                }

                return false;
            }

            bool fooLog()
            {
                Console.Write("Введите ваш логин : ");
                login = Console.ReadLine();
                Console.Write("Введите ваш пароль: ");
                password = Console.ReadLine();
                if (system.logInToAcc(login, password))
                {
                    Console.WriteLine("Вы успешно вошли!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль!");
                    return false;
                }
            }













            //Product laptopMSI = new Product("MSI Pulse", 145000);
            //Product laptopLenovo = new Product("Lenovo IdeaPad 3", 94000);
            //Product laptopAsus = new Product("ASUS TUF F15", 102000);
            //Product laptopApple = new Product("Apple MacBook Air 13", 83000);
            //Product videoСardMSI = new Product("MSI GeForce GTX 1050", 25000);
            //Product videoСardAsus = new Product("Asus GTX1050 Ti", 27000);
            //Product videoСardPalit = new Product("Palit GeForce GTX 1050", 25794);






        }
    }
}
