using System.Text;
using DecisionTech.ShoppingCart.Interfaces;

namespace DecisionTech.ShoppingCart.Domain
{
    public class Shop : IShop
    {
        public string MainText()
        {
            var mainString = new StringBuilder();

            mainString.Append("Welcome to the DecisionTech Shopping Cart");
            mainString.Append("\n" + "We have the following items in stock:");
            mainString.Append("\n" + "Bread - £1.00 (per loaf)");
            mainString.Append("\n" + "Butter - 80P (per block)");
            mainString.Append("\n" + "Milk - £1.15 (per bottle)");
            mainString.Append("\n" + "-------");
            mainString.Append("\n" + "Offers:");
            mainString.Append("\n" + "Buy 2 blocks of Butter and get a loaf of Bread for half price");
            mainString.Append("\n" + "Buy 3 bottles of Milk and get a 4th free");
            mainString.Append("\n");
            mainString.Append("\n" + "Please type in your orders (case insensitive) as follows:" + "\n");
            mainString.Append("Example: bread butter butter milk" + "\n");

            return mainString.ToString();
        }
    }
}
