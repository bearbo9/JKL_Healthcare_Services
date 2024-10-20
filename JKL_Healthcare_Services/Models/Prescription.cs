using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JKL_Healthcare_Services.Models
{
    public class Prescription
    {
        // Unique identifier for the prescription
        public int Id { get; set; }

        // Navigation property to associate the prescription with the doctor who prescribed it
        public Doctor Doctor { get; set; }

        // Foreign key for the doctor's unique identifier
        public int DoctorId { get; set; }

        // The name of the doctor who issued the prescription
        public string DoctorName { get; set; }

        // The specialization of the doctor for reference
        public string DoctorSpecialization { get; set; }

        // Navigation property to associate the prescription with the patient
        public Patient Patient { get; set; }

        // Foreign key for the patient's unique identifier
        [Display(Name = "Patient Name")]
        public int PatientId { get; set; }

        // Username of the patient, if applicable
        public string UserName { get; set; }

        // The name of the patient for display purposes
        public string PatientName { get; set; }

        // The gender of the patient, to provide demographic information
        public string PatientGender { get; set; }

        // The age of the patient, useful for dosage and treatment considerations
        public string PatientAge { get; set; }

        // Medical tests recommended or performed for the patient
        [Display(Name = "Medical Tests")]
        public string MedicalTest1 { get; set; }
        public string MedicalTest2 { get; set; }
        public string MedicalTest3 { get; set; }
        public string MedicalTest4 { get; set; }

        // The first prescribed medicine
        [Display(Name = "Medicine")]
        public string Medicine1 { get; set; }

        // Boolean properties to indicate the timing for taking the first medicine
        [Display(Name = " ")]
        public bool Morning1 { get; set; } // Indicates if taken in the morning
        public bool Afternoon1 { get; set; } // Indicates if taken in the afternoon
        public bool Evening1 { get; set; } // Indicates if taken in the evening

        // The second prescribed medicine
        public string Medicine2 { get; set; }
        public bool Morning2 { get; set; }
        public bool Afternoon2 { get; set; }
        public bool Evening2 { get; set; }

        // The third prescribed medicine
        public string Medicine3 { get; set; }
        public bool Morning3 { get; set; }
        public bool Afternoon3 { get; set; }
        public bool Evening3 { get; set; }

        // The fourth prescribed medicine
        public string Medicine4 { get; set; }
        public bool Morning4 { get; set; }
        public bool Afternoon4 { get; set; }
        public bool Evening4 { get; set; }

        // The fifth prescribed medicine
        public string Medicine5 { get; set; }
        public bool Morning5 { get; set; }
        public bool Afternoon5 { get; set; }
        public bool Evening5 { get; set; }

        // The sixth prescribed medicine
        public string Medicine6 { get; set; }
        public bool Morning6 { get; set; }
        public bool Afternoon6 { get; set; }
        public bool Evening6 { get; set; }

        // The seventh prescribed medicine
        public string Medicine7 { get; set; }
        public bool Morning7 { get; set; }
        public bool Afternoon7 { get; set; }
        public bool Evening7 { get; set; }

        // Number of days after which the patient should return for a check-up
        [Display(Name = "Checkup After Days")]
        public int CheckUpAfterDays { get; set; }

        // Date when the prescription was added to the system
        public DateTime PrescriptionAddDate { get; set; }

        // Timing details of the doctor, could include availability or working hours
        public string DoctorTiming { get; set; }
    }
}
