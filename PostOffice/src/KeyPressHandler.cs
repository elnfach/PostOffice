using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostOffice.src
{
    internal class KeyPressHandler
    {
        int comma_counter;

        public KeyPressHandler()
        {
            comma_counter = 0;
        }

        public bool CheckKeyPressed(char number)
        {
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                return true;
            }
            
            return false;
        }
    }
}
