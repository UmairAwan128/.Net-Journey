using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemo
{
    class ThreadPriorities
    {
        //we can prioritise threads as some threads can have more priority then other i.e they need more cpu resources then other
        //or in case of two threads both have differnt task and the task of thread is larger then the task of thead1 so if we prioritise
        //the thread2 with higher priority then thread1 so thread2 will start first and have more cpu resources then thread1
        //and in this way we may improve the overall time taken by the program  

        //by default all the thrads have normal priority so all have equal resources
        //we can assign them 5 prioites lowest,below normal,normal, above normal, highest
        //so lowest will be using the least cpu resources and highest will be using the highest

        static long count1, count2;

        public static void IncrementCoun1() {
            while (true)          //infinit loop
                count1 += 1;
        }
        public static void IncrementCoun2()
        {
            while (true)
                count2 += 1;
        }

        public static void Main() {
            Thread t1 = new Thread(IncrementCoun1);
            Thread t2 = new Thread(IncrementCoun2);
            Thread t3 = new Thread(IncrementCoun1);
            Thread t4 = new Thread(IncrementCoun2);

            t1.Start();
            t2.Start();


            //as both method have infinite loop so no one will stop so we can stop them using but we should not use it 
            //directly but we want to stop them after running them for 10 sec we can do this by making MainThread to sleep
            //or generating a pause here
            Console.WriteLine("MainThread is Going to sleep");
            Thread.Sleep(10000);  //as we are in Main Method which is called by MainThread So MainThread will Slepp using this
                                  //but t1 and t2 will keepdoing their work as they have been started 
            Console.WriteLine("MainThread is awaken");
            //as the MainThread WakeUp It will Terminate these threads
            t1.Abort();
            t2.Abort();

            //this will make the MainThread not going to close
            t1.Join();
            t2.Join();
            //as we didn,t assigned the threads any priorities so here both will have approximatley same value or either count1 is bit larger or count2 then other
            Console.WriteLine("Before assigning The Priorites either can be larger then other :");
            Console.WriteLine("Count1 : " + count1);
            Console.WriteLine("Count2 : " + count2);




            count1 = count2 = 0;

            //but after assigning the Priorities always count1 will have larger value
            t3.Priority = ThreadPriority.Highest;
            t4.Priority = ThreadPriority.Lowest;


            t3.Start();
            t4.Start();


            Console.WriteLine("\n\nMainThread is Going to sleep");
            Thread.Sleep(10000);   
            Console.WriteLine("MainThread is awaken");
            //as the MainThread WakeUp It will Terminate these threads
            t3.Abort();
            t4.Abort();

            //this will make the MainThread not going to close
            t3.Join();
            t4.Join();

            
            Console.WriteLine("After assigning The Priorites Count1 will be larger then Count2 as Count1 has larger priority :");
            Console.WriteLine("Count1 : " + count1);
            Console.WriteLine("Count2 : " + count2);

            Console.ReadKey();
        }
    }
}
