using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class TravelAirfare
    {
        public int ID { get; set; }
        [ForeignKey("FK_TravelParty")]
        public int TravelPartyID { get; set; }
        [Required(ErrorMessage = "Please enter a description for this airfare entry.")]
        public string Description { get; set; }
        [Display(Name = "Cost Per Person")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal CostPerPerson { get; set; }
        [Display(Name = "Baggage Cost (Per Person)")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal BaggagePerPerson { get; set; }
        [Display(Name = "Baggage Cost Total")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal BaggageCostTotal { get; set; }
        [Display(Name = "Agent Fee")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal AgentFee { get; set; }
        [Display(Name = "Agent Fee Total")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal AgentFeeTotal { get; set; }
        public bool IsCharter { get; set; }
        [Display(Name = "Total Airfare Expense")]
        [Column(TypeName = "decimal(12, 2)")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalAirfareExpense { get; set; }
    }
}
