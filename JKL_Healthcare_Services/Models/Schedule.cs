// Required namespaces for the model
using System; // Provides basic functionalities like DateTime
using System.Collections.Generic; // Allows the use of collections (though not used in this class)
using System.ComponentModel.DataAnnotations; // Provides data annotation attributes like [Required], [Display], and [DataType]
using System.Linq; // Allows LINQ functionalities
using System.Web; // Contains classes for web-related operations

namespace JKL_Healthcare_Services.Models
{
    // The Schedule class represents a doctor's availability schedule.
    public class Schedule
    {
        // Primary key for the schedule.
        public int Id { get; set; }

        // Navigation property to the Doctor entity.
        // This is a reference to the doctor whose schedule this is.
        public Doctor Doctor { get; set; }

        // Foreign key to the Doctor entity.
        // This links the schedule to a specific doctor.
        [Display(Name = "Doctor Name")] // Display name for the view
        public int DoctorId { get; set; } // Foreign key (FK) reference for the Doctor

        // The day on which the doctor's availability starts.
        // This could represent the start day of the week (e.g., Monday).
        [Required(ErrorMessage = "Start day is required.")] // Marks the field as required, meaning it must be provided
        [Display(Name = "Start Day")] // Display name for the view
        public string AvailableStartDay { get; set; } // Stores the starting day (e.g., "Monday")

        // The day on which the doctor's availability ends.
        // This could represent the end day of the week (e.g., Friday).
        [Required(ErrorMessage = "End day is required.")] // Marks the field as required, meaning it must be provided
        [Display(Name = "End Day")] // Display name for the view
        public string AvailableEndDay { get; set; } // Stores the ending day (e.g., "Friday")

        // The time at which the doctor starts being available on the given days.
        [Required(ErrorMessage = "Start time is required.")] // Marks the field as required, meaning it must be provided
        [Display(Name = "Start Time")] // Display name for the view
        [DataType(DataType.Time)] // Specifies that this field is a time (for form rendering)
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)] // Specifies the format for time display (e.g., "09:00 AM")
        public DateTime AvailableStartTime { get; set; } // Stores the starting time of availability

        // The time at which the doctor stops being available on the given days.
        [Required(ErrorMessage = "End time is required.")] // Marks the field as required, meaning it must be provided
        [Display(Name = "End Time")] // Display name for the view
        [DataType(DataType.Time)] // Specifies that this field is a time (for form rendering)
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)] // Specifies the format for time display (e.g., "05:00 PM")
        public DateTime AvailableEndTime { get; set; } // Stores the ending time of availability

        // The amount of time allocated for each patient during the doctor's availability.
        // This represents the typical consultation duration per patient (e.g., "30 minutes").
        [Required(ErrorMessage = "Time per patient is required.")] // Marks the field as required, meaning it must be provided
        [Display(Name = "Per Patient Time")] // Display name for the view
        public string TimePerPatient { get; set; } // Stores the time allocated per patient (e.g., "30 minutes")

        // The status of the schedule.
        // This can represent whether the schedule is active, inactive, or in any other state.
        [Required(ErrorMessage = "Status is required.")] // Marks the field as required, meaning it must be provided
        public string Status { get; set; } // Stores the current status of the schedule (e.g., "Active" or "Inactive")
    }
}
