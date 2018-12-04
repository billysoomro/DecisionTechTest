using System.Text.RegularExpressions;
using DecisionTech.ShoppingCart.Interfaces;

namespace DecisionTech.ShoppingCart.Domain
{
    public class Bread : IBread
    {
        private decimal Price => 1.00M;
        public int Count { get; set; }

        public decimal AddBread(string basket, decimal subtotal)
        {
            foreach (Match b in Regex.Matches(basket, "Bread", RegexOptions.IgnoreCase))
            {
                Count++;
                subtotal += Price;
            }

            return subtotal;
        }
    }
}
