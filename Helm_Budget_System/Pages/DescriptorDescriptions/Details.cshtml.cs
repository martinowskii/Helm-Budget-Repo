﻿using Helm_Budget_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Helm_Budget_System.Pages.DescriptorDescriptions
{
    //[Authorize("SystemAdmin,PrimarySchoolAdmin,SchoolAdmin")]
    public class DetailsModel : PageModel
    {
        private readonly Helm_Budget_System.Data.Helm_Budget_DbContext _context;

        public DetailsModel(Helm_Budget_System.Data.Helm_Budget_DbContext context)
        {
            _context = context;
        }

        public DescriptorDescription DescriptorDescription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DescriptorDescription = await _context.DescriptorDescription
                .Include(s => s.DescriptorDesignations)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (DescriptorDescription == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
