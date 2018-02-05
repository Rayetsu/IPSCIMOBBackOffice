using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IPSCIMOBBackOffice
{
    public class RequiredRule : ValidationRule
    {
        public override ValidationResult Validate
          (object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "O campo não pode estar vazio");
            }
            else
            {

                return ValidationResult.ValidResult;
            }
        }
    }
}