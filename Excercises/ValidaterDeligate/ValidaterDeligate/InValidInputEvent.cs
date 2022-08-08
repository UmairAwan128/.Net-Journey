using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaterDeligate
{
    public class InValidInputEvent : EventArgs
    {
        public InValidInputEvent(){

        }
        public void InValidInput() {
           Console.WriteLine("\nInvalid Input\n");
        }
    }
}
