namespace CentralService.Models.Baskets
{
    public class BasketItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public int Quantity { get; set; }
    }
}
