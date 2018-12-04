namespace DecisionTech.ShoppingCart.Interfaces
{
    public interface IMilk
    {
        int Count { get; set; }
        decimal AddMilk(string basket, decimal subtotal);
    }
}
