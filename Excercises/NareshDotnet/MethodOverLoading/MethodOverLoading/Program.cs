using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverLoading
{
    class Program
    {
        //method overloading depends only on the parameters of method not any other thing
        //no of parameters
        //order of parameters
        //type of parmeters

        //why not returnType below we creted method with string return type and there is also a method
        //in this class both same expect it has void return type 
        //first they have same parmeters
        //2nd there will be ambiguity while calling the Test method that which test method is called
        //so Visual studio will not allow u to create it even. 
        //public string Test()
        //{
        //    return "";
        //}

        //we use method overloading when there is a scenario where as input changes output/behaviour also change
        //for the same method benifit is same Name is easy to remember  
        
        public void Test() {
            Console.WriteLine("1st method no parameters");
        }
        public void Test(int i)
        {
            Console.WriteLine("2nd method one int parameter");
        }
        public void Test(string s)
        {
            Console.WriteLine("3rd method one string parameter");
        }
        public void Test(int i,string s)
        {
            Console.WriteLine("4th method 1st parmeter int and 2nd string");
        }
        public void Test(string s,int i)
        {
            Console.WriteLine("5th method 1st parmeter string and 2nd int");
        }
        static void Main(string[] args)
        {
            //lets access these 5 methods
            Program p = new Program();
            //but when accessing them using obj(p) by intellisense we only see one method test
            //and moving to it shows additionlly that it has +4 Overloads Methods
            //another feature when u select method and write bracket use up and down arrow to see 
            //all the overloaded Test methods syntax i.e what parameter they req
            p.Test();
            p.Test(10); //method with int parmeter will be called
            p.Test("umair");
            p.Test(10, "umair");
            p.Test("umair", 10); //method with 1st string and 2nd int parmeter will be called
            Console.ReadKey();


            //builtin e.g is
            //use up and down keys to see overloaded methods here IndexOf has 9
            String s = "Umair Umair";
            Console.WriteLine( s.IndexOf('a') );
            Console.WriteLine(s.IndexOf("air"));
            Console.WriteLine(s.IndexOf('a', 5));   
            Console.WriteLine(s.IndexOf('a', 5, 0)); //third parmeter is after starting pos i.e 2nd parmeter(5) 
            Console.WriteLine(s.IndexOf('a', 5, 5)); // search in next 0,5,4 elements 
            Console.WriteLine(s.IndexOf('a', 5, 4)); // for not getting error there must be (0,5,4) elements after starting pos
            Console.WriteLine(s.IndexOf('a', 5, 6));

            Console.ReadKey();

        }
    }
}
