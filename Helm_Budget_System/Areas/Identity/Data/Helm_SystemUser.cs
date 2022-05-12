using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Helm_Budget_System.Models;
using Microsoft.AspNetCore.Identity;

namespace Helm_Budget_System.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Helm_SystemUser class
public class Helm_SystemUser : IdentityUser
{
    [Display(Name = "First Name")] [Required] public string FirstName { get; set; }
    [Display(Name = "Last Name")] [Required] public string LastName { get; set; }
    [Display(Name = "Title")] public string Title { get; set; }
    public bool Active { get; set; }

    [Display(Name = "Name")]
    public string FullName
    {
        get
        {
            return LastName + ", " + FirstName;
        }
    }

    [Display(Name = "School")] public int? SchoolID { get; set; }
    [Display(Name = "School")] public School School { get; set; }
    [Display(Name = "User Role")] [Required] public int UserRoleID { get; set; }
    [Display(Name = "User Role")] public UserRole UserRole { get; set; }
}

