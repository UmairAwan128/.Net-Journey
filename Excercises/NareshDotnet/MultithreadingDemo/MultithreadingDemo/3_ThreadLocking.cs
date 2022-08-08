using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemo
{
    //same resource/method/database can be accessed by multiple threads at the same time at this time the output
    //would be not as expected also e.g in case of database if at the same time two or more threads try to modify
    //a same record it will be a big problem so reslove such issues we use ThreadLocking
    //in ThreadLocking we apply lock on such a code so at a time if three threads want to access the method/code
    //only one will access it and after it completly access it 2nd get its turn and after it third gets its turn

    class ThreadLocking
    {
        public void Display() {
            Console.Write("[Csharp is an ");
            Thread.Sleep(5000);
            Console.WriteLine("Òbject Oriented language] ");
        }

        public void Display2()
        {
            lock (this) {   //we applied lock on this piece of code so now only one thread at a time will access this code all other will be waiting in queue 
            Console.Write("[Csharp is an ");   //benifit is we get the perfect output
            Thread.Sleep(5000);
            Console.WriteLine("Òbject Oriented language] ");
            }
        }


        static void Main() {
            ThreadLocking tl = new ThreadLocking();

            Console.WriteLine("\n\n Dislay1 method without Threadlocking : \n\n");
            //creating three threads that will access the display method at the same time
            Thread t1 = new Thread(tl.Display);
            Thread t2 = new Thread(tl.Display);
            Thread t3 = new Thread(tl.Display);
            t1.Start(); t2.Start(); t3.Start(); //output would be unexpected or mixed of all three

            t1.Join(); t3.Join(); t2.Join();
            Console.WriteLine("\n\nNow Dislay2 method with Threadlocking : \n\n");

            //creating three threads that will try access the display2 method at the same time
            Thread t4 = new Thread(tl.Display2);//we applied lock on the piece of code inside Display2() so now only one thread at a time will access that code all other will be waiting in queue 
            Thread t5 = new Thread(tl.Display2);
            Thread t6 = new Thread(tl.Display2);
            t4.Start(); t5.Start(); t6.Start(); //output would be perfect as expected
            
            Console.ReadKey();
        }
    }
}
