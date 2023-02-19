namespace BasketService.Model
{
    public class Basket
    {
        public int Id { get; set; } = default(int);

        public IList<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
