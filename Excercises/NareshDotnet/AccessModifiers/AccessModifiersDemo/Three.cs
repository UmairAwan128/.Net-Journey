using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiersDemo
{
    class Three
    {
        //here we consume members of the Program class by creating instance of that class i.e in the same project
        //here public, internal, protected Internal members are accessible
        //consuming members from non child class in he same project
        static void Main(string[] args)
        {

            //here only three members/methods are accessible not the private and protected one
            //as protected members can be accessible in its class or in its child class and private 
            //to its class only so
            Program p = new Program();
            p.testInternal();
            p.testProtectedInternal();
            p.testPublic();
            // as all class have main method now you will setthe main class by double clicking
            //properties in solution explorer and from start up object select this class

        }
    }
}
