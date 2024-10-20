using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static JKL_Healthcare_Services.Models.Dbcontext;

namespace JKL_Healthcare_Services.Models
{
    public class Doctor
    {
        // Unique identifier for the Doctor
        public int Id { get; set; }

        // Navigation property to link to the ApplicationUser for authentication purposes
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }

        // The full name of the doctor, could be a concatenation of FirstName and LastName
        public string FullName { get; set; }

        // Required attributes for the doctor's first name
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Required attributes for the doctor's last name
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Required attributes for the doctor's email address with validation for email format
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        // Property for the doctor's designation (e.g., MD, DO)
        public string Designation { get; set; }

        // The residential address of the doctor
        public string Address { get; set; }

        // The doctor's primary phone number
        [Display(Name = "Phone No")]
        public string PhoneNo { get; set; }

        // The doctor's mobile contact number
        [Display(Name = "Mobile No")]
        public string ContactNo { get; set; }

        // Property for the doctor's area of specialization (e.g., Cardiology, Dermatology)
        public string Specialization { get; set; }

        // Gender of the doctor
        public string Gender { get; set; }

        // Blood group of the doctor for medical records
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        // The doctor's date of birth with a display format for consistency
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        // Educational qualifications or degrees obtained by the doctor
        [Display(Name = "Education/Degree")]
        public string Education { get; set; }

        // Status of the doctor's employment (e.g., Active, Inactive)
        public string Status { get; set; }
    }
}
