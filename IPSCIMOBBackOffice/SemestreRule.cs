using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IPSCIMOBBackOffice
{
    public class SemestreRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            bool isValido = int.TryParse(value.ToString(), out int estado);

            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "O semestre não pode estar vazio");
            }
            else if (!isValido)
            {
                return new ValidationResult(false, string.Format("O Semestre tem de ser um número inteiro!"));
            }
            else if (estado < 0 || estado > 1)
                return new ValidationResult(false, string.Format("O Semestre tem de ser 0 ou 1!"));
            else
            {

                return ValidationResult.ValidResult;
            }
        }
    }
}
