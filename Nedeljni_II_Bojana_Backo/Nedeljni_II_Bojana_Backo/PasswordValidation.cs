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
        public static bool PasswordOk(string passWord)
        {

            int validConditions = 0;

            foreach (char c in passWord)

            {

                if (c >= 'a' && c <= 'z')

                {

                    validConditions++;

                    break;

                }

            }

            foreach (char c in passWord)

            {

                if (c >= 'A' && c <= 'Z')

                {

                    validConditions++;

                    break;

                }

            }

            if (validConditions == 0) return false;

            foreach (char c in passWord)

            {

                if (c >= '0' && c <= '9')

                {

                    validConditions++;

                    break;

                }

            }

            if (validConditions == 1) return false;

            if (validConditions == 2)

            {

                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' }; // or whatever

                if (passWord.IndexOfAny(special) == -1) return false;

            }

            return true;

        }
    }
}
