﻿namespace CentralService.Models.Baskets
{
    public class Basket
    {
        public IList<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
