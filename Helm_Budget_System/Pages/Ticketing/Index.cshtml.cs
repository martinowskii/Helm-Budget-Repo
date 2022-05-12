using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Helm_Budget_System.Data;
using Helm_Budget_System.Models;

namespace Helm_Budget_System.Pages.Ticketing
{
    public class IndexModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public IndexModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public PaginatedList<Ticket> Tickets { get; set; }
        public string SuccessMessage { get; set; }
        public string CurrentSort { get; set; }
        public string IDSort { get; set; }
        public string NameSort { get; set; }
        public string NameFilter { get; set; }

        public int entryCount;

        public async Task OnGetAsync(string sortOrder, int? pageIndex,
            string searchName, string nameFilter, bool? saveChangesSuccess = false)
        {
            CurrentSort = sortOrder;

            IDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            NameSort = sortOrder == "Name" ? "Name_desc" : "Name";

            if (searchName != null) { pageIndex = 1; }
            else { searchName = nameFilter; }

            NameFilter = nameFilter;

            if (saveChangesSuccess.GetValueOrDefault())
            {
                SuccessMessage = String.Format("Entry deleted successfully.");
            }

            IQueryable<Ticket> entryIQ = from t in _context.Ticket select t;

            if (!String.IsNullOrEmpty(searchName))
            {
                entryIQ = entryIQ.Where(t => t.TicketName.Contains(searchName));
            }

            entryCount = entryIQ.Count();

            switch (sortOrder)
            {
                case "id_desc":
                    entryIQ = entryIQ.OrderByDescending(r => r.ID);
                    break;
                case "Name":
                    entryIQ = entryIQ.OrderBy(r => r.TicketName);
                    break;
                case "Name_desc":
                    entryIQ = entryIQ.OrderByDescending(r => r.TicketName);
                    break;
                default:
                    entryIQ = entryIQ.OrderBy(r => r.ID);
                    break;
            }

            int pageSize = 15;
            Tickets = await PaginatedList<Ticket>.CreateAsync(entryIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
