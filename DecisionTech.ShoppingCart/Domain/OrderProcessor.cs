using System.Collections.Generic;
using System.Text;
using DecisionTech.ShoppingCart.Interfaces;

namespace DecisionTech.ShoppingCart.Domain
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IBread _bread;
        private readonly IButter _butter;
        private readonly IMilk _milk;

        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public OrderProcessor(IBread bread, IButter butter, IMilk milk)
        {
            _bread = bread;
            _butter = butter;
            _milk = milk;
        }

        public string ProcessOrders(string basket)
        {
            var sb = new StringBuilder();
            var orderDictionary = new Dictionary<string, int>();
            var discountDictionary = new Dictionary<string, decimal>();

            if (basket != null)
            {
                if (basket.Contains("Bread") || basket.Contains("BREAD") || basket.Contains("bread"))
                {
                    Subtotal = _bread.AddBread(basket, Subtotal);
                    var breadCount = _bread.Count;
                    orderDictionary.Add("Bread", breadCount);
                }

                if (basket.Contains("Butter") || basket.Contains("BUTTER") || basket.Contains("butter"))
                {
                    Subtotal = _butter.AddButter(basket, Subtotal);
                    var butterCount = _butter.Count;
                    orderDictionary.Add("Butter", butterCount);

                    if (butterCount >= 2 && orderDictionary.ContainsKey("Bread"))
                    {
                        discountDictionary.Add("Bread Discount", 0.50M);
                    }
                }

                if (basket.Contains("Milk") || basket.Contains("MILK") || basket.Contains("milk"))
                {
                    Subtotal = _milk.AddMilk(basket, Subtotal);
                    var milkCount = _milk.Count;
                    orderDictionary.Add("Milk", milkCount);

                    if (milkCount == 4)
                    {
                        discountDictionary.Add("1 free bottle of Milk", 1.15M);
                    }

                    else if (milkCount >= 6)
                    {
                        discountDictionary.Add("2 free bottles of Milk", 2.30M);
                    }
                }
            }

            sb.Append("\nYour orders:");

            foreach (var order in orderDictionary)
            {
                sb.Append($"\n{order.Key} count: {order.Value}");
            }

            sb.Append($"\nSubtotal: {Subtotal}");
            sb.Append("\n---------------------------");

            if (discountDictionary.Count == 0)
            {
                sb.Append("\nno offers applicable");
            }

            else
            {
                foreach (var item in discountDictionary)
                {
                    sb.Append($"\n{item.Key} £{item.Value} off");
                    Discount += item.Value;
                }
            }

            Total = Subtotal - Discount;
            sb.Append($"\nTotal: {Total}");

            return sb.ToString();
        }
    }
}
