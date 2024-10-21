namespace JKL_Healthcare_Services.Models
{
    public class Roles // Remove static nature to allow instantiation
    {
        // Properties for the Roles class
        public int Id { get; set; } // Assuming you'll need a key
        public string Role { get; set; } // Property for role name

        // Constants representing role names
        public const string Admin = "Admin";
        public const string Doctor = "Doctor";
        public const string Patient = "Patient";
    }
}
