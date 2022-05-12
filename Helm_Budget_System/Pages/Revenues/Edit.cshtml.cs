using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helm_Budget_System.Data;
using Helm_Budget_System.Models;

namespace Helm_Budget_System.Pages.Revenues
{
    public class EditModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public EditModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["BudgetSectorID"] = new SelectList(_context.BudgetSector, "ID", "BudgetSectorName");
           ViewData["DescriptorDescriptionID"] = new SelectList(_context.DescriptorDescription, "ID", "DescriptorDescriptionName");
           ViewData["RevenueCategoryID"] = new SelectList(_context.RevenueCategory, "ID", "RevenueCategoryName");
           ViewData["SchoolID"] = new SelectList(_context.School, "ID", "ID");
           ViewData["YearID"] = new SelectList(_context.Year, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Revenue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevenueExists(Revenue.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RevenueExists(int id)
        {
            return _context.Revenue.Any(e => e.ID == id);
        }
    }
}
