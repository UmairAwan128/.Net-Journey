using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverriidng_VS_Overloading
{
   
    //In method overloading we define multiple methods with same name by changing their parameter(order,type,no)
    //this can be performed within the class or either b/w parent child class also e.g below
    //here child class method don,t need permission from parent to overload its method in it.
    //it is providing various behaviours 

    //Method Overriding is an approach of re_implementing parent class method under the child class with 
    //the same signature(i.e same name,parameters and return type)
    //This can be performed only b/w parent, child classes
    //while overriding, here child class requires permission from parent class to overrride its method in it. 
    //if we want override under the child class first the method should be declared with Virtual modifier in parent class
    // Virtual means either the child class can use its implementation or write its own that will remove default implementation. 
    //Any Virtual method of parent class can be overriden by child class but we should write Override modifier in creating it..
    //so it is changing the behaviour of the parent class method in child class
    public  abstract class Parent_Class    //as abstract class so we can,t create its obj
    {   

        //as Virtual Modifier used so they are now overridable
        //we can also use here abstrct here which means the method is must override for all child classes
        //also as any method gets abstract class also become abstract  and we can,t create its object 
        //another benifit of creating a abstract/virtual method in parent class is all child class will have
        //the method signature same. so call with same name/parameter
        public virtual void Show() {
            Console.WriteLine("Parents Show method is called");
        }

        public virtual void Test()   //as Virtual modifier so Overridable
        {
            Console.WriteLine("Parents Test method is called");
        }

        //a method that doesnot contain method body is abstract method
        public abstract void AbstractTest();   //must override method
     
    }

    class Child_Class : Parent_Class {
        static void Main(string[] args)
        {
            
            Child_Class c = new Child_Class();
            //so we have two show and test method each have +1 Overload one in parent and one in child class
            c.Show();
            c.Show(10); 
            c.Test();
            c.Test(20);
            c.AbstractTest();  
            
            Console.ReadLine();
        }

        //overloading parents class Show() and Test() method i.e by changing parameters in child class 
        //for this we don,t need any permission from parent class..
        public void Show(int i)
        {
            Console.WriteLine("Child overloaded Show method is called"+ i);
        }


        public void Test(int i)
        {
            Console.WriteLine("Childs overloaded Test method is called" + i);
        }


        //overridding parents class Show() and Test() method 
        //for this we need permission from parent class..
        //and we used here override modifier
        //before overriddin these methods Show and test of parent class was being called in main
        //now as they are overridden so these overridden methods will be called
        //so if we override method that will be called otherwise parent default method will be called
        //also this is not overloading so only one Show and Test method
        public override void Show()
        {
            Console.WriteLine("Childs overRidded Show method is called");
        }
        public override void Test()
        {
            Console.WriteLine("Childs overRidded Test method is called" );
        }

        //as must override
        public override void AbstractTest() {
            Console.WriteLine("AbstractTest method is called");
        }

    }
}
