﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace Presentation.ViewModel.AdditionalInterfaces
{
   public class StringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value cannot be coverted to string.");
            bool canConvert = false;
            
            
          
                    canConvert =(strValue.Length<30);
                    return canConvert ? new ValidationResult(true, null) : new ValidationResult(false, $"Input should be type of string and less then 30 characters");
       
        }
    }
}
