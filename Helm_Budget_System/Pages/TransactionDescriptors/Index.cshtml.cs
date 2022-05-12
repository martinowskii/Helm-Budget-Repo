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

namespace Helm_Budget_System.Pages.TransactionDescriptors
{
    //[Authorize("SystemAdmin,PrimarySchoolAdmin,SchoolAdmin")]
    public class IndexModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public IndexModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public PaginatedList<TransactionDescriptor> TransactionDescriptor { get;set; }
        public string SuccessMessage { get; set; }
        public string CurrentSort { get; set; }
        public string IDSort { get; set; }
        public string NameSort { get; set; }
        public string SchoolSort { get; set; }
        public string NameFilter { get; set; }
        public string SchoolFilter { get; set; }

        public int entryCount;

        public async Task OnGetAsync(string sortOrder, int? pageIndex,
            string searchSchool, string schoolFilter, 
            string searchName, string nameFilter, bool? saveChangesSuccess = false)
        {
            CurrentSort = sortOrder;

            IDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            NameSort = sortOrder == "Name" ? "Name_desc" : "Name";
            SchoolSort = sortOrder == "School" ? "School_desc" : "School";

            if (searchName != null) { pageIndex = 1; }
            else { searchName = nameFilter; }
            if (searchSchool != null) { pageIndex = 1; }
            else { searchSchool = schoolFilter; }

            NameFilter = nameFilter;
            SchoolFilter = schoolFilter;

            ViewData["SchoolID"] = new SelectList(_context.School.OrderBy(s => s.SchoolName), "ID", "SchoolName");

            if (saveChangesSuccess.GetValueOrDefault())
            {
                SuccessMessage = String.Format("Entry deleted successfully.");
            }

            IQueryable<TransactionDescriptor> entryIQ = from s in _context.TransactionDescriptor.Include(s => s.School) select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                entryIQ = entryIQ.Where(s => s.TransactionDescriptorName.Contains(searchName));
            }
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
                case "Name":
                    entryIQ = entryIQ.OrderBy(s => s.TransactionDescriptorName);
                    break;
                case "Name_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.TransactionDescriptorName);
                    break;
                case "School":
                    entryIQ = entryIQ.OrderBy(s => s.School.SchoolName);
                    break;
                case "School_desc":
                    entryIQ = entryIQ.OrderByDescending(s => s.School.SchoolName);
                    break;
                default:
                    entryIQ = entryIQ.OrderBy(s => s.ID);
                    break;
            }

            int pageSize = 15;
            TransactionDescriptor = await PaginatedList<TransactionDescriptor>.CreateAsync(entryIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
