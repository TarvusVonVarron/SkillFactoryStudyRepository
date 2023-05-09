using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module7Exam;

namespace Module7Exam
{
        public static class OrderNumberGenerator
        {
            private static int lastOrderNumber = 0;

            public static int GenerateNextOrderNumber()
            {
                return ++lastOrderNumber;
            }
        }

        public static class OrderExtensions
        {
            public static string GetDeliveryType<TDelivery, TStruct>(this Program.Order<TDelivery, TStruct> order) where TDelivery : Program.Delivery where TStruct : Program.OrderItem
            {
                if (order.Delivery is Program.HomeDelivery)
                {
                    return "Доставка на дом";
                }
                else if (order.Delivery is Program.PickPointDelivery)
                {
                    return "Пункт выдачи";
                }
                else if (order.Delivery is Program.ShopDelivery)
                {
                    return "Забор из ммагазина";
                }
                else
                {
                    return "Неизвестный тип доставки";
                }
            }

            // Индексатор для доступа к элементам заказа по индексу
            public static TStruct GetItem<TDelivery, TStruct>(this Program.Order<TDelivery, TStruct> order, int index) where TDelivery : Program.Delivery where TStruct : Program.OrderItem
            {
                return order.Items[index];
            }

            // Перегруженный оператор "+" для объединения заказов
            public static Program.Order<TDelivery, TStruct> Add<TDelivery, TStruct>(this Program.Order<TDelivery, TStruct> firstOrder, Program.Order<TDelivery, TStruct> secondOrder) where TDelivery : Program.Delivery where TStruct : Program.OrderItem
            {
                TStruct[] items = new TStruct[firstOrder.Items.Length + secondOrder.Items.Length];
                Array.Copy(firstOrder.Items, items, firstOrder.Items.Length);
                Array.Copy(secondOrder.Items, 0, items, firstOrder.Items.Length, secondOrder.Items.Length);

                return new Program.Order<TDelivery, TStruct>(OrderNumberGenerator.GenerateNextOrderNumber(), "Combined order", firstOrder.Delivery, items);
            }
        }
}
