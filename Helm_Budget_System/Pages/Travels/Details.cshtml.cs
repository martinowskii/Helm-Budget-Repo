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
    public class DetailsModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public DetailsModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public TravelEntry TravelEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TravelEntry = await _context.TravelEntry
                .Include(t => t.TravelCategory)
                .Include(t => t.Year)
                .Include(t => t.BudgetSector)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (TravelEntry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
