using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class TravelMiscellaneousExpense
    {
        public int ID { get; set; }
        [ForeignKey("FK_TravelEntry")]
        public int TravelEntryID { get; set; }
        [Required(ErrorMessage = "Please enter a description for this miscellaneous expense.")]
        public string Description { get; set; }
        [Display(Name = "Total Cost")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalExpense { get; set; }
    }
}
