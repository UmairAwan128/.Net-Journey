using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using AccessModifiersDemo;


//now as we have two projects bot have main method so two set this project as start up project 
//right clicj=k on the project and select   set as startup project

namespace AccessModifier_Internal_ProtectedInternal
{
    //as i want to access the members of the Program class i.e in another project so add reference of that 
    // project in this so do this by right click project move to add then reference a browse the project 
    //AccessModifierDemo and move to its bin debug folder and select the .exe application/Assembly file
    //it will be shown in references file in solution explorer 


    //here we access members of the program class using inherithence i.e of parent class 
    //and that parent class is not in the same project
    // so protected, public, protected internal members are only accessible here 
    class Four : Program
    {
        //also internal class is not accessible outside the project so class  Two and Three 
        // are also not accessible here only Program class is accessible here and inheritable also

        Program p = new Program();
        //Two t = new Two();  which is not accessible
        static void Main(string[] args) 
        {
            Four f = new Four();
            //we didn,t get here internal method as it is accessible only with in the project
            f.testProtected();
            f.testProtectedInternal();
            f.testPublic();
            Console.ReadKey();
        }
    }
}
