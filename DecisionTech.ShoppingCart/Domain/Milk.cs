using System.Text.RegularExpressions;
using DecisionTech.ShoppingCart.Interfaces;

namespace DecisionTech.ShoppingCart.Domain
{
    public class Milk : IMilk
    {
        private decimal Price => 1.15M;
        public int Count { get; set; }

        public decimal AddMilk(string basket, decimal subtotal)
        {
            foreach (Match m in Regex.Matches(basket, "Milk", RegexOptions.IgnoreCase))
            {
                Count++;
                subtotal += Price;
            }

            return subtotal;
        }
    }
}
