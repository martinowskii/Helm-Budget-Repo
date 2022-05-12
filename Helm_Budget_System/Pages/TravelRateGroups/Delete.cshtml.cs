using Helm_Budget_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Helm_Budget_System.Pages.TravelRateGroups
{
    //[Authorize("SystemAdmin,PrimarySchoolAdmin,SchoolAdmin")]
    public class DeleteModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(Helm_Budget_System.Data.Helm_Budget_DbContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public TravelRateGroup TravelRateGroup { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            TravelRateGroup = await _context.TravelRateGroup.Include(s => s.School).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (TravelRateGroup == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Unable to delete entry. Please remove any references and try again");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var school = await _context.TravelRateGroup.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            try
            {
                _context.TravelRateGroup.Remove(school);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index", new { id, saveChangesSucess = true });
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}
