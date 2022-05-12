using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helm_Budget_System.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "System Admin")] public bool SystemAdmin { get; set; }
        [Display(Name = "Primary School Admin")] public bool PrimarySchoolAdmin { get; set; }
        [Display(Name = "School Admin")] public bool SchoolAdmin { get; set; }
        [Display(Name = "School User")] public bool SchoolUser { get; set; }
        [Display(Name = "Read-only User")] public bool ReadOnlyUser { get; set; }
    }
}
