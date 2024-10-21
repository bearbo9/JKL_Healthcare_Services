using JKL_Healthcare_Services.Models; // Import custom models defined for the healthcare application.
using Microsoft.AspNet.Identity; // Provides functionalities for user authentication and identity management.
using Microsoft.AspNet.Identity.EntityFramework; // Provides IdentityUser and IdentityDbContext classes for ASP.NET Identity.
using System; // Provides fundamental types like DateTime, etc.
using System.Collections.Generic; // Provides support for generic collections like lists.
using System.Data.Entity; // Required for working with Entity Framework's DbContext and DbSet.
using System.Security.Claims; // Provides classes to handle user claims for authentication and authorization.
using System.Threading.Tasks; // Supports asynchronous operations like the async method for generating user identity.

namespace JKL_Healthcare_Services.Models // Namespace for grouping related classes and functionalities for JKL Healthcare Services.
{
    public class Dbcontext
    {

        // The ApplicationUser class extends IdentityUser to include additional custom properties for users of the system.
        public class ApplicationUser : IdentityUser // Inherits from IdentityUser, which provides basic user-related properties and methods.
        {
            // Custom property to store the role of the user (e.g., "Admin", "Doctor", "Patient").
            public string UserRole { get; set; }

            // Property to store the date and time when the user registered in the system.
            public DateTime RegisteredDate { get; set; }

            // Asynchronously generates a ClaimsIdentity object for the user, containing the necessary authentication information.
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Create a ClaimsIdentity using the ApplicationCookie authentication type, which is used for cookie-based authentication.
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

                // Custom claims can be added here if needed (e.g., user role claims or additional user-specific claims).
                // Example: userIdentity.AddClaim(new Claim(ClaimTypes.Role, this.UserRole));

                // Return the generated ClaimsIdentity object for the user.
                return userIdentity;
            }
        }

        // The ApplicationDbContext class manages the database operations and maps the models to database tables using Entity Framework.
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser> // Inherits from IdentityDbContext to integrate with ASP.NET Identity.
        {
            // Define a DbSet for the Medicine model, which represents the Medicines table in the database.
            public DbSet<Medicine> Medicines { get; set; }

            // Define a DbSet for the Patient model, representing patients in the system.
            public DbSet<Patient> Patients { get; set; }

            // Define a DbSet for the Doctor model, representing doctors in the healthcare system.
            public DbSet<Doctor> Doctors { get; set; }

            // Define a DbSet for the Schedule model, representing the schedule of doctors or appointments.
            public DbSet<Schedule> Schedules { get; set; }

            // Define a DbSet for the Prescription model, representing medical prescriptions.
            public DbSet<Prescription> Prescriptions { get; set; }

            // Define a DbSet for the Appointment model, representing appointments between patients and doctors.
            public DbSet<Appointment> Appointments { get; set; }

            // Add a DbSet for Roles to manage roles within the application.
            public DbSet<Roles> Role { get; set; } // Represents roles in the healthcare system.



            // Constructor for the ApplicationDbContext, calling the base class constructor to set the database connection.
            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false) // Uses the "DefaultConnection" string and prevents legacy schema usage.
            {
                // Empty constructor - the connection string "DefaultConnection" should be defined in Web.config or appsettings.json.
            }

            // Static factory method to create and return an instance of ApplicationDbContext.
            // This is useful when creating a new context instance where required (e.g., in controllers).
            public static ApplicationDbContext Create()
            {
                // Return a new instance of ApplicationDbContext for use.
                return new ApplicationDbContext();
            }
        }
    }
}
