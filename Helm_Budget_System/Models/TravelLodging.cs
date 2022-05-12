using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class TravelLodging
    {
        public int ID { get; set; }
        [ForeignKey("FK_TravelParty")]
        public int TravelPartyID { get; set; }
        [Required(ErrorMessage = "Please enter a description for this lodging entry.")]
        public string Description { get; set; }
        public int Nights { get; set; }
        public int Rooms { get; set; }
        [Display(Name = "Room Rate")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal RoomRate { get; set; }
        [Display(Name = "Total Expense")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalExpense { get; set; }

    }
}
