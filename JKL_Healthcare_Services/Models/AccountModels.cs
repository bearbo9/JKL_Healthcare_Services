using System; // Imports basic system classes like String, DateTime, etc. which are used across .NET applications.
using System.Collections.Generic; // Provides support for generic collections like List<T>, Dictionary<TKey, TValue>, and ICollection<T>.
using System.ComponentModel.DataAnnotations; // Provides attributes for data validation and UI display, such as [Required], [EmailAddress], and [StringLength].
using System.Linq; // Enables LINQ (Language Integrated Query) functionality to query collections, though not directly used in this code.
using System.Web; // Provides classes for handling web-related operations, though not explicitly used here.
using System.Web.Mvc; // Imports the ASP.NET MVC classes, such as SelectListItem, used for binding data to dropdowns and other view-related operations.

namespace JKL_Healthcare_Services.Models // Defines the namespace for the models, grouping related classes for healthcare service models.
{
    public class AccountModels // Defines a class to encapsulate multiple view models used in account-related operations like login, registration, and password management.
    {
        // ViewModel for confirming an external login, typically used when logging in via third-party providers like Google or Facebook.
        public class ExternalLoginConfirmationViewModel
        {
            [Required] // Specifies that the Email field is mandatory.
            [Display(Name = "Email")] // Sets the display name for this property in the UI as "Email".
            public string Email { get; set; } // Stores the email address of the user.
        }

        // ViewModel for listing available external login providers and managing redirection upon successful login.
        public class ExternalLoginListViewModel
        {
            public string ReturnUrl { get; set; } // Holds the URL to redirect the user back to after a successful external login.
        }

        // ViewModel used for sending a security code to verify user identity during two-factor authentication.
        public class SendCodeViewModel
        {
            public string SelectedProvider { get; set; } // Stores the selected two-factor authentication provider (e.g., SMS, Email).
            public ICollection<SelectListItem> Providers { get; set; } // List of available authentication providers (e.g., SMS, Email), typically shown as a dropdown.
            public string ReturnUrl { get; set; } // Stores the URL to redirect the user back to after completing two-factor authentication.
            public bool RememberMe { get; set; } // Indicates whether the user opted to remember their login (persistent login).
        }

        // ViewModel used for verifying a code sent via two-factor authentication.
        public class VerifyCodeViewModel
        {
            [Required] // Specifies that the Provider field is mandatory.
            public string Provider { get; set; } // Stores the name of the two-factor authentication provider (e.g., SMS, Email).

            [Required] // Specifies that the Code field is mandatory.
            [Display(Name = "Code")] // Sets the display name for this property as "Code" in the UI.
            public string Code { get; set; } // Stores the code entered by the user for two-factor authentication.

            public string ReturnUrl { get; set; } // Stores the URL to redirect the user back to after successful code verification.

            [Display(Name = "Remember this browser?")] // Sets the display name for this property as "Remember this browser?" in the UI.
            public bool RememberBrowser { get; set; } // Indicates whether to remember the current browser for future two-factor authentication sessions.

            public bool RememberMe { get; set; } // Indicates whether the user opted for a persistent login (remember me functionality).
        }

        // ViewModel for submitting a forgotten password request.
        public class ForgotViewModel
        {
            [Required] // Specifies that the Email field is mandatory.
            [Display(Name = "Email")] // Sets the display name for this property as "Email" in the UI.
            public string Email { get; set; } // Stores the email address of the user for password recovery.
        }

        // ViewModel used for logging in a user.
        public class LoginViewModel
        {
            [Required] // Specifies that the Email field is mandatory.
            [Display(Name = "UserName")] // Sets the display name for this property as "UserName" in the UI.
            public string Email { get; set; } // Stores the username or email used for login.

            [Required] // Specifies that the Password field is mandatory.
            [DataType(DataType.Password)] // Specifies that this field should be treated as a password, masking input characters.
            [Display(Name = "Password")] // Sets the display name for this property as "Password" in the UI.
            public string Password { get; set; } // Stores the user's password for login.

            [Display(Name = "Remember me?")] // Sets the display name for this property as "Remember me?" in the UI.
            public bool RememberMe { get; set; } // Indicates whether the user opted for a persistent login (remember me functionality).
        }

        // ViewModel used for registering a new user.
        public class RegisterViewModel
        {
            [Required] // Specifies that the UserName field is mandatory.
            [Display(Name = "User Name")] // Sets the display name for this property as "User Name" in the UI.
            public string UserName { get; set; } // Stores the username chosen by the user.

            [Required] // Specifies that the FirstName field is mandatory.
            [Display(Name = "First Name")] // Sets the display name for this property as "First Name" in the UI.
            public string FirstName { get; set; } // Stores the user's first name.

            [Required] // Specifies that the LastName field is mandatory.
            [Display(Name = "Last Name")] // Sets the display name for this property as "Last Name" in the UI.
            public string LastName { get; set; } // Stores the user's last name.

            [Required] // Specifies that the Email field is mandatory.
            [EmailAddress] // Ensures that the value entered is a valid email address format.
            [Display(Name = "Email")] // Sets the display name for this property as "Email" in the UI.
            public string Email { get; set; } // Stores the user's email address.

            [Display(Name = "Select")] // Sets the display name for this property as "Select" in the UI, typically for selecting a user role.
            public string UserRole { get; set; } // Stores the role selected by the user (e.g., Admin, User).

            [Required] // Specifies that the Password field is mandatory.
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)] // Enforces a minimum password length of 6 characters.
            [DataType(DataType.Password)] // Specifies that this field should be treated as a password, masking input characters.
            [Display(Name = "Password")] // Sets the display name for this property as "Password" in the UI.
            public string Password { get; set; } // Stores the user's password.

            [DataType(DataType.Password)] // Specifies that this field should be treated as a password, masking input characters.
            [Display(Name = "Confirm password")] // Sets the display name for this property as "Confirm password" in the UI.
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] // Compares the ConfirmPassword field to the Password field to ensure they match.
            public string ConfirmPassword { get; set; } // Stores the user's confirmation password to ensure both password fields match.
        }

        // ViewModel used for resetting a forgotten password.
        public class ResetPasswordViewModel
        {
            [EmailAddress] // Ensures that the value entered is a valid email address format.
            [Display(Name = "Email")] // Sets the display name for this property as "Email" in the UI.
            public string Email { get; set; } // Stores the user's email for password reset purposes.

            [Required] // Specifies that the Password field is mandatory.
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)] // Enforces a minimum password length of 6 characters.
            [DataType(DataType.Password)] // Specifies that this field should be treated as a password, masking input characters.
            [Display(Name = "Password")] // Sets the display name for this property as "Password" in the UI.
            public string Password { get; set; } // Stores the new password chosen by the user.

            [DataType(DataType.Password)] // Specifies that this field should be treated as a password, masking input characters.
            [Display(Name = "Confirm password")] // Sets the display name for this property as "Confirm password" in the UI.
            [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] // Compares the ConfirmPassword field to the Password field to ensure they match.
            public string ConfirmPassword { get; set; } // Stores the confirmation password.

            public string Code { get; set; } // Stores the password reset token/code used for password recovery.
        }

        // ViewModel for handling forgot password requests.
        public class ForgotPasswordViewModel
        {
            [Required] // Specifies that the Email field is mandatory.
            [EmailAddress] // Ensures that the value entered is a valid email address format.
            [Display(Name = "Email")] // Sets the display name for this property as "Email" in the UI.
            public string Email { get; set; } // Stores the email address of the user requesting a password reset.
        }
    }
}


