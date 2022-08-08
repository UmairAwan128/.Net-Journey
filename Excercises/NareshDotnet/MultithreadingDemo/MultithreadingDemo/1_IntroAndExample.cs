using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingDemo
{
    class Program
    {
        //Operating System has a group of processes..
        //Taskmanager has some processes each process is executing an application(e.g google chrom)
        //background processes are windows service(application OS is running for us)
        //process use thread to run (the code inside an) appliction

        //Every application has a logic and to run that logic a thread is used
        //Every application has bydefault one thread to execute logic that is called Main thread its not the main method 
        //so every application is by default single threaded application

        //Drawbacks in SingleThreaded Application
        //as only one thread so only it will run all the program code/logic in a sequence we write code so actions are
        //completed one after the other and if any action fails/delays then actions after it will not/be execute/delayed

        //so overcome this problem we use multiThreading
        // multiThreading(under one process we have multiple threads for the same application where each thread 
        //                is executing a specific part/methods of the application/code )  
        // so execution will be simultaneous i.e OS will allocate some timeperiod for each thread to execute e.g 1 sec 
        //so when execution starts OS give 1 sec to test1() and it will execute some of its instruction then after this 1 sec to test2() and
        // then it will execute its some code then  Test3() and then agin test1() then agiain test2,test3 and soon till all comletes 
        //but if test2() fails/delays() for any reason both test1() and test2() will be executing simutaneously by skiping test2().. 
        // so all threads have equal importance/priority and its benifit is maximum ustilization of cpu resources but its not parallel execution
        //is so fast that it looks parallel
        static void Main(string[] args)
        {
            //CurrentThread is static property in Thread class it returns he reference of current Thread that will execute this applicaion or default thread
            Thread t = Thread.CurrentThread;  //by default thread does not have a name
            t.Name = "MyThread"; //assigning name to the current Thread that will execute this applicaion

            //SingleThreaded();     //as only one thread so only it will run all the program code/logic in a sequence we write code so methods are called/completed one after the other
                                    //but problem here is if Test2() has database code and when test2() is called there may be a delay of 5 or 10 sec for connecting to Database
                                     //and after this delay test2() will execute and after test2(), test3() will execute 
                                    //also if Test2() has any error/exception then Test3() will also not execute and program crash..

            //as for multitreading each method test1(),test2(),test3() will be executed by a seperate thread so creating them                       
            MultiThreaded();

            //A thread exits once it completes its task so MainThread/MyThread exits after doing its task
            //i.e its task is creating and starting his childThreads(threadForTest1,2,3) so after this it will exit..
            Console.WriteLine("MainThread/MyThread  is  exiting 2 ");

            Console.WriteLine("Program executed using thread : "+Thread.CurrentThread.Name );
            Console.ReadKey();

        }

        static void SingleThreaded() {
            Test1();
            Test2();
            Test3();
        }

        static void MultiThreaded()
        {
            //as for multitreading each method test1(),test2(),test3() will be executed by a seperate thread so creating them                       
            Thread threadForTest1 = new Thread(Test1);  //takes method/delegate as parameter
            Thread threadForTest2 = new Thread(Test2);
            Thread threadForTest3 = new Thread(Test3);
            //now there are four threads in the program one is MainThread that will be allways there and rem 3 we created
            //these 3 threads are child of the MainThread(named above MyThread)

            threadForTest1.Start();  //to start thread or execute method
            threadForTest2.Start();
            threadForTest3.Start();

            //A thread exits once it completes its task so MainThread/MyThread exits after doing its task
            //i.e its task is creating and starting his childThreads(threadForTest1,2,3) so after this it will exit..

            //but if we want MainThread/MyThread to exit last i.e after its all child threads complete their task we use Join method for all the child threads
            threadForTest1.Join(); threadForTest3.Join();
            threadForTest2.Join(4000); // means when threadForTest2 starts after 4 sec Mainthread will now exit 
            Console.WriteLine("MainThread/MyThread  is  exiting ");

        }


        static void Test1() {
            for (int i=1;i<=50;i++) {
                Console.WriteLine("Test1 : "+i);
            }
            Console.WriteLine("threadForTest1  is  exiting ");
        }

        static void Test2()
        {
            for (int i = 1; i <= 60; i++)
            {
                Console.WriteLine("Test2 : " + i);

                if (i==50) {
                    Console.WriteLine("MyThread/threadForTest2 is going to sleep");  //as MyThread we named abive is executing the application so it will sleep
                    //this will make the current thread sleep for 5 sec so nothing will be done in these 5 sec
                    Thread.Sleep(5000);  //its like a delay for connecting to Database for 5 sec will make the 'threadForTest2' sleep not all because of Test2() is called by this thread so this will only sleep
                    Console.WriteLine("MyThread/threadForTest2 is awaken ");
                }
            }
            Console.WriteLine("threadForTest2  is  exiting ");
        }
        static void Test3()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine("Test3 : " + i);
            }
            Console.WriteLine("threadForTest3  is  exiting ");
        }

    }
}
