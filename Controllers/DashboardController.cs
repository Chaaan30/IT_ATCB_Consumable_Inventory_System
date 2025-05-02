using Microsoft.AspNetCore.Mvc;
using IT_ATCB_Consumable_Inventory_System.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IT_ATCB_Consumable_Inventory_System.Controllers
{
    public class DashboardController : Controller
    {
        private readonly InventoryContext _context;

        public DashboardController(InventoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Replace dummy values with real queries:
            var totalItems = await _context.Items.CountAsync();
            var totalCategories = await _context.Categories.CountAsync();
            var totalSuppliers = await _context.Suppliers.CountAsync();

            var categoryStock = await _context.Categories
                .Select(c => new
                {
                    c.Name,
                    Count = c.Items.Count()
                }).ToListAsync();

            var topItems = await _context.Items
                .OrderByDescending(i => i.CurrentQuantity)
                .Take(5)
                .Select(i => new { i.ModelName, i.CurrentQuantity })
                .ToListAsync();

            // You can similarly get recent activities if you have a table/log for that

            var model = new DashboardViewModel
            {
                UserName = User.Identity.Name,
                SummaryCards = new List<DashboardSummaryCard>
                {
                    new DashboardSummaryCard { Title = "Total Items", Value = totalItems },
                    new DashboardSummaryCard { Title = "Categories", Value = totalCategories },
                    new DashboardSummaryCard { Title = "Suppliers", Value = totalSuppliers }
                },
                CategoryStockLabels = categoryStock.Select(c => c.Name).ToArray(),
                CategoryStockValues = categoryStock.Select(c => c.Count).ToArray(),
                TopItemsLabels = topItems.Select(t => t.ModelName).ToArray(),
                TopItemsValues = topItems.Select(t => t.CurrentQuantity).ToArray(),
                // Fill in RecentActivities and Flash/ErrorMessage as needed
                RecentActivities = new List<DashboardRecentActivity>(), // TODO: fill this if you have a log
                FlashMessage = TempData["FlashMessage"] as string,
                ErrorMessage = TempData["ErrorMessage"] as string
            };

            return View(model);
        }
    }
}