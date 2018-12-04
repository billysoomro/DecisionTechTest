using System.Text.RegularExpressions;
using DecisionTech.ShoppingCart.Interfaces;

namespace DecisionTech.ShoppingCart.Domain
{
    public class Butter : IButter
    {
        private decimal Price => 0.80M;
        public int Count { get; set; }

        public decimal AddButter(string basket, decimal subtotal)
        {
            foreach (Match a in Regex.Matches(basket, "Butter", RegexOptions.IgnoreCase))
            {
                subtotal += Price;
                Count++;
            }

            return subtotal;
        }
    }
}
