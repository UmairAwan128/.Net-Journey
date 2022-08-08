using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    //we can inherit from any exception class but it is suggested to inherit from Application Exception so
    public class DivideByOddNumberException : ApplicationException
    {

        //now iverride here message property
        public override string Message {
            get {
                return "Attempted to Divide by Odd Number.";
            }
        }
        //we can create such exception classes in our project and call them when needed
    }
}
