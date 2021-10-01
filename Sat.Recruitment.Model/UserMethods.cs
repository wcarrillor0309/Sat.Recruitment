using System;

namespace Sat.Recruitment.Model
{
    public sealed partial class User
    {

        /// <summary>
        /// Validate that user data is not null or empty
        /// </summary>
        /// <returns>returns list of errors</returns>
        public static string ValidateErrors
        (
              string name
            , string email
            , string address
            , string phone
            , string money
        )
        {
            var errors = string.Empty;

            if (string.IsNullOrEmpty(name)) errors = "The name is required";
            if (string.IsNullOrEmpty(email)) errors += " The email is required";
            if (string.IsNullOrEmpty(address)) errors += " The address is required";
            if (string.IsNullOrEmpty(phone)) errors += " The phone is required";
            if (!decimal.TryParse
                (money, out _)
               ) errors += " The money is not numeric";

            return errors;
        }

        /// <summary>
        /// The percentage calculation is made
        /// </summary>
        /// <returns>retorna el porcentaje calculado</returns>
        private decimal GetPercentage(decimal value)
        {
            decimal dPercentage = (UserType.Equals("Normal") && value > 10M && value < 100M) ? 0.8M : 0M;

            if (dPercentage > 0M || value < 100M) return dPercentage;

            // Todo lo Mayor a 100
            switch (UserType)
            {
                case "Normal":
                    dPercentage = 0.12M;
                    break;
                case "SuperUser":
                    dPercentage = 0.20M;
                    break;
                default: // premium
                    dPercentage = 2M;
                    break;
            }

            return dPercentage;

        }

        private decimal getMoneyFromUserType(decimal value)
        {
            return value + (value * GetPercentage(value));
        }

        private string NormalizeEmail(string semail)
        {
            var aux = semail.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

    }
}


