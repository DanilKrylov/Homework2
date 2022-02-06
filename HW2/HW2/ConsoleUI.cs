using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public static class ConsoleUI
    {
        public static void ConsoleWriteProducts()
        {
            List<Product> products = Products.GetProducts().Prod;

            Console.WriteLine("Список продуктов магазина:");
            for(int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price} грн.");
            }
        }

        public static void ConsoleWriteShopCart(ShopCart shopCart)
        {
            Dictionary<Product, int> products = shopCart.Products;

            if(products.Count == 0)
            {
                Console.WriteLine("Ваша корзина пуста");
                return;
            }

            Console.WriteLine("Ваша корзина:");
            foreach(KeyValuePair<Product, int> elem in shopCart.Products)
            {
                Console.WriteLine($"{elem.Key.Name} - {elem.Value} шт. - {elem.Key.Price * elem.Value} грн.");
            }

            Console.WriteLine($"Общая сумма: {shopCart.GetFullPrice()}");
        }

        public static void ConsoleWriteCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Чтобы добавить товар в корзину напишите / и номер товара, например '/1'.");
            Console.WriteLine("Чтобы просмотреть список продуктов напишите '/Products'");
            Console.WriteLine("Чтобы просмотреть корзину напишите '/ShopCart'");
            Console.WriteLine("Чтобы очистить корзину напишите /Clear");
            Console.WriteLine("Чтобы просмотреть ваши заказы напишите /Orders");
            Console.WriteLine("Чтобы оформить заказ напишите /AddOrder");
            Console.WriteLine();
        }

        public static void ConsoleWriteOrders(User user)
        {
            List<Order> orders = user.Orders;

            if(orders.Count == 0)
            {
                Console.WriteLine("У вас нет заказов");
            }

            Console.WriteLine("У Вас есть заказы под индексами:");

            foreach(Order order in orders)
            {
                Console.WriteLine(order.ID);
            }
        }

        public static void ConsoleWriteOrderInfo(Order order)
        {
            Console.WriteLine();
            Dictionary<Product, int> products = order.Products;

            Console.WriteLine("Ваш заказ:");
            foreach (KeyValuePair<Product, int> elem in order.Products)
            {
                Console.WriteLine($"{elem.Key.Name} - {elem.Value} шт. - {elem.Key.Price * elem.Value} грн.");
            }

            Console.WriteLine($"Общая сумма: {order.toPay} грн.");

            switch (order.isPayed)
            {
                case false:
                    Console.WriteLine("Заказ не оплачен");
                    break;
                case true:
                    Console.WriteLine("Заказ оплачен");
                    break;
            }
            Console.WriteLine();
        }
    }
}
