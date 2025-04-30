using Microsoft.AspNetCore.Mvc;
using IT_ATCB_Consumable_Inventory_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IT_ATCB_Consumable_Inventory_System.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index(
            string category = "",
            string stockStatus = "",
            string search = "",
            int page = 1,
            string sort = "CategoryName",
            string dir = "ASC")
        {
            // Dummy data for demonstration
            var allItems = new List<ItemViewModel>
            {
                new ItemViewModel{Id=1, ModelName="Dell XPS 13", CategoryName="Laptops", CurrentQuantity=10, UnitOfMeasure="pcs", CriticalLevel=3, StockStatus="OK", LastUpdated=DateTime.UtcNow.AddDays(-1)},
                new ItemViewModel{Id=2, ModelName="HP EliteBook", CategoryName="Laptops", CurrentQuantity=2, UnitOfMeasure="pcs", CriticalLevel=3, StockStatus="Low Stock", LastUpdated=DateTime.UtcNow.AddDays(-2)},
                new ItemViewModel{Id=3, ModelName="Logitech Mouse", CategoryName="Peripherals", CurrentQuantity=0, UnitOfMeasure="pcs", CriticalLevel=5, StockStatus="Out of Stock", LastUpdated=DateTime.UtcNow.AddDays(-1)},
            };
            var categories = allItems.Select(i => i.CategoryName).Distinct().ToList();

            // Simulated filtering, sorting, and pagination
            var filtered = allItems.AsQueryable();
            if (!string.IsNullOrEmpty(category))
                filtered = filtered.Where(i => i.CategoryName == category);
            if (!string.IsNullOrEmpty(stockStatus))
                filtered = filtered.Where(i => i.StockStatus == stockStatus);
            if (!string.IsNullOrEmpty(search))
                filtered = filtered.Where(i => i.ModelName.Contains(search, StringComparison.OrdinalIgnoreCase));

            // Sorting
            filtered = sort switch
            {
                "ModelName" => dir == "DESC" ? filtered.OrderByDescending(i => i.ModelName) : filtered.OrderBy(i => i.ModelName),
                "CurrentQuantity" => dir == "DESC" ? filtered.OrderByDescending(i => i.CurrentQuantity) : filtered.OrderBy(i => i.CurrentQuantity),
                "LastUpdated" => dir == "DESC" ? filtered.OrderByDescending(i => i.LastUpdated) : filtered.OrderBy(i => i.LastUpdated),
                _ => dir == "DESC" ? filtered.OrderByDescending(i => i.CategoryName) : filtered.OrderBy(i => i.CategoryName),
            };

            // Paging
            int pageSize = 10, total = filtered.Count(), totalPages = (int)Math.Ceiling(total / (double)pageSize);
            var items = filtered.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var vm = new ItemsListViewModel
            {
                Items = items,
                Categories = categories,
                SelectedCategory = category,
                StockStatusFilter = stockStatus,
                SearchTerm = search,
                Page = page,
                TotalPages = totalPages,
                SortColumn = sort,
                SortDirection = dir,
                UserRole = "Admin" // Simulate as Admin; change as needed
            };

            return View(vm);
        }
    }
}