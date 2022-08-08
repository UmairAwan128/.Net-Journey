using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    class TestExtensionMethods
    {

        static void Main() {
            Program p = new Program();
            
            //example 1: class in our project
            //orignally Program class contains only two method but as test3() extension method added so 3 methods now
            p.test1();
            p.test2();
            p.test3(); //hovering over test3() or in intellisense we can see (extension) keyword is written with it telling its an extension method
            p.test4(20);

            //example 2: built in struct/class not in our project
            //lets take an example of a built_in class say 'int'  it's a struct and we don,t have its code
            //either we that struct is also not in the same project  so we access it and right now it does not have
            //factorial method but we want to add factorial method into this struct so follow the steps
            // we already have a static class so no need to create it we will define factorial method there in (HasExtensionMethods) class   
            int x = 5;
            // x contains the value for which the factorial will be calculated 
            //as its already in the extension method or we can access so we didn,t created parameter in extension method...    
            long result = x.Factorial();
            Console.WriteLine("Factorial of "+x+" is "+result);



            //example 3: our/built in sealed class not in our project so for e.g we take String i.e is a sealed class
            String str = "heLLo wOrLd iTs uMaIr";
            //I want this string to be converted to Proper case i.e first letter will be upper and latter will be lower
            //but we have toUpper() and toLower() in string class but not this so lets add this as extension so
            //so again we created method in (HasExtensionMethods) class
            Console.WriteLine(str.toProper());

            Console.ReadKey();
            
        }
    }
}
