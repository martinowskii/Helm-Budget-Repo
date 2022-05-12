using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Helm_Budget_System.Data;
using Helm_Budget_System.Models;

namespace Helm_Budget_System.Pages.Travels
{
    public class IndexModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public IndexModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public PaginatedList<TravelEntry> TravelEntry { get; set; }
        public string SuccessMessage { get; set; }
        public string CurrentSort { get; set; }
        public string IDSort { get; set; }
        public string NameSort { get; set; }
        public string NameFilter { get; set; }
        public string TravelCategorySort { get; set; }
        public string BudgetSectorSort { get; set; }

        public int entryCount;

        public async Task OnGetAsync(string sortOrder, int? pageIndex,
            string searchName, string nameFilter, bool? saveChangesSuccess = false)
        {
            CurrentSort = sortOrder;

            IDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            NameSort = sortOrder == "Name" ? "Name_desc" : "Name";
            TravelCategorySort = String.IsNullOrEmpty(sortOrder) ? "TravelCategory_desc" : "";
            BudgetSectorSort = String.IsNullOrEmpty(sortOrder) ? "BudgetSector_desc" : "";

            if (searchName != null) { pageIndex = 1; }
            else { searchName = nameFilter; }

            NameFilter = nameFilter;

            if (saveChangesSuccess.GetValueOrDefault())
            {
                SuccessMessage = String.Format("Entry deleted successfully.");
            }

            IQueryable<TravelEntry> entryIQ = from t in _context.TravelEntry
                                              .Include(t => t.TravelCategory)
                                              .Include(t => t.BudgetSector) select t;

            if (!String.IsNullOrEmpty(searchName))
            {
                entryIQ = entryIQ.Where(t => t.EventDescription.Contains(searchName));
            }

            entryCount = entryIQ.Count();

            switch (sortOrder)
            {
                case "id_desc":
                    entryIQ = entryIQ.OrderByDescending(t => t.ID);
                    break;
                case "Name":
                    entryIQ = entryIQ.OrderBy(t => t.EventDescription);
                    break;
                case "Name_desc":
                    entryIQ = entryIQ.OrderByDescending(t => t.EventDescription);
                    break;
                case "TravelCategory":
                    entryIQ = entryIQ.OrderBy(t => t.TravelCategory.Description);
                    break;
                case "TravelCategory_desc":
                    entryIQ = entryIQ.OrderByDescending(t => t.TravelCategory.Description);
                    break;
                case "BudgetSector":
                    entryIQ = entryIQ.OrderBy(t => t.BudgetSector.BudgetSectorName);
                    break;
                case "BudgetSector_desc":
                    entryIQ = entryIQ.OrderByDescending(t => t.BudgetSector.BudgetSectorName);
                    break;
                default:
                    entryIQ = entryIQ.OrderBy(t => t.ID);
                    break;
            }

            int pageSize = 15;
            TravelEntry = await PaginatedList<TravelEntry>.CreateAsync(entryIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
