using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Helm_Budget_System.Data;
using Helm_Budget_System.Models;

namespace Helm_Budget_System.Pages.Revenues
{
    public class DetailsModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public DetailsModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public Revenue Revenue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Revenue = await _context.Revenue
                .Include(r => r.BudgetSector)
                .Include(r => r.DescriptorDescription)
                .Include(r => r.RevenueCategory)
                .Include(r => r.School)
                .Include(r => r.Year).FirstOrDefaultAsync(m => m.ID == id);

            if (Revenue == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
