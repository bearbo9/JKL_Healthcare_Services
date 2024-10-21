using JKL_Healthcare_Services.Models; // Imports the models used in the healthcare service application, such as Appointment, Patient, and Doctor.
using System; // Provides fundamental classes and base types.
using System.Collections.Generic; // Enables the use of generic collections like lists and enumerables.
using System.Linq; // Enables LINQ (Language-Integrated Query) for querying collections.
using System.Web; // Contains classes for web applications, though not directly used in this class.

namespace JKL_Healthcare_Services.ModelCollection // Defines a namespace for grouping related classes that manage collections of healthcare-related entities.
{
    // The AppointmentsCollection class serves as a container for managing appointments along with their associated patients and doctors.
    public class AppointmentsCollection
    {
        // Represents a single appointment instance, linking to the specific Appointment model.
        public Appointment Appointment { get; set; }

        // A collection of patients associated with the appointment. This uses IEnumerable for flexibility in managing the list of patients.
        public IEnumerable<Patient> Patients { get; set; }

        // A collection of doctors who may be associated with the appointment. Like Patients, it uses IEnumerable for flexible management.
        public IEnumerable<Doctor> Doctors { get; set; }

        // Constructor can be added here if needed to initialize the collections or perform setup tasks.

        // Additional methods for managing appointments, such as adding or removing patients and doctors, 
        // could be implemented here for enhanced functionality.
    }
}
