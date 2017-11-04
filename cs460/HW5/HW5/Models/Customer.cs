using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/**
 * Author: Alex Molodyh
 * Date: 11/3/2017
 * Class: CS460
 * Assignment: HWK5
 **/

namespace HW5.Models
{
    // compile with: /doc:DocFileName.xml 

    public class Customer
    {
        public int ID { get; set; }

        /// <summary>
        /// CustomerNumber represents an ID, License, or any type of identification number for a person.
        /// </summary>
        [Required, RegularExpression("([0-9]{7})", ErrorMessage = "Customer # must be 7 digits")]
        [Display(Name = "Customer #")]
        public int CustomerNumber { get; set; }

        /// <summary>
        /// A customers first name.
        /// </summary>
        [Required, StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// A customers middle name that is not required for the form.
        /// </summary>
        [StringLength(100)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// A customers last name that is required for an address change.
        /// </summary>
        [Required, StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// A customers date of birth that is required for an address change.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        /// <summary>
        /// The customers new address that is required for an address change.
        /// </summary>
        [Required, StringLength(300)]
        [Display(Name = "New Address")]
        public string NewAddress { get; set; }

        /// <summary>
        /// The city for the new address that is required for an address change.
        /// </summary>
        [Required, StringLength(80)]
        [Display(Name = "City")]
        public string NewCity { get; set; }

        /// <summary>
        /// The US state for the new address that is required for an address change.
        /// </summary>
        [Required, StringLength(2)]
        [Display(Name = "State")]
        public string NewState { get; set; }

        /// <summary>
        /// The zip code for the new address that is required for an address change.
        /// </summary>
        [Required, RegularExpression("([0-9]{5})", ErrorMessage = "Zip code must be 5 digits")]
        [Display(Name = "Zip Code")]
        public int NewZip { get; set; }

        /// <summary>
        /// The county for the new address that is required for an address change.
        /// </summary>
        [Required, StringLength(50)]
        [Display(Name = "County")]
        public string NewCounty { get; set; }

        /// <summary>
        /// The date of the address change that is required for an address change.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Date of Change")]
        public DateTime ChangeDate { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {MiddleName} {LastName} DOB = {DOB}";
        }
    }
}