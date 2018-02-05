using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IPSCIMOBBackOffice
{
    public class EstadoEntrevistaRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            bool isValido = int.TryParse(value.ToString(), out int estado);

            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "O estado não pode estar vazio");
            }else if (!isValido) { 
                return new ValidationResult(false, string.Format("O Estado tem de ser um número inteiro!"));
            }else if (estado < 0 || estado > 3)
                return new ValidationResult(false, string.Format("O Estado tem de ser 0, 1, 2 ou 3!"));
            else
            {

                return ValidationResult.ValidResult;
            }
        }
    }
}
