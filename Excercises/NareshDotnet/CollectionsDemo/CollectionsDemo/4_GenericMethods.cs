using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    class GenericMethods
    {
        //will only recieve and compare int
        public bool CompareInt(int a, int b) {
            if (a == b)
                return true;
            else
                return false;
        }
        //but we want to Compare float values so either we create that or
        //craete a method that can compare any type of value we pass so use object type
        public bool CompareObject(object a, object b)
        {
            //Console.WriteLine("    "+( (int)a + (int)b) );     //unboxing performed to add int parmeters

            if (a.Equals(b)) // a == b does not work for object as it compares numeric only but not char but object can have any so
                return true;
            else
                return false;
        }
        //but the Problem with compareobject() is its not type safe we can pass two parameters either of same type
        //or other type, other problem is boxing and unboxing as we call method and pass parameters e.g int it will be stored
        //in object ans is converted to reference type by using process of boxing and if we want to perform any operation 
        //either arithematic,relational,logical like Add,== on that these values we will first perform unboxing i.e 
        //convert them to int or valueType as those operation can be performed on value type not on reference type..
        //so the solution is use generic or generic method its also type safe and don,t nedd boxing/unboxing...
        public bool CompareGeneric<T>(T a, T b)  //T is any type we tell while we call method it also make the method TypeSafe  
        {
            //Console.WriteLine("    "+( (int)a + (int)b) );     //unboxing performed to add int parmeters

            if (a.Equals(b)) // a == b does not work for object as it compares numeric only but not char but object can have any so
                return true;
            else
                return false;
        }

        public static void Main() {
            GenericMethods gm = new GenericMethods();
            //calling CompareInt()
            Console.WriteLine(gm.CompareInt(15,12));  //returns false
            Console.WriteLine(gm.CompareInt(15, 15));  //returns true
            //CompareInt problem compares only int
                                                       
            //calling CompareObject() 
            Console.WriteLine(gm.CompareObject(15, 12));  //returns false
            Console.WriteLine(gm.CompareObject('s', 's'));  //returns true
            Console.WriteLine(gm.CompareObject(12.4f, 12.4f));  //returns true 
            Console.WriteLine(gm.CompareObject("sd", "sd"));  //returns true
            Console.WriteLine(gm.CompareObject(true,false));  //returns true
            //CompareObject problem not type safe we can pass two parameters either of same type or other type also boxing/unboxing problem
            Console.WriteLine(gm.CompareObject(12.4, 12.4f));  //returns false  first is double 2nd is float type
            Console.WriteLine(gm.CompareObject("sd", 4));  //returns false   first is string second is int 

            //calling CompareGeneric() 
            Console.WriteLine(gm.CompareGeneric<int>(15, 12));  //returns false
            Console.WriteLine(gm.CompareGeneric<char>('s', 's'));  //returns true
            Console.WriteLine(gm.CompareGeneric<float>(12.4f, 12.4f));  //returns true 

    //        Console.WriteLine(gm.CompareGeneric<float>(12.4, 12.4f));    //will not work as typeSafe float is type acceptable
   //         Console.WriteLine(gm.CompareGeneric<string>("sd", 4));   //will not work as typeSafe and string is type acceptable

            Console.WriteLine(gm.CompareGeneric<double>(12.4, 12.4f));    //but works as float can be converted to double returns false 



            Console.ReadKey();
        }
    }
}
