using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Presentation.Utils.Validations
{
    public static class InputValidation
    {
        public static bool IsValidOption(int maxRange, string input)
        {
            try
            {
                int selectedValue = Convert.ToInt32(input);

                if (selectedValue <= 0 || selectedValue > maxRange)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidDate(string inputType, string userInput)
        {
            DateTime date;
            if (inputType == "NotMandatory" && userInput == String.Empty)
            {
                return true;
            }
            else if (DateTime.TryParse(userInput, out date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidEmpID(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]) && !Char.IsNumber(input[i])) return false;
            }
            return true;
        }


        public static bool IsValidMail(string input)
        {
            string mailRegex = @"(^[a-z 0-9]+[.]{0,1}[a-z 0-9]+@[a-z]+.com)";
            Regex re = new Regex(mailRegex);
            if (re.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidName(string inputType, string input)
        {
            if (inputType == "NotMandatory" && input == String.Empty)
            {
                return true;
            }
            if (input.Length < 3)
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]) && input[i] != ' ') return false;
            }
            return true;

        }


        public static bool IsValidPhno(string input)
        {
            string phnoRegex = @"(^[0-9]{10})";
            Regex re = new Regex(phnoRegex);
            if (re.IsMatch(input) || input == String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidYesNoInput(string input)
        {
            try
            {
                char selectedInput = Convert.ToChar(input);
                if (selectedInput == 'Y' || selectedInput == 'N')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
