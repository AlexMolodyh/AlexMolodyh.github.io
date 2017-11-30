using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW8.Models
{
    public class DateValidationAtt : ValidationAttribute
    {

        /*Validates the date entered so that it's not in the future*/
        public override bool IsValid(object value)
        {
            DateTime dt = Convert.ToDateTime(value);
            return dt < DateTime.Now;
        }
    }
}