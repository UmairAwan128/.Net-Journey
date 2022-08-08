using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7NewFeature
{
    //Local methods are the methods that can be created any where even inside a method so we can call them without creating the obj of the class
    class LocalMethods
    {
        static void Main() {

            //here we created a local method
            void AddNums(int a, int b) {
                Console.WriteLine(a + b);
            }

            AddNums(10, 15);
            //but we can also do this using Annonymous method or buiilt in delgates
            //But Annoymous method cannot do what it can do i.e in Annonymous method we cannot use
            //1. Params keyword      that can be used as input parameter its like a list so user can pass any no of input parameters
            //2. ref or out keyword         as we disscussed in ReturnMultipleValue.cs file 
            //3. Generics <> 

            void refMethod(int a, int b, ref int c, ref int d)
            {
                c = a + b;
                d = a * b;
            }

            int m = 10; int n = 20;
            refMethod(10, 20, ref m, ref n); 
            Console.WriteLine(m + " " + n);

            void outMethod(int a, int b, out int c, out int d)
            {
                c = a + b;
                d = a * b;
            }

            outMethod(10, 20, out int l, out int r);  //no need to initialize l and r
            Console.WriteLine(l + " " + r);


            void ParmsMethod(params int[] arrPara )
            {
                int sum=0;
                foreach (var i in arrPara) {
                    sum += i;
                }
                Console.WriteLine("Sum is :" + sum);
            }

            ParmsMethod(10, 20,30,40);//pass any no of parameters

            void genericMethod<T>(T a, T b)
            {
                //as we didn,t tell type so we cannot directly add them so 
                dynamic c = a;   //if var type will be known at compile time
                dynamic d = b;  //d type will be known at run time
                Console.WriteLine(c + d);
            }
            genericMethod<string>("umair", "awan");
            genericMethod<int>(10, 15);


            //all thes things are possible with local methods not with annonymous method
            Console.ReadKey();
        }
    }
}
