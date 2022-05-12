using System.ComponentModel.DataAnnotations;

namespace Helm_Budget_System.Models
{
    public class ExpenseCategory
    {
        public int ID { get; set; }
        [Display(Name = "Expense Category")][Required] public string ExpenseCategoryName { get; set; }
        [Display(Name = "School")] public int SchoolID { get; set; }
        public School School { get; set; }
    }
}
