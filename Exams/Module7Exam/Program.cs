using System;

namespace Module7Exam
{
    public class Program
    {
        // Абстрактный класс "Delivery"
        public abstract class Delivery
        {
            protected string address;

            public Delivery(string address)
            {
                this.address = address;
            }

            public string Address
            {
                get { return address; }
                set { address = value; }
            }
        }

        // Класс "HomeDelivery", наследник "Delivery"
        public class HomeDelivery : Delivery
        {
            public HomeDelivery(string address) : base(address) { }
        }

        // Класс "PickPointDelivery", наследник "Delivery"
        public class PickPointDelivery : Delivery
        {
            public PickPointDelivery(string address) : base(address) { }
        }

        // Класс "ShopDelivery", наследник "Delivery"
        public class ShopDelivery : Delivery
        {
            public ShopDelivery(string address) : base(address) { }
        }

        // Абстрактный класс "OrderItem"
        public abstract class OrderItem
        {
            protected string name;
            protected decimal price;

            public OrderItem(string name, decimal price)
            {
                this.name = name;
                this.price = price;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public decimal Price
            {
                get { return price; }
                set { price = value; }
            }
        }

        // Класс "PhoneOrderItem", наследник "OrderItem"
        public class PhoneOrderItem : OrderItem
        {
            public PhoneOrderItem(string name, decimal price) : base(name, price) { }
        }

        // Класс "HeadphonesOrderItem", наследник "OrderItem"
        public class HeadphonesOrderItem : OrderItem
        {
            public HeadphonesOrderItem(string name, decimal price) : base(name, price) { }
        }

        // Класс "CaseOrderItem", наследник "OrderItem"
        public class CaseOrderItem : OrderItem
        {
            public CaseOrderItem(string name, decimal price) : base(name, price) { }
        }

        // Класс "Order", параметризованный обобщенными типами "TDelivery" и "TStruct"
        public class Order<TDelivery, TStruct> where TDelivery : Delivery where TStruct : OrderItem
        {
            protected int number;
            protected string description;
            protected TDelivery delivery;
            protected TStruct[] items;

            public Order(int number, string description, TDelivery delivery, TStruct[] items)
            {
                this.number = number;
                this.description = description;
                this.delivery = delivery;
                this.items = items;
            }

            public int Number
            {
                get { return number; }
                set { number = value; }
            }

            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            public TDelivery Delivery
            {
                get { return delivery; }
                set { delivery = value; }
            }

            public TStruct[] Items
            {
                get { return items; }
                set { items = value; }
            }

            public virtual decimal GetTotalPrice()
            {
                decimal totalPrice = 0;
                foreach (TStruct item in items)
                {
                    totalPrice += item.Price;
                }
                return totalPrice;
            }
        }

        // Класс "HomeDeliveryOrder", наследник "Order<HomeDelivery, TStruct>"
        public class HomeDeliveryOrder<TStruct> : Order<HomeDelivery, TStruct> where TStruct : OrderItem
        {
            public HomeDeliveryOrder(int number, string description, HomeDelivery delivery, TStruct[] items)
            : base(number, description, delivery, items) { }
        }

        // Класс "PickPointDeliveryOrder", наследник "Order<PickPointDelivery, TStruct>"
        public class PickPointDeliveryOrder<TStruct> : Order<PickPointDelivery, TStruct> where TStruct : OrderItem
        {
            public PickPointDeliveryOrder(int number, string description, PickPointDelivery delivery, TStruct[] items)
            : base(number, description, delivery, items) { }
        }

        // Класс "ShopDeliveryOrder", наследник "Order<ShopDelivery, TStruct>"
        public class ShopDeliveryOrder<TStruct> : Order<ShopDelivery, TStruct> where TStruct : OrderItem
        {
            public ShopDeliveryOrder(int number, string description, ShopDelivery delivery, TStruct[] items)
            : base(number, description, delivery, items) { }
        }

        // Класс "OrderProcessor"
        public class OrderProcessor
        {
            public static decimal GetTotalPrice<TDelivery, TStruct>(Order<TDelivery, TStruct> order) where TDelivery : Delivery where TStruct : OrderItem
            {
                return order.GetTotalPrice();
            }
        }

        // Main Method
        static void Main(string[] args)
        {
            // Создаем заказы
            var homeDeliveryOrder = new HomeDeliveryOrder<OrderItem>(OrderNumberGenerator.GenerateNextOrderNumber(), "Заказ с доставкой на дом", new HomeDelivery("Петрова 54"), new OrderItem[] { new PhoneOrderItem("iPhone", 1000), new HeadphonesOrderItem("AirPods", 200) });
            var pickPointDeliveryOrder = new PickPointDeliveryOrder<OrderItem>(OrderNumberGenerator.GenerateNextOrderNumber(), "Заказ на пункт выдачи", new PickPointDelivery("Сиреневый бульвар 7"), new OrderItem[] { new CaseOrderItem("Чехол для Iphone", 50) });
            var shopDeliveryOrder = new ShopDeliveryOrder<OrderItem>(OrderNumberGenerator.GenerateNextOrderNumber(), "Заказ из магазина", new ShopDelivery("Перовская 66"), new OrderItem[] { new PhoneOrderItem("Samsung", 800), new HeadphonesOrderItem("Galaxy Buds", 150) });

            // Вызываем метод GetTotalPrice для каждого заказа
            Console.WriteLine("Стоимость заказа с доставкой на дом: " + OrderProcessor.GetTotalPrice(homeDeliveryOrder));
            Console.WriteLine("Стоимость заказа с доставкой на пункт выдачи: " + OrderProcessor.GetTotalPrice(pickPointDeliveryOrder));
            Console.WriteLine("Стоимость заказа с забором из магазина: " + OrderProcessor.GetTotalPrice(shopDeliveryOrder));
        }
    }
}