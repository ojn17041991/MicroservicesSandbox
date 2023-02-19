using MicroservicesSandbox.Models.Inventorys.Abstract;

namespace MicroservicesSandbox.Models.Inventorys
{
    public class InventoryItem : IInventoryItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal WholesaleCost { get; set; }
    }
}
