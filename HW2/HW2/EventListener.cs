using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public static class EventListener
    {
        public static void Run(User user)
        {
            
            Console.WriteLine("Добро пожаловать в интернет магазин");

            ConsoleUI.ConsoleWriteProducts();

            UserCommandHendler(user);
        }
        private static void UserCommandHendler(User user)
        {
            ShopCart shopCart = user.UserShopCart;
            List<Product> products = Products.GetProducts().Prod;
            while (true)
            {
                ConsoleUI.ConsoleWriteCommands();

                string userCommand = Console.ReadLine().Trim();

                if (userCommand[0] != '/')
                {
                    Console.WriteLine("Неверная комманда");
                    continue;
                }
                userCommand = userCommand[1..];

                switch (userCommand.ToLower())
                {
                    case "products":
                        ConsoleUI.ConsoleWriteProducts();
                        continue;
                    case "shopcart":
                        ConsoleUI.ConsoleWriteShopCart(shopCart);
                        continue;
                    case "clear":
                        shopCart.Clear();
                        Console.WriteLine("Ваша корзина очищена");
                        continue;
                    case "orders":
                        ConsoleUI.ConsoleWriteOrders(user);
                        OrderChooseHandler(user);
                        continue;
                    case "addorder":
                        if(shopCart.Products.Count == 0)
                        {
                            Console.WriteLine("Ваша корзина пуста");
                            continue;
                        }
                        user.AddOrder(shopCart);
                        Console.WriteLine("Заказ успешно оформлен но не оплачен");
                        shopCart = user.UserShopCart;
                        continue;
                }

                int productID;

                if (int.TryParse(userCommand, out productID) &&
                    productID >= 1 &&
                    productID <= products.Count)
                {
                    TryAddProductToShopCart(productID, shopCart);
                    continue;
                }

                if (int.TryParse(userCommand, out productID))
                {
                    Console.WriteLine("Введен неверный номер товара");
                    continue;
                }

                Console.WriteLine("Вы ввели что-то непонятное :( ");
            }
        }

        private static void TryAddProductToShopCart(int productID, ShopCart shopCart)
        {
            Product currentProduct = Products.GetProducts().Prod[productID - 1];
            Console.WriteLine($"Вы выбрали товар - {currentProduct.Name}");

            while (true)
            {
                Console.Write("Напишите количество товара которое хотите купить или" +
                " /Back чтобы вернуться в главное меню:");

                string userCom = Console.ReadLine();

                if (userCom.ToLower() == "/back")
                {
                    return;
                }
                int count;

                if (int.TryParse(userCom, out count) && count >= 1)
                {
                    if (shopCart.TryAddProduct(currentProduct, count))
                    {
                        Console.WriteLine("Товар успешно добавлен");
                        break;
                    }

                    Console.WriteLine("К сожалению в магазине нет такого количества товара");
                    continue;
                }
                Console.WriteLine("Вы ввели что-то непонятное :( ");
            }
        }

        private static void OrderChooseHandler(User user)
        {
            while (true)
            {
                Console.WriteLine("Чтобы вернуться в главное меню введите /Main");
                Console.WriteLine("Чтобы просмотреть заказ введите его индекс:");

                string userString = Console.ReadLine();

                int orderID;
                
                if (int.TryParse(userString, out orderID) && user.GetOrderOrNull(orderID) != null)
                {
                    Order order = user.GetOrderOrNull(orderID);
                    OrderHandler(order);
                    return;
                }

                if(userString.ToLower() == "/main")
                {
                    return;
                }

                Console.WriteLine("Вы ввели неверный индекс");
            }
        }

        private static void OrderHandler(Order order)
        {
            ConsoleUI.ConsoleWriteOrderInfo(order);
            while (true)
            {
                Console.WriteLine("Чтобы вернуться в главное меню введите /Main");

                if (!order.isPayed)
                {
                    Console.WriteLine("Чтобы Оплатить заказ введите /Pay");
                }

                string userCommand = Console.ReadLine();

                if (userCommand.ToLower() == "/main")
                {
                    return;
                }
                if (userCommand.ToLower() == "/pay" && !order.isPayed)
                {
                    order.Pay();
                    Console.WriteLine("Заказа оплачен");
                    return;
                }

                Console.WriteLine("Вы ввели что-то непонятное :( ");
            }
        }
    }
}
