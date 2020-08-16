using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_II_Bojana_Backo
{
    // Class for Password validation
    public static class PasswordValidation
    {
        public static bool PasswordOk(string password)
        {
            int minUpper = 1;
            int minLower = 1;
            int minLength = 8;
            int minNumber = 1;
            int minSpecial = 1;
            char[] special = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '-', '[', ']', '{', '}', '|', ';', ':', '?', '/', '<', '>', ',', '.' };

            // get individual characters
            char[] characters = password.ToCharArray();

            // checking variables
            int upper = 0;
            int length = password.Length;
            int lower = 0;
            int number = 0;
            int specialChar = 0;

            // check the entered password
            foreach (char enteredCharacter in characters)
            {
                if (char.IsUpper(enteredCharacter))
                {
                    upper = upper + 1;
                }
                if (char.IsLower(enteredCharacter))
                {
                    lower = lower + 1;
                }
                if (char.IsDigit(enteredCharacter))
                {
                    number = number + 1;
                }
                for (int i = 0; i < special.Length; i++)
                {
                    if (enteredCharacter == (special[i]))
                    {
                        specialChar = specialChar + 1;
                    }
                }
            }
            if (upper < minUpper || length < minLength || specialChar < minSpecial
                    || number < minNumber || length < minLength || lower < minLower)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
