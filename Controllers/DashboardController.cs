using Microsoft.AspNetCore.Mvc;
using IT_ATCB_Consumable_Inventory_System.Models;
using System.Collections.Generic;
using System;

namespace IT_ATCB_Consumable_Inventory_System.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Dummy data for initial transition (replace with real data layer later)
            var model = new DashboardViewModel
            {
                UserName = "Chaaan30",
                SummaryCards = new List<DashboardSummaryCard>
                {
                    new DashboardSummaryCard { Title = "Total Items", Value = 123 },
                    new DashboardSummaryCard { Title = "Categories", Value = 5 },
                    new DashboardSummaryCard { Title = "Suppliers", Value = 10 }
                },
                CategoryStockLabels = new[] { "Laptops", "Monitors", "Peripherals" },
                CategoryStockValues = new[] { 20, 35, 68 },
                TopItemsLabels = new[] { "Dell XPS 13", "HP EliteBook", "Logitech Mouse", "Lenovo Dock", "Asus Monitor" },
                TopItemsValues = new[] { 18, 15, 14, 10, 9 },
                RecentActivities = new List<DashboardRecentActivity>
                {
                    new DashboardRecentActivity { Date = DateTime.UtcNow.AddMinutes(-20), ItemName = "Dell XPS 13", Action = "Added Stock", Quantity = 4, User = "admin" },
                    new DashboardRecentActivity { Date = DateTime.UtcNow.AddHours(-1), ItemName = "Logitech Mouse", Action = "Removed Stock", Quantity = -2, User = "editor" }
                },
                FlashMessage = TempData["FlashMessage"] as string,
                ErrorMessage = TempData["ErrorMessage"] as string
            };

            return View(model);
        }
    }
}