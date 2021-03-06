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
using Microsoft.AspNetCore.Authorization;

namespace Helm_Budget_System.Pages.PayrollCategories
{
    //[Authorize("SystemAdmin,PrimarySchoolAdmin,SchoolAdmin")]
    public class EditModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public EditModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PayrollCategory PayrollCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PayrollCategory = await _context.PayrollCategory.FindAsync(id);

            ViewData["SchoolID"] = new SelectList(_context.School.OrderBy(s => s.SchoolName), "ID", "SchoolName");


            if (PayrollCategory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var updateBudgetSector = await _context.PayrollCategory.FindAsync(id);

            if (updateBudgetSector == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<PayrollCategory>(updateBudgetSector, "PayrollCategory",
                s => s.PayrollCategoryName,s => s.SchoolID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
