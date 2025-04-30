using System.Collections.Generic;

namespace IT_ATCB_Consumable_Inventory_System.Models
{
    public class ItemsListViewModel
    {
        public List<ItemViewModel> Items { get; set; }
        public List<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public string StockStatusFilter { get; set; }
        public string SearchTerm { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public string UserRole { get; set; } // "Admin", "Editor", "Viewer"
    }
}