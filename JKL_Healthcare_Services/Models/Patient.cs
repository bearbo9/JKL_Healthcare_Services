using System; // Imports fundamental classes like DateTime, which are essential for date manipulations and other system-level operations.
using System.Collections.Generic; // Provides support for collections like lists, dictionaries, etc., that may be used in the model.
using System.ComponentModel.DataAnnotations; // Provides attributes like [Required], [Display], and [DataType] for validation and metadata annotations in the model.
using System.Linq; // Enables LINQ (Language-Integrated Query) for querying collections, although not explicitly used here.
using System.Web; // Contains classes for HTTP requests and web applications, though not directly used in this model.

namespace JKL_Healthcare_Services.Models // Declares the namespace, which groups related classes together. Here, it's for the healthcare service models.
{
    public class Patient // Defines the Patient class, which represents a patient entity in the application.
    {
        public int Id { get; set; } // Property to store the unique identifier for each patient. The database usually auto-generates this.

        public ApplicationUser ApplicationUser { get; set; } // Navigation property representing the relationship between the Patient and the ApplicationUser entity. This is useful for accessing the full user details.
        public string ApplicationUserId { get; set; } // Foreign key property representing the ID of the associated ApplicationUser. It's a string because user IDs are often GUIDs or other non-numeric identifiers.

        [Required] // Indicates that this property is mandatory and cannot be null or empty.
        [Display(Name = "First Name")] // Specifies the display name for this property in forms or UI, as "First Name" instead of the default "FirstName".
        public string FirstName { get; set; } // Stores the patient's first name.

        [Required] // Indicates that this property is required.
        [Display(Name = "Last Name")] // Specifies the display name for this property as "Last Name".
        public string LastName { get; set; } // Stores the patient's last name.

        [Display(Name = "Name")] // Specifies the display name as "Name" for this field in the UI.
        public string FullName { get; set; } // Stores the patient's full name. This might be computed from FirstName and LastName elsewhere in the application.

        [EmailAddress] // Ensures that the value entered for this property is a valid email address.
        [Display(Name = "Email Id")] // Specifies the display name as "Email Id".
        public string EmailAddress { get; set; } // Stores the patient's email address.

        [Display(Name = "Phone No")] // Specifies the display name as "Phone No".
        public string PhoneNo { get; set; } // Stores the patient's phone number.

        public string Contact { get; set; } // Stores additional contact information. This could be a secondary phone number, or other contact details.

        [Display(Name = "Blood Group")] // Specifies the display name as "Blood Group".
        public string BloodGroup { get; set; } // Stores the patient's blood group, which could be useful in medical contexts.

        public string Gender { get; set; } // Stores the patient's gender. It is kept optional or nullable for flexibility.

        [Display(Name = "Date of Birth")] // Specifies the display name as "Date of Birth" in the UI.
        [DataType(DataType.Date)] // Indicates that this property should be treated as a date field.
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Specifies the format in which the date should be displayed and edited (YYYY-MM-DD).
        public DateTime? DateOfBirth { get; set; } // Stores the patient's date of birth. It's nullable (DateTime?) since a birthdate may not always be provided.

        public string Address { get; set; } // Stores the patient's address, which might include street, city, etc.
    }
}

