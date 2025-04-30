using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ATCB_Consumable_Inventory_System.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace IT_ATCB_Consumable_Inventory_System.Controllers
{
    public class ItemsController : Controller
    {
        private readonly InventoryContext _context;

        public ItemsController(InventoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string category = "",
            string stockStatus = "",
            string search = "",
            int page = 1,
            string sort = "CategoryName",
            string dir = "ASC")
        {
            var allItemsQuery = _context.Items
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .AsQueryable();

            // Add your filtering here as needed (category, stockStatus, search, etc.)

            int pageSize = 10;
            int total = await allItemsQuery.CountAsync();
            int totalPages = (int)Math.Ceiling(total / (double)pageSize);
            var items = await allItemsQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var categories = await _context.Categories.Select(c => c.Name).ToListAsync();

            var vm = new ItemsListViewModel
            {
                Items = items.Select(i => new ItemViewModel
                {
                    Id = i.Id,
                    ModelName = i.ModelName,
                    CategoryName = i.Category.Name,
                    CurrentQuantity = i.CurrentQuantity,
                    UnitOfMeasure = i.UnitOfMeasure,
                    CriticalLevel = i.CriticalLevel,
                    StockStatus = i.CurrentQuantity == 0 ? "Out of Stock" :
                                  i.CurrentQuantity <= i.CriticalLevel ? "Low Stock" : "OK",
                    LastUpdated = i.LastUpdated
                }).ToList(),
                Categories = categories,
                SelectedCategory = category,
                StockStatusFilter = stockStatus,
                SearchTerm = search,
                Page = page,
                TotalPages = totalPages,
                SortColumn = sort,
                SortDirection = dir,
                UserRole = "Admin" // Replace with your actual logic
            };

            return View(vm);
        }
    }
}