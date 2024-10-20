// Required namespaces for the model
using System; // Provides basic functionalities like DateTime
using System.Collections.Generic; // Allows the use of collections (though not used in this class)
using System.ComponentModel.DataAnnotations; // Provides data annotation attributes like [Display], [DataType], and [DisplayFormat]
using System.Linq; // Allows LINQ functionalities
using System.Web; // Contains classes for web-related operations

namespace JKL_Healthcare_Services.Models
{
    // The Appointment class represents an appointment between a patient and a doctor.
    public class Appointment
    {
        // Primary key for the appointment.
        public int Id { get; set; }

        // Navigation property to the Patient entity.
        // This is a reference to the patient associated with the appointment.
        public Patient Patient { get; set; }

        // Foreign key to the Patient entity.
        // This links the appointment to a specific patient.
        [Display(Name = "Patient Name")] // Display name for the view
        public int PatientId { get; set; } // Foreign key (FK) reference for the Patient

        // Navigation property to the Doctor entity.
        // This is a reference to the doctor associated with the appointment.
        public Doctor Doctor { get; set; }

        // Foreign key to the Doctor entity.
        // This links the appointment to a specific doctor.
        [Display(Name = "Doctor Name")] // Display name for the view
        public int DoctorId { get; set; } // Foreign key (FK) reference for the Doctor

        // Date of the appointment.
        [Display(Name = "Appointment Date")] // Display name for the view
        [DataType(DataType.Date)] // Specifies that this field is a date (for form rendering)
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Format for displaying the date in a "yyyy-MM-dd" format
        public DateTime? AppointmentDate { get; set; } // Nullable to allow for cases where an appointment date might not be set

        // Description of the patient's problem or reason for the appointment.
        public string Problem { get; set; } // Brief description of the medical issue or concern

        // Status of the appointment.
        // True could mean the appointment is confirmed, and false could mean it's pending or cancelled.
        public bool Status { get; set; } // Boolean to track whether the appointment is confirmed (True) or not (False)
    }
}
