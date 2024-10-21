using JKL_Healthcare_Services.Models; // Imports the models from the healthcare service application, which includes entities like Prescription and Patient.
using System; // Provides fundamental classes and base types used throughout the application.
using System.Collections.Generic; // Enables the use of generic collections such as lists, which are useful for storing multiple objects.
using System.Linq; // Provides LINQ (Language-Integrated Query) functionalities for querying collections and data manipulation.
using System.Web; // Contains classes for managing HTTP requests and responses, although not directly utilized in this model.

namespace JKL_Healthcare_Services.ModelCollection // Defines a namespace to group related classes that handle view models in the healthcare service application.
{
    // The CollectionPrescription class is designed to hold data related to prescriptions
    // and the list of patients associated with those prescriptions.
    public class CollectionPrescription
    {
        // Property to store information about a prescription,
        // which includes details such as the doctor, patient, medication, and dosage.
        public Prescription Prescription { get; set; }

        // Property to store a list of patients,
        // which may be related to the prescription for managing and tracking patient medications.
        public List<Patient> Patients { get; set; }
    }
}
