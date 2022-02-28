using NykantMVC.Models;
using NykantMVC.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Friends
{
    public static class OrderHelpers
    {

        public static DateTime CalculateDeliveryDate(List<BagItem> bagItems)
        {
            var deliveryDate = new DateTime();
            foreach (var item in bagItems)
            {
                if (item.Product.ExpectedDelivery != new DateTime())
                {
                    if (deliveryDate != new DateTime())
                    {
                        if (DateTime.Compare(deliveryDate, item.Product.ExpectedDelivery) < 0)
                        {
                            deliveryDate = item.Product.ExpectedDelivery;
                        }
                    }
                    else
                    {
                        deliveryDate = item.Product.ExpectedDelivery;
                    }
                }
            }
            if (deliveryDate == new DateTime())
            {
                deliveryDate = DateTime.Now;
                if (DateTime.Now.Hour < 12)
                {
                    deliveryDate = deliveryDate.AddDays(1);
                    if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        deliveryDate = deliveryDate.AddDays(1);
                    }
                }
                else
                {
                    deliveryDate = deliveryDate.AddDays(2);
                    if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Monday)
                    {
                        deliveryDate = deliveryDate.AddDays(1);
                    }
                }
            }
            else
            {
                deliveryDate = deliveryDate.AddDays(2);
                if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    deliveryDate = deliveryDate.AddDays(2);
                }
                else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    deliveryDate = deliveryDate.AddDays(2);
                }
                else if (deliveryDate.DayOfWeek == DayOfWeek.Monday)
                {
                    deliveryDate = deliveryDate.AddDays(1);
                }
            }
            return deliveryDate;
        }

        public static DateTime CalculateDeliveryDate(BagItem bagItem)
        {
            var deliveryDate = new DateTime();
            if (bagItem.Product.ExpectedDelivery != new DateTime())
            {
                if (deliveryDate != new DateTime())
                {
                    if (DateTime.Compare(deliveryDate, bagItem.Product.ExpectedDelivery) < 0)
                    {
                        deliveryDate = bagItem.Product.ExpectedDelivery;
                    }
                }
                else
                {
                    deliveryDate = bagItem.Product.ExpectedDelivery;
                }
            }
            if (deliveryDate == new DateTime())
            {
                deliveryDate = DateTime.Now;
                if (DateTime.Now.Hour < 12)
                {
                    deliveryDate = deliveryDate.AddDays(1);
                    if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        deliveryDate = deliveryDate.AddDays(1);
                    }
                }
                else
                {
                    deliveryDate = deliveryDate.AddDays(2);
                    if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        deliveryDate = deliveryDate.AddDays(2);
                    }
                    else if (deliveryDate.DayOfWeek == DayOfWeek.Monday)
                    {
                        deliveryDate = deliveryDate.AddDays(1);
                    }
                }
            }
            else
            {
                deliveryDate = deliveryDate.AddDays(2);
                if (deliveryDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    deliveryDate = deliveryDate.AddDays(2);
                }
                else if (deliveryDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    deliveryDate = deliveryDate.AddDays(2);
                }
                else if (deliveryDate.DayOfWeek == DayOfWeek.Monday)
                {
                    deliveryDate = deliveryDate.AddDays(1);
                }
            }
            return deliveryDate;
        }

        public static double CalculateAmount(List<BagItem> items)
        {
            double price = 0;
            foreach (var item in items)
            {
                for (int i = 0; i < item.Quantity; i++)
                    price += item.Product.Price;
            }
            return price;
        }

        public static string DeliveryDateInfo(List<BagItem> bagItems)
        {
            foreach (var item in bagItems)
            {
                if (item.Product.ExpectedDelivery != new DateTime())
                {
                    return "En eller flere produkter i din kurv, er ikke på lager. Derfor er forventet leveringstid for ordren desværre forlænget.";
                }
            }
            return null;
        }

        public static List<OrderItem> MakeOrderItems(List<BagItem> bagItems, int orderId)
        {
            var orderItems = new List<OrderItem>();
            foreach (var item in bagItems)
            {
                orderItems.Add(new OrderItem { Quantity = item.Quantity, ProductId = item.ProductId, OrderId = orderId });
            }
            return orderItems;
        }

        public static bool IsBackOrder(List<BagItem> bagItems)
        {
            foreach (var item in bagItems)
            {
                if (item.Product.Amount <= item.Quantity)
                {
                    return true;
                }
            }
            return false;
        }

        public static string CalculateDeliveryTypeString(ShippingType type)
        {
            if (type == ShippingType.HomePallegods)
            {
                return "Til leveringsaddressen med DKI Pallegods";
            }

            return "Til leveringsaddressen med GLS";
        }

        public static ShippingType CalculateDeliveryType(List<BagItem> bagItems)
        {
            foreach (var item in bagItems)
            {
                if (item.Product.WeightInKg > 20)
                {
                    return ShippingType.HomePallegods;
                }
            }
            return ShippingType.Home;
        }

        public static Order BuildOrder(MakeOrder makeOrder, int paymentCaptureId)
        {
            var total = CalculateAmount(makeOrder.BagItems);
            var taxes = total / 5;
            var taxlessPrice = total - taxes;

            double weight = 0;
            foreach (var item in makeOrder.BagItems)
            {
                weight += item.Product.WeightInKg * item.Quantity;
            }

            var deliveryDate = CalculateDeliveryDate(makeOrder.BagItems);

            Order order = new Order
            {
                CreatedAt = DateTime.Now,
                Currency = "dkk",
                CustomerId = makeOrder.CustomerId,
                PaymentCaptureId = paymentCaptureId,
                Status = Status.Pending,
                TotalPrice = total.ToString(),
                Taxes = taxes.ToString(),
                WeightInKg = weight,
                TaxLessPrice = taxlessPrice.ToString(),
                EstimatedDelivery = deliveryDate,
                IsBackOrder = IsBackOrder(makeOrder.BagItems),
                BagItems = makeOrder.BagItems
            };

            return order;
        }

        public static List<Order> MakeOrders(Checkout checkout, int paymentCaptureId)
        {
            var orders = new List<Order>();
            var dates = new List<DateTime>();
            var makeOrders = new List<MakeOrder>();

            foreach(var item in checkout.BagItems)
            {
                if (!dates.Contains(item.Product.ExpectedDelivery))
                {
                    dates.Add(item.Product.ExpectedDelivery);
                }
            }

            foreach(var date in dates)
            {
                var makeOrder = new MakeOrder { CustomerId = checkout.CustomerInfId, BagItems = new List<BagItem>() };
                foreach(var item in checkout.BagItems)
                {
                    if(item.Product.ExpectedDelivery == date)
                    {
                        makeOrder.BagItems.Add(item);
                    }
                }
                makeOrders.Add(makeOrder);
            }

            foreach(var makeOrder in makeOrders)
            {
                orders.Add(BuildOrder(makeOrder, paymentCaptureId));
            }

            return orders;
        }
    }
}
