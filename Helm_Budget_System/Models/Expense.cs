using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class Expense
    {
        public int ID { get; set; }

        [Display(Name = "Description")]
        public string ExpenseDescription { get; set; } = String.Empty;

        [Display(Name = "Comment")]
        public string ExpenseComment { get; set; } = String.Empty;

        [Display(Name = "Quantity")]
        public int ExpenseQuantity { get; set; } = 0;

        [Display(Name = "Rate")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal ExpenseRate { get; set; } = 0;

        [Display(Name = "Other Expense")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? OtherExpense { get; set; }

        [Display(Name = "Budget Sector")] public int BudgetSectorID { get; set; }
        public BudgetSector BudgetSector { get; set; }

        [Display(Name = "Expense Category")] public int ExpenseCategoryID { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

        [Display(Name = "Descriptor Description")] public int DescriptorDescriptionID { get; set; }
        public DescriptorDescription DescriptorDescription { get; set; }

        [Display(Name = "School")] public int SchoolID { get; set; }
        public School School { get; set; }

        [Display(Name = "Year")] public int YearID { get; set; }
        public Year Year { get; set; }
    }
}
