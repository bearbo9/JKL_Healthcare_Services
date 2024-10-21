using System; // Provides fundamental types and functionality for .NET applications.
using System.Collections.Generic; // Provides support for generic collections like lists and dictionaries.
using System.Linq; // Provides LINQ functionalities for querying collections.
using System.Web; // Provides classes and methods for working with web applications.

namespace JKL_Healthcare_Services.Models // Namespace for grouping related classes and functionalities for the healthcare application.
{
    public class UserRoles // Class to define various user roles within the application.
    {
        // Constant string representing the Admin role, which has the highest level of permissions.
        public const string Admin = "Admin";

        // Constant string representing the Doctor role, which allows access to patient management features.
        public const string Doctor = "Doctor";

        // Constant string representing the Patient role, which allows access to personal health information.
        public const string Patient = "Patient";
    }
}
