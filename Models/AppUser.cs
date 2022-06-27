using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ClinicManagement.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name ="Doctor")]
          public int DoctorID { get; set; }

        //   // [Required]       
        //   [DataType(DataType.Date)]
        //   public DateTime? BirthDate { get; set; }
    }
}