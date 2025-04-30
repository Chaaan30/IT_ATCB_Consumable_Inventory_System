using System;

namespace IT_ATCB_Consumable_Inventory_System.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string CategoryName { get; set; }
        public int CurrentQuantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public int CriticalLevel { get; set; }
        public string StockStatus { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}