using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleInheritence_Demo
{

    //In C# multiple inheritence is not suported but we can do this using interfaces as a class can implement
    // as much interfaces as it wants so multipe inheritence is supported through interfaces
    //Why multiple inheritence is supported thru interfaces but not with classes?
    //the answer is if we have three classes class1,class2,class3 and class3 inherits from class1 and class2
    //and say both the classes 1 and 2 have Test mehtod with same signature so while inheriting there will be an ambiguity
    //Test() method in class 3 is of class1 or class2 i.e obj of class3 will call/cosume which as the
    //implentation of both the methods will be provided their classes class1 and class2...

    //in case of interface the answer is if we have two interfaces interface1,interface2 and a class and class
    //inherits from interface1 and 2 and say both the interface 1 and 2 have Test mehtod with same signature
    // but as there will be no impemenation in parent/interfaces so when we implement a single Test in child/class
    //both the interfaces will think that as there Test method is implemented and hence one Test method
    //will be there only and only one implementation so compiler will have no ambiguity while calling
    
    //So consuming will cause amb
    interface interface1 {
        void Test();
        void Show();

    }

    interface interface2
    {
        void Test();
        void Show();

    }

    class Program :interface1,interface2 
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Test();  //but we cannot call show methods so
            //we can call them as
            interface1 i1 = p;  
            i1.Show();   //as show is not public here and also ambiguity so it can be callled by parent/interface only
            interface2 i2 = p;
            i2.Show();


        }

        //also to increase readability in case of many other simple methods in class
        //we can identify these overrided method as writting complete name of method and 
        //avoid public modifier..
        //this is explicit implementation i.e we implemented both methods seperately by using there
        //fully qualifed name so now they are two different methods ..
        void interface1.Show()
        {
            Console.WriteLine("show method of interface1 implemented in child class");
        }
        void interface2.Show()
        {
            Console.WriteLine("show method of interface2 implemented in child class");
        }
        public void Test()
        {
            Console.WriteLine("Test method of interface1 and interface2 implemented using one method in child class");
        }

        //so in these both ways of implementing interface we never come accross ambiguty problem so 
        //multiple inheritence is supported thru interfaces in c#.....
    }
}
