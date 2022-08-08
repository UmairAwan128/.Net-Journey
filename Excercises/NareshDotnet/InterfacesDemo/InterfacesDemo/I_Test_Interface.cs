using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    //Class : contains only non_Abstract methods(with out method body)
    //Abstract Class : contains Abstract and non_Abstract methods(with out method body)
    //Interface : contains only Abstract methods(with out method body) i.e declaration only

    //A class can also inherit from Interface but child class should implement all methods of Interface as all are abstrct..    
    //A class can implement as many methods as it want
    //Generally a classs inherits from another class to consume members of the parent class but a 
    //class inheriting from interface it is to implement members(as all abstract) of the interface/parent..

    interface I_Test_Interface_Parent
    {
        //  the default scope of members of the imterface are public so no need to write whereas its private in case of class
        //  so by default every member of interface is abstract so we don,t need to write this modifier with members

        //  interface don,t contain any fileds/variables


        void Add(int a, int b);
    }

    interface I_Test_Interface_Child : I_Test_Interface_Parent   //interface can inherit from another interface
    {
        //so this interface has two methos add,sub..
        void Sub(int a, int b);
        void Div(int a, int b);

    }

    class ImplementationClass : I_Test_Interface_Child  // child interface inherited so two method must be implemented
    {
        
        //here we don,t write override but we should write public as in interface they were public and
        //in class by default all members are private..
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        public void Sub(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        //also to increase readability in case of many other simple methods in class
        //we can identofy these overrided method as writting complete name of method and 
        //avoid public modifier..
         void I_Test_Interface_Child.Div(int a, int b)
         {
            Console.WriteLine(a - b);
         }

        static void Main() {
            ImplementationClass obj = new ImplementationClass();
            obj.Add(1, 4);
            obj.Sub(6, 4);
            obj.Div(6, 2); //not accessible as its not public i guess
            //also can be
            I_Test_Interface_Parent p = obj;
            p.Add(1, 4);
            //p.Sub(6, 4); can,t be called as I_Test_Interface_Parent don,t contain add method
            // p.Div(6, 2); can,t be called as I_Test_Interface_Parent don,t contain div method

            I_Test_Interface_Child c = obj;
            c.Add(1, 4);
            c.Sub(6, 4);
            c.Div(6, 2);   //Div is only Accessible from the class its declared in
            Console.ReadLine();
        }



    }
}
