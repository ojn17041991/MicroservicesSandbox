namespace BasketService.Model
{
    /* This doesn't need to match the Item definition in the Item Service exactly.
     * It just needs to be able to extract the information it needs. */

    public class Item
    {
        public int Id { get; set; } = default(int);
    }
}
