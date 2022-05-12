using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Helm_Budget_System.Data;
using Helm_Budget_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helm_Budget_System.Pages.TravelRateGroups
{
    //[Authorize("SystemAdmin,PrimarySchoolAdmin,SchoolAdmin")]
    public class IndexModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public IndexModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public PaginatedList<TravelRateGroup> TravelRateGroup { get;set; }
        public string SuccessMessage { get; set; }
        public string CurrentSort { get; set; }
        public string IDSort { get; set; }
        public string PerDSort { get; set; }
        public string CoachSort { get; set; }
        public string RecrSort { get; set; }
        public string SchoolSort { get; set; }
        public string SchoolFilter { get; set; }

        public int entryCount;

        public async Task OnGetAsync(string sortOrder, int? pageIndex,
            string searchSchool, string schoolFilter, bool? saveChangesSuccess = false)
        {
            CurrentSort = sortOrder;

            IDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            SchoolSort = sortOrder == "School" ? "School_desc" : "School";
            PerDSort = sortOrder == "PerD" ? "PerD_desc" : "PerD";
            CoachSort = sortOrder == "Coach" ? "Coach_desc" : "Coach";
            RecrSort = sortOrder == "Recr" ? "Recr_desc" : "Recr";

            if (searchSchool != null) { pageIndex = 1; }
            else { searchSchool = schoolFilter; }

            SchoolFilter = schoolFilter;

            ViewData["SchoolID"] = new SelectList(_context.School.OrderBy(s => s.SchoolName), "ID", "SchoolName");

            if (saveChangesSuccess.GetValueOrDefault())
            {
                SuccessMessage = String.Format("Entry deleted successfully.");
            }

            IQueryable<TravelRateGroup> entryIQ = from s in _context.TravelRateGroup.Include(s => s.School) select s;

            if (searchSchool != null)
            {
                entryIQ = entryIQ.Where(s => s.SchoolID.ToString() == searchSchool);
            }

            entryCount = entryIQ.Count();

            switch (sortOrder)
            {
                case "id_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.ID);
                    break;
                case "School":
                    entryIQ = entryIQ.OrderBy(s => s.School.SchoolName);
                    break;
                case "School_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.School.SchoolName);
                    break;
                case "PerD":
                    entryIQ = entryIQ.OrderBy(s => s.MealPerDiemRate);
                    break;
                case "PerD_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.MealPerDiemRate);
                    break;
                case "Coach":
                    entryIQ = entryIQ.OrderBy(s => s.CoachTravelRate);
                    break;
                case "Coach_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.CoachTravelRate);
                    break;
                case "Recr":
                    entryIQ = entryIQ.OrderBy(s => s.RecruitTravelRate);
                    break;
                case "Recr_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.RecruitTravelRate);
                    break;
                default:
                    entryIQ = entryIQ.OrderBy(s => s.ID);
                    break;
            }

            int pageSize = 15;
            TravelRateGroup = await PaginatedList<TravelRateGroup>.CreateAsync(entryIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
