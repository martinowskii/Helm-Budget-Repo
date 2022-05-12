using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helm_Budget_System.Models
{
    public class TravelRateGroup
    {
        public int ID { get; set; }

        [Display(Name = "School")] public int SchoolID { get; set; }

        public School School { get; set; }

        [Display(Name = "Meal Per Diem Rate")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal MealPerDiemRate { get; set; } = 0;

        [Display(Name = "Coach Travel Rate")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal CoachTravelRate { get; set; } = 0;

        [Display(Name = "Recruit Travel Rate")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal RecruitTravelRate { get; set; } = 0;
    }
}
