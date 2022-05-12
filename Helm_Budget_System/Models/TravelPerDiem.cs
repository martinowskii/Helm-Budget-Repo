using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class TravelPerDiem
    {
        public int ID { get; set; }
        [ForeignKey("FK_TravelParty")]
        public int TravelPartyID { get; set; }
        public int BreakfastDays { get; set; }
        public int LunchDays { get; set; }
        public int DinnerDays { get; set; }
    }
}
