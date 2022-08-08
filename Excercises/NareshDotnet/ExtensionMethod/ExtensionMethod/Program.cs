using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    class Program
    {
        //suppose any built class(String) has 10 methods and we want to add a method in it so we can,t do this
        //as we don,t have permission to add,update any thing in a built in class and also we don,t have the 
        //source code of that class so if sourcecode of a class is not available we cannot add method to a class
        // 1. one way will be you inherit the built_in class in your class and create methods in child class 
        //    so inheritence is used here to extend the funcionality of a class as child class has every thing new/old methods... 
        //    but the problem is if the class is Sealed we cannot apply inheritence on the class 
        //    or if that is not a class but struct also we can,t apply inheritence...

        //So Extension Method is a mechanism through which we add new methods to any existing class(even sealed) or struct
        //   without modifying source code of the orignal type.. 

        // procedure:
        //1. create a new static class so it has all static members
        //2. define methods in it what you want
        //3. now bind these methods with the class/struct we want..

        //say folloing is the class in which we want to add a method   

        public void test1() {
            Console.WriteLine("test1() executed");
        }

        public void test2()
        {
            Console.WriteLine("test2() executed");
        }

    }
}
