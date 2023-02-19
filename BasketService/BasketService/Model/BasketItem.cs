namespace BasketService.Model
{
    public class BasketItem
    {
        public int ProductId { get; set; } = default(int);

        public string ProductName { get; set; } = string.Empty;

        public string ProductDescription { get; set; } = string.Empty;

        public int Quantity { get; set; } = default(int);
    }
}
