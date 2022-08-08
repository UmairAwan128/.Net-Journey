using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemo
{
    class _5_SpeedComparisionSingle_Multi
    {
        static void IncrementCounter1()
        {
            long count = 0;
            for (long i = 0; i < 10000000; i++)
            {
                count++;
            }
            Console.WriteLine("IncrementCounter1 : " + count);
        }

        static void IncrementCounter2()
        {
            long count = 0;
            for (long i = 0; i < 10000000; i++)
            {
                count++;
            }
            Console.WriteLine("IncrementCounter2 : " + count);
        }

        static void Main() {
            Stopwatch s1 = new Stopwatch();   
            s1.Start();  //will start a timer
            IncrementCounter1();
            IncrementCounter2();
            s1.Stop(); 
            Console.WriteLine("Time Taken by using Single thred : " + s1.ElapsedMilliseconds);

            //now using Multi threaded 
            Thread t1 = new Thread(IncrementCounter1);
            Thread t2 = new Thread(IncrementCounter2);
            Stopwatch s2 = new Stopwatch();
            s2.Start();  //will start a timer

            t1.Start();
            t2.Start();

            s2.Stop();  //will stop timer

            //will make MainThread not to close till thread1 and thread2 complete their task and also holds control here till t1 and t2 completes 
            t1.Join();  //so the line will be printed after t1 and t2 completes
            t2.Join();
            Console.WriteLine("Time Taken when used Multithreaded thred : " + s2.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
