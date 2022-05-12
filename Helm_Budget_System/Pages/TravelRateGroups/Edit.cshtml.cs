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

namespace Helm_Budget_System.Pages.TravelRateGroups
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
        public TravelRateGroup TravelRateGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TravelRateGroup = await _context.TravelRateGroup.FindAsync(id);

            ViewData["SchoolID"] = new SelectList(_context.School.OrderBy(s => s.SchoolName), "ID", "SchoolName");


            if (TravelRateGroup == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var updateBudgetSector = await _context.TravelRateGroup.FindAsync(id);

            if (updateBudgetSector == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<TravelRateGroup>(updateBudgetSector, "TravelRateGroup",
                s => s.MealPerDiemRate,s => s.CoachTravelRate,s => s.RecruitTravelRate,s => s.SchoolID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
