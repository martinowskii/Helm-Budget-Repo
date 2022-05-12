using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public int SchoolID { get; set; }
        public string TicketType { get; set; } // Seasonal or Single Game. Enum?

        public string PriceType { get; set; } // Chosen by school

        [Display(Name = "Price")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TicketPrice { get; set; } = 0;
        [Display(Name = "Ticket Name")]
        public string TicketName { get; set; } // For single games.

    }
}
