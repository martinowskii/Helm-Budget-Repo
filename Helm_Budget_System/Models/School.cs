using System.ComponentModel.DataAnnotations;

namespace Helm_Budget_System.Models
{
    public class School
    {
        public int ID { get; set; }
        [Display(Name = "School Name")] public string SchoolName { get; set; }
    }
}
