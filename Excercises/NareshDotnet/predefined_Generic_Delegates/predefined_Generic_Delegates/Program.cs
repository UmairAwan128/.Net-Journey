using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predefined_Generic_Delegates
{
    //there are three predifned/builtin generic delegate these are defined in base classes
    //1. func delegate (stores reference or bounds the method that has a return type or returns a value )
    //2. action delegate (stores reference or bounds the method that does not returns any value or has void return type )
    //3. predicate delegate (stores reference or bounds the method that has bool return type )
    
        //so next time when you need delegate try to use built in delegate
    
    //step 2 : create delegates for these methods
    public delegate void DelgateAddnums(int x, float y, double z);
    public delegate double DelgateAddnumsRet(int x, float y, double z);
    public delegate bool DelgateCheckLength(string str);

    class Program
    {
        //step 1 : create methods
        // value returning method
        public static double AddnumsRet(int x, float y, double z) {
            return x+y+z;
        }
        //non value returning method
        public static void Addnums(int x, float y, double z)
        {
            Console.WriteLine("Sum is : " +(x + y + z));
        }

        //the method that takes string and returns true if the length is greater then 5..
        public static bool checkLength(string str)
        {
            if(str.Length>5)
              return true;
            else
                return false;
        }


        static void Main(string[] args)
        {
            
            //calling methods using our created delgates
            DelgateAddnumsRet dar = AddnumsRet;
            double result = dar.Invoke(100,134f,193.465);
            Console.WriteLine("sum is : "+result);

            DelgateAddnums da = Addnums;
            da.Invoke(100, 134f, 193.465);

            DelgateCheckLength dcl = checkLength;
            bool status = dcl.Invoke("umair");
            Console.WriteLine("Status is : "+status);

            Console.ReadKey();

            
            
            
            
            
            //same code using built in delegate and normal methods
            //we can also call all the methods using the built in delegates i.e without using our created delegates

            //first three are input parameters and fourth is return type of method
            Func<int,float,double,double> dar1 = AddnumsRet;     //1. func delegate (stores reference or bounds the method that has a return type or returns a value and has 0-16 parameter i.e +17 overloads for this delegate)
            double result1 = dar1.Invoke(100, 134f, 193.465);
            Console.WriteLine("sum is : " + result1);

            Action<int,float,double> da1 = Addnums;  //2. action delegate (stores reference or bounds the method that does not returns any value or has void return type and can have upto 16 input parameters i.e +16 overloads  )
            da1.Invoke(100, 134f, 193.465);

            Predicate<string> dcl1 = checkLength;  //3. predicate delegate (stores reference or bounds the method that has fixed bool return type and any type of only one input parameter)
            // Func<string,bool> dcl1 = checkLength;  //also func delegate can be used here also works same way
            bool status1 = dcl1.Invoke("umair");
            Console.WriteLine("Status is : " + status1);

            Console.ReadKey();





            //same code using built in delegate and using lamda expression for methods

            //first three are input parameters and fourth is return type of method
            //so here we are not using the method(AddnumsRet) and also delegate(DelegateAddnumsRet)
            //instead we used built in delgate(Func) and lamda expression for creating method here on runtime...
            
                                                    //as single line code so no body{ } required
            Func<int, float, double, double> dar2 = (x, y, z) => x + y + z;   //also no need to write return

            double result2 = dar2.Invoke(100, 134f, 193.465);
            Console.WriteLine("sum is : " + result2);
            
            //as single line code so no body{ } required
            Action<int, float, double> da2 = (x,y,z)=> Console.WriteLine("Sum is : " + (x + y + z));

            da2.Invoke(100, 134f, 193.465);

            Predicate<string> dcl2 = (str)=> {
                if (str.Length > 5)
                    return true;
                else
                    return false;
            }; 

            // Func<string,bool> dcl1 = checkLength;  //also func delegate can be used here also works same way
            bool status2 = dcl2.Invoke("umair");
            Console.WriteLine("Status is : " + status2);

            Console.ReadKey();
        }
        //conclusion: 
        //so next time when you need delegate try to use built in delegate
    }
}
