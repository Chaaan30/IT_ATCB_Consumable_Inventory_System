using System;
using System.Collections.Generic;

namespace IT_ATCB_Consumable_Inventory_System.Models
{
    public class DashboardViewModel
    {
        public string UserName { get; set; }
        public List<DashboardSummaryCard> SummaryCards { get; set; }
        public string[] CategoryStockLabels { get; set; }
        public int[] CategoryStockValues { get; set; }
        public string[] TopItemsLabels { get; set; }
        public int[] TopItemsValues { get; set; }
        public List<DashboardRecentActivity> RecentActivities { get; set; }
        public string FlashMessage { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class DashboardSummaryCard
    {
        public string Title { get; set; }
        public int Value { get; set; }
    }

    public class DashboardRecentActivity
    {
        public DateTime Date { get; set; }
        public string ItemName { get; set; }
        public string Action { get; set; }
        public int Quantity { get; set; }
        public string User { get; set; }
    }
}