using System; // Provides fundamental classes and base types, like DateTime, used for date manipulations.
using System.Collections.Generic; // Enables collections such as List<T> and Dictionary<TKey, TValue> that could be used in models.
using System.ComponentModel.DataAnnotations; // Provides attributes for validation like [Required], [EmailAddress], and [DataType].
using System.Web; // Contains classes for web applications, although not directly used in this specific class.
using static JKL_Healthcare_Services.Models.Dbcontext;

namespace JKL_Healthcare_Services.Models // Defines the namespace for grouping related classes in the healthcare service domain.
{
    public class Patient // Defines the Patient class, which represents a patient entity in the system.
    {
        // Primary Key: Represents the unique identifier for each patient.
        public int Id { get; set; }

        // Navigation Property: Links the Patient to the ApplicationUser entity (e.g., user account details).
        public ApplicationUser ApplicationUser { get; set; }

        // Foreign Key: Stores the ID of the associated ApplicationUser as a string (commonly used for user IDs like GUIDs).
        public string ApplicationUserId { get; set; }

        // First Name Field: Required attribute ensures this field cannot be empty. 
        // RegularExpression ensures the name contains only letters to prevent invalid input (e.g., numbers or special characters).
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")] // Provides a more user-friendly label in the UI.
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name should contain only letters.")]
        public string FirstName { get; set; } // Stores the patient's first name.

        // Last Name Field: Same validation rules as FirstName. Required and only allows alphabetic characters.
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name should contain only letters.")]
        public string LastName { get; set; } // Stores the patient's last name.

        // Full Name Field: Combines the first and last names. This field could be automatically generated in the application logic.
        [Display(Name = "Name")]
        public string FullName { get; set; } // Stores the patient's full name.

        // Email Field: Validates that the email format is correct using [EmailAddress].
        // The Required attribute ensures that an email must be provided.
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Email Id")]
        public string EmailAddress { get; set; } // Stores the patient's email address.

        // Phone Number Field: Validates that the phone number contains only digits.
        [Display(Name = "Phone No")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number must contain only digits.")]
        public string PhoneNo { get; set; } // Stores the patient's phone number.

        // Additional Contact Information Field: Can be used for secondary contact details (e.g., alternate phone or emergency contact).
        public string Contact { get; set; } // Stores additional contact information.

        // Blood Group Field: Optional field that stores the patient's blood type, useful in medical contexts.
        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; } // Stores the patient's blood group.

        // Gender Field: Stores the patient's gender (optional), which might be used in medical or demographic reporting.
        public string Gender { get; set; } // Stores the patient's gender.

        // Date of Birth Field: Specifies the patient's birthdate.
        // [DataType(DataType.Date)] ensures the date is rendered correctly in the UI, and [DisplayFormat] defines how it's displayed.
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Formats the date as YYYY-MM-DD.
        public DateTime? DateOfBirth { get; set; } // Nullable because the birth date might not always be available.

        // Address Field: Stores the patient's physical address, which may include street, city, state, etc.
        public string Address { get; set; } // Stores the patient's address.

        // Additional methods or properties (e.g., validation logic or data masking) could be implemented here to further secure or manipulate sensitive fields.
    }
}
