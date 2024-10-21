using JKL_Healthcare_Services.Models; // Imports the models from the healthcare service application, which includes entities like Schedule and Doctor.
using System; // Provides fundamental classes and base types used throughout the application.
using System.Collections.Generic; // Enables the use of generic collections such as lists and enumerable collections.
using System.Linq; // Provides LINQ (Language-Integrated Query) functionalities for querying collections and data manipulation.
using System.Web; // Contains classes for managing HTTP requests and responses, although not directly utilized in this model.

namespace JKL_Healthcare_Services.ModelCollection // Defines a namespace to group related classes for view models in the healthcare service application.
{
    // The CollectionsSchedule class is designed to hold data related to a schedule
    // and the list of doctors associated with that schedule.
    public class CollectionsSchedule
    {
        // Property to store information about a specific schedule,
        // which includes details such as available time slots for doctors.
        public Schedule Schedule { get; set; }

        // Property to store a collection of doctors,
        // which allows for displaying or managing multiple doctors
        // that may be associated with the schedule.
        public IEnumerable<Doctor> Doctors { get; set; }
    }
}
