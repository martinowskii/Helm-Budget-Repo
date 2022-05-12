using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class TravelParty
    {
        public int ID { get; set; }
        [ForeignKey("FK_TravelEntry")]
        public int TravelEntryID { get; set; }
        [Required(ErrorMessage = "Please enter the traveler type for this party.")]
        public string TravelerType { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<TravelAirfare> TravelAirfares { get; set; }
        public virtual ICollection<TravelAuto> TravelAutos { get; set; }
        public virtual ICollection<TravelLodging> TravelLodgings { get; set; }
        public virtual ICollection<TravelPerDiem> TravelPerDiems { get; set; }

    }
}
