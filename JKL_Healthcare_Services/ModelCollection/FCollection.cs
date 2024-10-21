using JKL_Healthcare_Services.Models; // Imports the necessary models from the healthcare service application.
using System; // Provides fundamental classes and base types used in the application.
using System.Collections.Generic; // Enables the use of generic collections for managing multiple objects.
using System.Linq; // Provides LINQ (Language-Integrated Query) functionalities for querying collections and data manipulation.
using System.Web; // Contains classes for handling HTTP requests and web application-related functionalities.

namespace JKL_Healthcare_Services.ModelCollection // Declares a namespace to group related classes, specifically for view models in the healthcare service application.
{
    // The FCollection class serves as a data structure to group and manage collections 
    // of various entities within the healthcare service application.
    public class FCollection
    {
        // Property to store a collection of Doctor objects, representing all doctors in the system.
        // This allows for easy access and management of doctor-related information.
        public IEnumerable<Doctor> Doctors { get; set; }

        // Property to store a collection of Patient objects, representing all patients in the system.
        // This facilitates managing patient-related information and operations.
        public IEnumerable<Patient> Patients { get; set; }

        // Property to store a collection of Medicine objects, representing all medicines available in the system.
        // This aids in managing and accessing medicine-related information.
        public IEnumerable<Medicine> Medicines { get; set; }

        // Property to store a collection of currently active Appointment objects.
        // This is useful for tracking appointments that are ongoing or have been confirmed.
        public IEnumerable<Appointment> ActiveAppointments { get; set; }

        // Property to store a collection of pending Appointment objects.
        // This is important for tracking appointments that have been requested but not yet confirmed.
        public IEnumerable<Appointment> PendingAppointments { get; set; }
    }
}
