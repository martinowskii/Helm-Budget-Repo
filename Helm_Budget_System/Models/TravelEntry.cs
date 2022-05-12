using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class TravelEntry
    {
        public int ID { get; set; }
        [Required]
        [ForeignKey("FK_BudgetSector")]
        [Display(Name = "Budget Sector")]
        public int BudgetSectorID { get; set; }
        public BudgetSector BudgetSector { get; set; }
        [Required]
        [ForeignKey("FK_Year")]
        [Display(Name = "Year")]
        public int YearID { get; set; }
        public Year Year { get; set; }
        [Required]
        [ForeignKey("FK_TravelCategory")]
        [Display(Name = "Travel Category")]
        public int TravelCategoryID { get; set; }
        public TravelCategory TravelCategory { get; set; }
        public DateTime TravelStartDate { get; set; }
        public DateTime TravelEndDate { get; set; }
        [Display(Name = "In State?")]
        public bool InState { get; set; }
        [Display(Name = "In Conference?")]
        public bool IsConference { get; set; }
        [Required(ErrorMessage = "Please enter a description for this travel event.")]
        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        public virtual ICollection<TravelParty> TravelParties { get; set; }
        public virtual ICollection<TravelMiscellaneousExpense> TravelMiscellaneousExpenses { get; set; }

    }
}
