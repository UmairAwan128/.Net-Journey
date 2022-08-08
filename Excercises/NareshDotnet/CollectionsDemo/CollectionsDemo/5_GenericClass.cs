using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    class GenericClassDemo
    {
        public void Add<T>(T a, T b) {
            //but we can,t directy Add them as we don,t know rightknow the type of T and it can be any  
            //Console.WriteLine(a + b);   so use dynamic(benifit is it will be the type which value is passed and its done on runtime)
            dynamic d1 = a;  // the type of d1,d2 will be known on runtime and will be of the type the value is  
            dynamic d2 = b;  // passsed so addition will work as d1 and d2 type is now known and these are inside the 
            Console.WriteLine(d1 + d2);   //the method so can now be added
        }

        public void Sub<T>(T a, T b)
        {
            dynamic d1 = a;  
            dynamic d2 = b;  
            Console.WriteLine(d1 - d2);   
        }

        public void Mul<T>(T a, T b)
        {
            dynamic d1 = a;   
            dynamic d2 = b;   
            Console.WriteLine(d1 * d2); 
        }

        public void Div<T>(T a, T b)
        {   dynamic d1 = a;  
            dynamic d2 = b;  
            Console.WriteLine(d1 / d2);   
        }
    }
    //As GenericClassDemo class has all methods having same generic sign <T> i.e all methods require same type of 
    //paramerters e.g int parameters req for Add,Sub,Mul,Div so same so in such a case this <T> is wrote with the  
    //name of class and skiped from methods and write while declaring class and method will know the type from this <T> with class so
    class theGenericClass<T>
    {
        public void Add(T a, T b)
        {
            //but we can,t directy Add them as we don,t know rightknow the type of T and it can be any  
            //Console.WriteLine(a + b);   so use dynamic(benifit is it will be the type which value is passed and its done on runtime)
            dynamic d1 = a;  // the type of d1,d2 will be known on runtime and will be of the type the value is  
            dynamic d2 = b;  // passsed so addition will work as d1 and d2 type is now known and these are inside the 
            Console.WriteLine(d1 + d2);   //the method so can now be added
        }

        public void Sub(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 - d2);
        }

        public void Mul(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 * d2);
        }

        public void Div(T a, T b)
        {
            dynamic d1 = a;
            dynamic d2 = b;
            Console.WriteLine(d1 / d2);
        }
    }

    class TestGenericClass
    {
        static void Main() {

            GenericClassDemo gcd = new GenericClassDemo();
            gcd.Add<int>(10, 20);
            gcd.Sub<int>(10, 20);
            gcd.Mul<int>(10, 20);
            gcd.Div<int>(10, 20);

            theGenericClass<int> tgcd = new theGenericClass<int>();
            tgcd.Add(10, 20);
            tgcd.Sub(10, 20);
            tgcd.Mul(10, 20);
            tgcd.Div(10, 20);

            //theGenericClass<T> we created above is same as builtin builtinGenericCollection class e.g List  
            //i.e this is how all the builtin generic collection class are created e.g List class use is also same as it 

            List<int> li = new List<int>();  //we told type while creating class
            //and this type is know knowned to all the methods in List class so they will only accept that type(int) only
            li.Add(200); li.Add(100); li.Add(300); li.Add(500); li.Add(800); 
            li.Insert(2, 50);
            li.Remove(3);
     
            Console.ReadKey();
        }
    }
}
