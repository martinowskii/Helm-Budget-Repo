using System.ComponentModel.DataAnnotations;

namespace Helm_Budget_System.Models
{
    public class BudgetSector
    {
        public int ID { get; set; }
        [Display(Name = "Budget Sector")][Required] public string BudgetSectorName { get; set; }
        [Display(Name = "School")] public int SchoolID { get; set; }
        public School School { get; set; }
    }
}
