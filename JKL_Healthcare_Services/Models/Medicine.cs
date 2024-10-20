using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JKL_Healthcare_Services.Models
{
    // Represents a medicine that can be prescribed or administered to patients.
    public class Medicine
    {
        // Gets or sets the unique identifier for the medicine.
        // This is typically used as the primary key in the database.
        public int Id { get; set; }

        // Gets or sets the name of the medicine.
        // This field is required and must be provided by the user.
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        // Gets or sets the description of the medicine.
        // This field provides additional information about the medicine, including its uses and effects.
        // It is required for better understanding and record-keeping.
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        // Gets or sets the quantity of the medicine available.
        // This field is required to manage inventory effectively.
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        // Gets or sets the price of the medicine.
        // This field is required and must be a positive value to ensure proper billing and cost tracking.
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public double Price { get; set; }
    }
}
