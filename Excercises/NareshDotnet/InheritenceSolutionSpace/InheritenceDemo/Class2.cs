using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritenceDemo
{
    //here in class i want all methods of class1 so what i should do i should copy paste it
    //better is to use inheritence.
    class Class2 :Class1
    {
        
        public Class2(int i) : base(i) {  //child class constructor auto calls default constructor of the parent
        //but if the parent class default constructor is no more i.e now there is parameterized constructor
        //that needs an int so we will implicitly call that parent class constructor using base() keyword and pass parameter required   
            Console.WriteLine("Class2 Constructor called");
        }
        public void Test3() {
            Console.WriteLine("Method 3");
        }
        static void Main() {

            //when this line executes first control move to the class2 constructor but this constructor
            //with out executing its code calls parents class Class1 contructor and this calls object class
            //Constructor so as if child class Class2
            //want to use comonents of parent class those compnents must be initialized first which is done 
            //by parent class constructor only
           Class2 c = new Class2(15); //for this the parent class(Class1) constructor should be accessible here i.e should not be private  
            c.Test1();  //Test1 method is of Class1 but as Class2 is child so it can access it
            c.Test2();  //Test2 method is of Class1
            c.Test3();  //Test3 method is of Class2
            //but can access only its methods
           Class1 c1 = new Class1(6);
            c1.Test1();
            c1.Test2();

            //c2 is a reference of parent class created by using child class instance
            Class1 c2 = new Class2(10);  //this ref is consuming mem of child class instance 
            //here also we can,t call child class members so its Class1 instance
            //but here both class constructors are called as its like we first created class2 obj and assigned
            //it to class1 obj i.e.   Class2 c = new Class2();  Class1 c2 = c;
            c2.Test1();
            c2.Test2();

            //Object class inside system namespace is the parent of all classes which has four methods which will be avail in all classes
            Object obj = new Object();  //ultimate base class of all classes so its four methods will be in all classes
            Object obj1 = new Class1(6); //as obj is of object class so it has only four methods of object class 
            //e.g getType() is method of object class so accessible any class also here
            //getType() method tells the fully qualified name of class whom object is passed 
            Console.WriteLine(c1.GetType());
            Console.WriteLine(c2.GetType());
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj1.GetType());

            Console.ReadKey();
        }
    }
}
