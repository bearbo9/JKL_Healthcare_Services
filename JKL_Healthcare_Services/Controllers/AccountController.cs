// Import necessary namespaces
using JKL_Healthcare_Services.Models; // Contains application models
using System; // Provides basic functionalities
using System.Collections.Generic; // Allows the use of collections
using System.Linq; // Provides LINQ functionalities
using System.Net; // Allows handling network operations
using System.Threading.Tasks; // Supports asynchronous programming
using static JKL_Healthcare_Services.Models.AccountModels;
using static JKL_Healthcare_Services.Models.Dbcontext;
using System.Web; // Contains classes for the web
using System.Web.Mvc; // Provides MVC functionalities
using System.Data.Entity; // Provides database context functionalities for Entity Framework
using Microsoft.AspNet.Identity; // Provides identity functionalities for managing users
using Microsoft.AspNet.Identity.Owin; // Provides OWIN context-based identity management
using static JKL_Healthcare_Services.App_Start.UserAuthConfig;
using Microsoft.Owin.Security; // Provides security-related functionalities for OWIN

namespace JKL_Healthcare_Services.Controllers // Define the namespace for the controller
{
    // AccountController handles user authentication and account management
    public class AccountController : Controller
    {
        private ApplicationDbContext db; // Database context for accessing data
        private ApplicationSignInManager _signInManager; // Manager for sign-in operations
        private ApplicationUserManager _userManager; // Manager for user operations

        // Default constructor initializes the database context
        public AccountController()
        {
            db = new ApplicationDbContext(); // Initialize the database context
        }

        // Constructor that allows dependency injection for user and sign-in managers
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager; // Set user manager
            SignInManager = signInManager; // Set sign-in manager
        }

        // Property to get or set the sign-in manager
        public ApplicationSignInManager SignInManager
        {
            get
            {
                // Return the sign-in manager from Owin context if not already set
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value; // Set the sign-in manager
            }
        }

        // Property to get or set the user manager
        public ApplicationUserManager UserManager
        {
            get
            {
                // Return the user manager from Owin context if not already set
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value; // Set the user manager
            }
        }

        // GET: /Account/Login - Renders the login view
        [AllowAnonymous] // Allow access to unauthenticated users
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl; // Store the return URL in ViewBag for later use
            return View(); // Return the login view
        }

        // POST: /Account/Login - Handles the login form submission
        [HttpPost] // Indicates this method responds to POST requests
        [AllowAnonymous] // Allow access to unauthenticated users
        [ValidateAntiForgeryToken] // Protect against cross-site request forgery
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) // Check if the model state is valid
            {
                return View(model); // Return the view with the model if invalid
            }

            // Attempt to sign in the user with the provided email and password
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result) // Handle the result of the sign-in attempt
            {
                case SignInStatus.Success: // Sign-in was successful
                    // Find the user by email and password
                    var user = await UserManager.FindAsync(model.Email, model.Password);

                    // Redirect based on the user's role
                    if (UserManager.IsInRole(user.Id, "Admin"))
                    {
                        return RedirectToAction("Index", "Admin"); // Redirect to Admin dashboard
                    }
                    else if (UserManager.IsInRole(user.Id, "Doctor"))
                    {
                        return RedirectToAction("Index", "Doctor"); // Redirect to Doctor dashboard
                    }
                    else if (UserManager.IsInRole(user.Id, "Patient")) // If the user is a patient
                    {
                        // Find the corresponding patient record
                        var patient = db.Patients.Single(c => c.ApplicationUserId == user.Id);

                        // Check if the patient's profile is complete
                        if (patient.BloodGroup == null || patient.Contact == null || patient.Gender == null)
                        {
                            return RedirectToAction("UpdateProfile", "Patient", new { id = user.Id }); // Prompt to update profile
                        }
                        else
                        {
                            return RedirectToAction("Index", "Patient"); // Redirect to Patient dashboard
                        }
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl); // Redirect to return URL if no specific role matched
                    }

                case SignInStatus.Failure: // Sign-in failed
                default:
                    ModelState.AddModelError("", "Invalid login attempt."); // Add error to model state
                    return View(model); // Return the view with the model
            }
        }

        // GET: /Account/Register - Renders the registration view
        [AllowAnonymous] // Allow access to unauthenticated users
        public ActionResult Register()
        {
            return View(); // Return the registration view
        }

        // POST: /Account/Register - Handles the registration form submission
        [HttpPost] // Indicates this method responds to POST requests
        [AllowAnonymous] // Allow access to unauthenticated users
        [ValidateAntiForgeryToken] // Protect against cross-site request forgery
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                // Create a new user object from the provided registration details
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    // Add other user properties here
                };

                var result = await UserManager.CreateAsync(user, model.Password); // Create user asynchronously

                if (result.Succeeded) // If user creation succeeded
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false); // Sign in the user
                    return RedirectToAction("Index", "Home"); // Redirect to home page
                }
                AddErrors(result); // Add errors to model state if creation failed
            }
            return View(model); // Return the view with the model
        }

        // Method to handle errors and add them to the ModelState
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors) // Iterate through each error
            {
                ModelState.AddModelError("", error); // Add error to model state
            }
        }

        // Helper method to redirect to the local URL or home if the return URL is invalid
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl)) // Check if the return URL is local
            {
                return Redirect(returnUrl); // Redirect to the return URL
            }
            return RedirectToAction("Index", "Home"); // Redirect to home page if the return URL is not valid
        }

        // Other methods (e.g., Logout, ConfirmEmail, etc.) would go here...
    }
}
