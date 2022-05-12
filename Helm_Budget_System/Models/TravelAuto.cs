using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class TravelAuto
    {
        public int ID { get; set; }
        [ForeignKey("FK_TravelParty")]
        public int TravelPartyID { get; set; }
        [Required(ErrorMessage = "Please enter a description for this auto entry.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter your auto option.")]
        public string AutoOption { get; set; }
        [Display(Name = "Total Cost")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalCost { get; set; }
    }
}
