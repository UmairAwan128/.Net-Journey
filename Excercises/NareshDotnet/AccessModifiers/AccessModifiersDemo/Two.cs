using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiersDemo
{
    //here we access members of the other class using inherithence i.e of parent class i.e in the same project
    //here public, internal, protected Internal, protected members are accessible
    //no access modifier so internal by default
    class Two : Program
    {
        static void Main() {
            //here we can have all methods of Program class then the testPrivate() i.e private method
            //here we consume members of the other class using inherithence
            Two t = new Two();
            t.testInternal();
            t.testProtected();
            t.testProtectedInternal();
            t.testPublic();

            Console.ReadKey();

            // as both class have main method now you will setthe main class by double clicking
            //properties in solution explorer and from start up object select this class


        }
    }
}
