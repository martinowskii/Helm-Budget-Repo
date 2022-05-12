using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class Revenue
    {
        public int ID { get; set; }

        [Display(Name = "Description")]
        public string RevenueDescription { get; set; } = String.Empty;

        [Display(Name = "Comment")]
        public string RevenueComment { get; set; } = String.Empty;

        [Display(Name = "Quantity")]
        public int RevenueQuantity { get; set; } = 0;

        [Display(Name = "Rate")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal RevenueRate { get; set; } = 0;

        [Display(Name = "Other Revenue")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal? OtherRevenue { get; set; }

        [Display(Name = "Budget Sector")] public int BudgetSectorID { get; set; }
        public BudgetSector BudgetSector { get; set; }

        [Display(Name = "Revenue Category")] public int RevenueCategoryID { get; set; }
        public RevenueCategory RevenueCategory { get; set; }

        [Display(Name = "Descriptor Description")] public int DescriptorDescriptionID { get; set; }
        public DescriptorDescription DescriptorDescription { get; set; }

        [Display(Name = "School")] public int SchoolID { get; set; }
        public School School { get; set; }

        [Display(Name = "Year")] public int YearID { get; set; }
        public Year Year { get; set; }
    }
}
