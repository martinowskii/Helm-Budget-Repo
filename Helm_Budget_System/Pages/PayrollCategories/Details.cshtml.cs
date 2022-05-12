using Helm_Budget_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Helm_Budget_System.Pages.PayrollCategories
{
    //[Authorize("SystemAdmin,PrimarySchoolAdmin,SchoolAdmin")]
    public class DetailsModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public DetailsModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public PayrollCategory PayrollCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PayrollCategory = await _context.PayrollCategory.Include(s => s.School).FirstOrDefaultAsync(m => m.ID == id);

            if (PayrollCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
