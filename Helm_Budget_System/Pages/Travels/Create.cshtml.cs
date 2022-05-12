using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Helm_Budget_System.Data;
using Helm_Budget_System.Models;

namespace Helm_Budget_System.Pages.Travels
{
    public class CreateModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public CreateModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BudgetSectorID"] = new SelectList(_context.BudgetSector, "ID", "BudgetSectorName");
            ViewData["YearID"] = new SelectList(_context.Year, "ID", "YearEntry");
            ViewData["TravelCategoryID"] = new SelectList(_context.TravelCategory, "ID", "Description");
            return Page();
        }

        [BindProperty]
        public TravelEntry TravelEntry { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TravelEntry.Add(TravelEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
