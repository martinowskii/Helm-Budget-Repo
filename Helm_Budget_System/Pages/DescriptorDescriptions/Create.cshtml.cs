using Helm_Budget_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helm_Budget_System.Pages.DescriptorDescriptions
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
            return Page();
        }

        [BindProperty]
        public DescriptorDescription DescriptorDescription { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var newEntry = new DescriptorDescription();

            if (await TryUpdateModelAsync<DescriptorDescription>(newEntry, "DescriptorDescription",
                s => s.DescriptorDescriptionName))
            {
                _context.DescriptorDescription.Add(newEntry);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
