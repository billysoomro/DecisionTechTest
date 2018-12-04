namespace DecisionTech.ShoppingCart.Interfaces
{
    public interface IOrderProcessor
    {
        decimal Subtotal { get; set; }
        decimal Discount { get; set; }
        decimal Total { get; set; }
        string ProcessOrders(string basket);
    }
}
