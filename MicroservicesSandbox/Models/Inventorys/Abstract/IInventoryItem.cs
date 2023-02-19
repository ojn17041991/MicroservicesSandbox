namespace MicroservicesSandbox.Models.Inventorys.Abstract
{
    public interface IInventoryItem
    {
        int Id { get; set; }

        string Name { get; set; }

        int Quantity { get; set; }

        decimal WholesaleCost { get; set; }
    }
}
