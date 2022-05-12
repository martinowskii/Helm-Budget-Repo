using System.ComponentModel.DataAnnotations;

namespace Helm_Budget_System.Models
{
    public class RevenueCategory
    {
        public int ID { get; set; }
        [Display(Name = "Revenue Category")][Required] public string RevenueCategoryName { get; set; }
        [Display(Name = "School")] public int SchoolID { get; set; }
        public School School { get; set; }
    }
}
