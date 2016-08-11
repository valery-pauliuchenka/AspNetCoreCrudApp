using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCrudApp.Web.Attributes
{
    public class CategoryIsRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int parsedValue = value is int ? (int)value : 0;

            if (parsedValue < 1)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Category must be chosen.";
        }
    }
}
