using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaterDeligate
{
    public class ValidateStudent
    {
        public static bool ValidateNameMethod(string name) {

            if (name.Length<25 && name.Length>2) {
                return true;            
            }

            return false;
        }

       

        public static bool ValidateRollNoMethod(int rollNo)
        {

            if (rollNo< 1000 && rollNo> 0)
            {
                return true;
            }

            return false;
        }

    }
}
