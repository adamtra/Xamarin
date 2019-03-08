using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Wizytówki.Validators
{
    public static class ValidatorRules
    {
        public static bool EmailValidation(string value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(str);

            return match.Success;
        }

        public static bool IsNotNullOrEmpty(string value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            return !string.IsNullOrWhiteSpace(str);
        }

        public static bool PhoneNumberValidation(string value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            Regex regex = new Regex("^[0-9]{3}[-][0-9]{3}[-][0-9]{3}$");
            Match match = regex.Match(str);

            return match.Success;
        }
    }
}
