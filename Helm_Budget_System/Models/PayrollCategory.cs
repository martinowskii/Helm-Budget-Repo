using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helm_Budget_System.Models
{
    public class PayrollCategory
    {
        public int ID { get; set; }

        [Display(Name = "Payroll Category")][Required] public string PayrollCategoryName { get; set; }

        [Display(Name = "School")] public int SchoolID { get; set; }

        public School School { get; set; }

        [Display(Name = "Fringe Benefit Rate")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? FringeBenefitRate { get; set; }

        [Display(Name = "Annual Benefit Rate")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? AnnualBenefitRate { get; set; }
    }
}
