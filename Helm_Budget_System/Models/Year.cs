using System.ComponentModel.DataAnnotations;

namespace Helm_Budget_System.Models
{
    public class Year
    {
        public int ID { get; set; }
        [Display(Name = "Year")] public int YearEntry { get; set; }
    }
}
