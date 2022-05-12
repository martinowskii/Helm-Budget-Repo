using Helm_Budget_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helm_Budget_System.Pages.ExpenseCategories
{
    //[Authorize("SystemAdmin,PrimarySchoolAdmin,SchoolAdmin")]
    public class CreateModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public CreateModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SchoolID"] = new SelectList(_context.School.OrderBy(s => s.SchoolName), "ID", "SchoolName");

            return Page();
        }

        [BindProperty]
        public ExpenseCategory ExpenseCategory { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var newBudgetSector = new ExpenseCategory();

            if (await TryUpdateModelAsync<ExpenseCategory>(newBudgetSector, "ExpenseCategory",
                s => s.ExpenseCategoryName, s => s.SchoolID))
            {
                _context.ExpenseCategory.Add(newBudgetSector);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
