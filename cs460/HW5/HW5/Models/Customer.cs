using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Customer Number")]
        public int CustomerNumber { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Required, StringLength(300)]
        [Display(Name = "New Address")]
        public string NewAddress { get; set; }

        [Required, StringLength(80)]
        [Display(Name = "City")]
        public string NewCity { get; set; }

        [Required, StringLength(80)]
        [Display(Name = "State")]
        public string NewState { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public int NewZip { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "County")]
        public string NewCounty { get; set; }

        [Required]
        [Display(Name = "Date of Change")]
        public DateTime ChangeDate { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {MiddleName} {LastName} DOB = {DOB}";
        }
    }
}