using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemo
{
    class _2_ThredConstuctors
    {
        static void Test() {
            for (int i=0;i<100;i++) {
                Console.WriteLine("Test : "+i);
            }
        }

        static void Test2(object max)
        {
            int limit = Convert.ToInt32(max);
            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("Test2 : " + i);
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(Test);  // Thread class has four constructors we used here 2nd that takes 
                                          //Delegate named ThreadStart()/method which has same signature like it i.e void return type and no input parameters

            ThreadStart ts = new ThreadStart(Test);//other way of doing the same thing is first assign method ref to Delegate either by this way
//            ThreadStart ts2 = Test;                   //or this ways
  //          ThreadStart ts3 = delegate() { Test(); }; //or using annonymous method that is calling the method can have body of this method also
    //        ThreadStart ts4 = ()=> Test();            //or using lamda expression 

            Thread t1 = new Thread(ts);             //then pass this delegate object to Thread class constructor   
                                                    //so in first the instance of the delegate ThreadStart is auto created and passed

            //Test() method above has no parameters but if the mehtod has parmeter so we use used here 1st constuctor
            //of Thread class that takes  Delegate named ParameterizedThreadStart()/method which has same signature like it i.e void return type and one input parameters of object type so
            ParameterizedThreadStart pts = new ParameterizedThreadStart(Test2);
            Thread t2 = new Thread(pts);
            t2.Start(75);  //the parameters of the Test2 method are passed here when we start thread  
            t2.Start("hello"); //but the problem is it can take any type of parameter as ParameterizedThreadStart delegate takes input parameters of object type so any can be passed
            //so it will not a compile time error but a runtime error as cannot convert string to int..
            Console.ReadKey();


        }
    }



}
 