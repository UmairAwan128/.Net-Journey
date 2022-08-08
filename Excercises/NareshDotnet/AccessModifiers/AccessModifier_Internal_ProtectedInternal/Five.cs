using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifier_Internal_ProtectedInternal
{
    //here we consume members of the Program class by creating instance of that class i.e in the different project
    //here only  public members are accessible 
    //here we didn,t accessed protected internal as this class not child and also not in the same project
    // so only public accessible
    
        //as we didn,t imported AccessModifiersDemo also we can do this 
    class Five : AccessModifiersDemo.Program
    {
        static void Main() {
            AccessModifiersDemo.Program p = new AccessModifiersDemo.Program();
            p.testPublic();
        }
    }
}
