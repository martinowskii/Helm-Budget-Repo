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

namespace Helm_Budget_System.Pages.UserRoles
{
    //[Authorize("SystemAdmin,PrimarySchoolAdmin,SchoolAdmin")]
    public class IndexModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public IndexModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public PaginatedList<UserRole> UserRole { get;set; }
        public string SuccessMessage { get; set; }
        public string CurrentSort { get; set; }
        public string IDSort { get; set; }
        public string NameSort { get; set; }
        public string NameFilter { get; set; }

        public int entryCount;

        public async Task OnGetAsync(string sortOrder, int? pageIndex,
            string searchName, string nameFilter, bool? saveChangesSuccess = false)
        {
            CurrentSort = sortOrder;

            IDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            NameSort = sortOrder == "Name" ? "Name_desc" : "Name";

            if (searchName != null) { pageIndex = 1; }
            else { searchName = nameFilter; }

            NameFilter = nameFilter;

            ViewData["SchoolID"] = new SelectList(_context.School.OrderBy(s => s.SchoolName), "ID", "SchoolName");

            if (saveChangesSuccess.GetValueOrDefault())
            {
                SuccessMessage = String.Format("Entry deleted successfully.");
            }

            IQueryable<UserRole> entryIQ = from s in _context.UserRole select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                entryIQ = entryIQ.Where(s => s.Name.Contains(searchName));
            }

            entryCount = entryIQ.Count();

            switch (sortOrder)
            {
                case "id_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.ID);
                    break;
                case "Name":
                    entryIQ = entryIQ.OrderBy(s => s.Name);
                    break;
                case "Name_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.Name);
                    break;
                default:
                    entryIQ = entryIQ.OrderBy(s => s.ID);
                    break;
            }

            int pageSize = 15;
            UserRole = await PaginatedList<UserRole>.CreateAsync(entryIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
