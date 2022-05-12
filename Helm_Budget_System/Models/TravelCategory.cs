using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class TravelCategory
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please select a travel category.")]
        public string Description { get; set; }
    }
}
