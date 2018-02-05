using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IPSCIMOBBackOffice
{
    public class EstadoCandidaturaRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            bool isValido = int.TryParse(value.ToString(), out int estado);

            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "O estado não pode estar vazio");
            }
            else if (!isValido)
            {
                return new ValidationResult(false, string.Format("O Estado tem de ser um número inteiro!"));
            }
            else if (estado < 0 || estado > 9)
                return new ValidationResult(false, string.Format("O Estado tem de ser de 0 à 9!"));
            else
            {

                return ValidationResult.ValidResult;
            }
        }
    }
}
