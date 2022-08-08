// following file is created using 'code file' i.e blank file in which we can create any thing
//class,strucut interface e.t.c
using System;
namespace StructuresDemo {

    //Class vs Struct
    //Class is reference type and memory is allocated in heap e.g built_in are  String,object class
    //struct is value type and memory is allocated on stack e.g built_in are int32,Boolean e.t.c
    //both class and structures are used to represent entities but when which
    // structure used when we want to represent smaller volume of data or has small values
    // class used when data is in larger volume or has large values

    //In case of class its object must be initialized when declared to use class members i.e
    //  myclass m = new myclass();
    //In case of structure if we just declare obj it will work i.e initialization is optional
    // MyStruct m;     m.Display();   //works

    //Fields of a class can be initialized at the time of declaration in class but we cannot
    //initialize fileds of struct at the time of declaration in struct but can be in constructor..

    //in class we can define both parameterized and parameterless constructors
    //but in case of struct we cannot define parameterless constructor but only parameterized contructor
    //i.e why in struct when we create a parameterized constructor we don,t need to re_define default constructor 
    //as its allways there and is not removed
    // but in case of class when we define a parameterized constructor we need to redefine
    //the default constructor if we need that.

    //Structurs don,t support inheritence

    interface myinterface {

        void add(int i, int z); 
    }

    struct MyStruct : myinterface{
        int i;
        public void Display() {
            Console.WriteLine("Method in a structure");
        }
        public MyStruct(int i) {  //in struct we can only define parameterized constructor
            this.i = i;
        }
        static void Main() {
            //calling default constructor as its allways present in case of struct
            MyStruct s = new MyStruct();  //= new MyStruct();   is optional in case of struct has no fields if has so they must be initialized
            s.Display();                 //so  do this  s.i=10(assigning value through obj) or  = new MyStruct();(calling the default constructor of struct)   
            s.add(20, 10);

            MyStruct s1;  
            s1.i = 10;
            s1.Display();
            s1.add(20, 10);
            
            //calling our define or parameterized constructor
            MyStruct s2 = new MyStruct(100);
            s2.Display();
            s2.add(20, 10);
            Console.ReadLine();

        }

        public void add(int i, int z)
        {
            Console.WriteLine("add method od interface is implemented in struct");
        }
    }

} 