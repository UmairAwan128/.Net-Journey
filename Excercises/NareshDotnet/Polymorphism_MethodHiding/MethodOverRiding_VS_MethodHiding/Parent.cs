using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverRiding_VS_MethodHiding
{
    //Overriding is the approach of reimplemeting parent class under the child class with same name and parameters
    //Method hiding/shadowing is also the approach of reimplemeting parent class under the child class with same name and parameters
    //so what,s difference..
    //in overriding child class re_implement the methods of parent class that have modifier Virtual(i.e which parent allowed to reimplement)
    //where as in method hiding/shadowing child class re_implement the methods of parent class even they don,t have Virtual modifier
    //we did this by using new modifier while creating such methods also if we remove this parent class method will be called

    //so 2 approaches to implement parent class methods in child class 
    //mthod overriddng            (with permission of parent class)
    //method hidding/shadowing    (without permission of parent class) 

    class Parent
    {
        public virtual void Test1(){ //has virtual modifier so overridable
            Console.WriteLine("Test1 mehod parent class");
        }
        public void Test2()   //not overridable but can be overloaded in child class
        {
            Console.WriteLine("Test2 mehod parent class");
        }


    }

    class Child : Parent {
        public override void Test1() //Method Overriding
        { //as overrided so now this will be called from child class obj
            Console.WriteLine("Test1 mehod child class");
        }

        //Method hiding is here this method was not declared virtual and we re_implemented it here so now 
        //this will be called from child class obj
        //we can also skip new keyword this will not change anything but there will be a warning not an error
        public new void Test2()   //Method Hiding/shadowing
        {
            Console.WriteLine("Test2 mehod child class");
        }
        static void Main(string[] args)
        {
            Child c = new Child();
            //till not overrided so parent class methods will be called 
            c.Test1(); //as overrided so child class method will be called
            c.Test2(); //as method hidding so child class method will be called
            
            //but we want call parent class methods from child class even after re_implementing methods 
            //1.  if these overriden/reimplemented methods are removed from here 
            //2.  creating parent class object here and call them using it i.e
            Parent p = new Parent();
            p.Test1(); 
            p.Test2();
            //3.  we can call using the 'base' keyword but ...Note(keywords like 'base' and 'this' can,t be used inside static block/methods )
            //so we did this by creating methods and called using child class obj
            c.ParentTest1();
            c.ParentTest2();


            //so whats the difference b/w method overridding and hidding till we get only syntax diff see this
            Parent p1 = new Child(); //so by inheritence we studied that it is Parent class obj so methods of parent will be call
            //but output told us
            p1.Test1();  //child class Test1 called
            p1.Test2();  //parent class Test2 called

            //so the answer is as Test1 is overriden to child class and Parent class gave permisson to override it
            //using virtual keyword so if child does re_implementaion of method, parents knows it and hence 
            //new implementaion will be displayed or child class mehod will be called using parent class obj

            //but for Test2 as child class reimplemented parent class method without permisson of parent class
            //so parent don,t know or ignore any re_implementation by child class and parent class method called
            // or parent class mehod will be called using parent class obj and child class method with child class obj

            //also as the method hidding creted the Test2 without permission of parent so 
            //so its purely a child class member and its not accessible to parent class obj.
            
            Console.ReadKey(); 
        }
        public void ParentTest1()   //calling the base/parent class method
        {
            base.Test1();
        }
        public void ParentTest2()   //calling the base/parent class method
        {
            base.Test2();
        }

    }
}
