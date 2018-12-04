namespace DecisionTech.ShoppingCart.Interfaces
{
    public interface IBread
    {
        int Count { get; set; }
        decimal AddBread(string basket, decimal subtotal);
    }
}
