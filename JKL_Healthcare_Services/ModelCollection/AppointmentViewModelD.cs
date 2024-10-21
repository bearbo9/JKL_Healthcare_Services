using JKL_Healthcare_Services.Models; // Imports the models used in the healthcare service application, specifically the Appointment model.
using System; // Provides fundamental classes and base types used in the application.
using System.Collections.Generic; // Enables the use of generic collections like lists, which are useful for managing collections of objects.
using System.Linq; // Provides LINQ (Language-Integrated Query) capabilities for querying collections and working with data.
using System.Web; // Contains classes related to web applications, though not directly utilized in this model.

namespace JKL_Healthcare_Services.ModelCollection // Defines a namespace to group related classes that handle view models within the healthcare service application.
{
    // AppointmentViewModelD class is designed to hold a collection of appointment data 
    // that can be used in views for displaying or managing appointments.
    public class AppointmentViewModelD
    {
        // A list of Appointment objects that represents multiple appointments.
        // This property will be used to store and manipulate appointment data 
        // as needed by the associated views or controllers.
        public List<Appointment> Appointments { get; set; }
    }
}
