using JKL_Healthcare_Services.Models; // Imports the models used in the healthcare service application, including account models and doctor information.
using System; // Provides fundamental classes and base types used in the application.
using System.Collections.Generic; // Enables the use of generic collections like lists, dictionaries, etc., which are useful for managing collections of objects.
using System.Linq; // Provides LINQ (Language-Integrated Query) capabilities for querying collections and working with data.
using System.Web; // Contains classes related to web applications, though not directly utilized in this model.
using static JKL_Healthcare_Services.Models.AccountModels; // Imports static members from AccountModels, allowing direct access to its properties or methods without specifying the class name.

namespace JKL_Healthcare_Services.ModelCollection // Defines a namespace to group related classes that handle view models within the healthcare service application.
{
    // The CollectionDoctors class is designed to hold data related to doctors
    // and their associated application user (registration) information.
    public class CollectionDoctors
    {
        // Property to store application user information,
        // specifically the registration view model that includes details about the user.
        public RegisterViewModel ApplicationUser { get; set; }

        // Property to store information about a doctor,
        // which includes medical and professional details pertinent to the healthcare service.
        public Doctor Doctor { get; set; }
    }
}
