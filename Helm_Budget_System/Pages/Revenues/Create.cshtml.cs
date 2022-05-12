using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Helm_Budget_System.Data;
using Helm_Budget_System.Models;

namespace Helm_Budget_System.Pages.Revenues
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
        ViewData["DescriptorDescriptionID"] = new SelectList(_context.DescriptorDescription, "ID", "DescriptorDescriptionName");
        ViewData["RevenueCategoryID"] = new SelectList(_context.RevenueCategory, "ID", "RevenueCategoryName");
        ViewData["SchoolID"] = new SelectList(_context.School, "ID", "ID");
        ViewData["YearID"] = new SelectList(_context.Year, "ID", "YearEntry");
            return Page();
        }

        [BindProperty]
        public Revenue Revenue { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Revenue.Add(Revenue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
