using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    //step 1 : defining delegate
    public delegate void AddDelegate(int x, int y);
    public delegate string SayDelegate(string str);

    class DelegatesIntro_Syntax
    {
        //delegate is a userdefined reference type that holds reference of the method and then its is used to call that method...
        //we call methods of the class..  (1) using object of the class if static with name of class  
                                         //or  (2) using delegates


        public void AddNums(int a,int b)
        {
            Console.WriteLine("Sum is : "+(a+b));
        }
        //creating a static method
        public static string SayHello(string name)
        {
            return "Hello : " + name;
        }
        static void Main(string[] args)
        {
            DelegatesIntro_Syntax p = new DelegatesIntro_Syntax();
            p.AddNums(10,15);  //calling AddNums
            string s = DelegatesIntro_Syntax.SayHello("umair");   //calling static method
            Console.WriteLine(s);

            //to call  a method using delegate 
            //1. define a delegate its definaion is same like method just delegate keyword is added i.e
            //  for method        -->             public static string SayHello(string name)
            //  delegate will be  -->             public delegate string SayHello(string str)  //static will not be used
            //as delegate is a reference type so it should be defined under a namespace also under a class

            //step 2: create instance of the delegate
            //while writing brackets intellisense tells the method having such (return type, type and no parameters) will be stored in this delegate 
            AddDelegate ad = new AddDelegate(p.AddNums);  //so AddNums() method is assigned to delegate
            SayDelegate sd = new SayDelegate(DelegatesIntro_Syntax.SayHello);

            //step 3 : call the delegate by passing required parameters so bounded mehod will be executed
            ad(10,15);
            string s1 = sd("umair");
            Console.WriteLine(s1);
            Console.WriteLine(sd("umair")); //or this also same as above

            ad.Invoke(10, 15);//other way of calling is using Invoke there is no difference in both calling with or without using invoke() method
            string s2 = sd.Invoke("umair");  
            Console.WriteLine(s2);

        }
    }
}
