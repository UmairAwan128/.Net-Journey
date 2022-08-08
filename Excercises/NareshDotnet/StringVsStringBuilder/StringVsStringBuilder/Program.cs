using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//for the string Builder class we need
using System;
using System.Text;
using System.Diagnostics;//for the StopWatch class

namespace StringVsStringBuilder
{
    class Program
    {
        // String/string are immutable we can never nevery change/manipulate the value of the string/String
        // but what about concatenation, lets take an example...
        //string str = "Hello";     //so in the heap we get some space for the the word "Hello"
        //str += str + "World";     //now the str contains "Hello world" so in the heap again some memory
        //will be allocated for this now "Hello World" but still previous value/str
        //"Hello" also present i.e both are there but now str is referencing to "Hello World"

        //str += str + "Umair";     //again concatenation so now str contains "Hello World Umair" also both pre values
        //are present in heap but now str is referencing to "Hello World Umair" so its like
        //waste of sapace this tells that string/String is immutable/un_changeable once declared  

        //upper three lines are same as these three in both seperate mem is all three strings take seperate memory
        //string str = "Hello";         //str = "Hello"
        //string str1 = str + "World";  //str1 = "Hello World"
        //string str2 = str + "Umair";  //str2 = "Hello World Umair"

        //so when to use these string/String use them when after creating String you require very less or no
        // modification/manipulation in the value of the string as each change will create a copy but 
        //incase we nedd a string whose value changes very frequently we use StringBuilder as its mutable...


        //StringBuilder:  (mutable)  
        //declared as:   
        //StringBuilder sb = new StringBuilder("Hello");   //here the size of the string is 16 by default and now "sb" is consuming 5 out of 16
        //here we don,t have concatenation but Append() method so:
        //sb.Append(" World");   //so sb value is updated to "Hello World" and its size is also 16 and now "sb" is consuming 11 out of 16
        //sb.Append(" America"); //so sb value is updated to "Hello World America" and its size is updated 32(i.e mul by 2 as all 16 filled) and now "sb" is consuming 19 out of 32(new size)
        //when 32 filled sb size gets to 64 and so on

        //also performance problems in string/String as multiple copies i.e (n+1)(1 orignal + n copies(of modification)) but not
        //in StringBuilder as only one string so stringbuilder is fast also lets check this practically
        static void Main(string[] args)
        {
            //to measure time for each loop to complete we use stopwatch class
            Stopwatch swString = new Stopwatch();
            swString.Start(); //notice the loop start time
            string s = "";//creating an empty string
            for (int i=1; i<100000; i++) {
                s = s + i; //so 100000 copies of sring will be generated 
            }
            swString.Stop(); //notice the loop stop time


            Stopwatch swStringBuild = new Stopwatch();
            swStringBuild.Start();
            StringBuilder sb = new StringBuilder(); //creating an empty string
            //StringBuilder sb = new StringBuilder(50) //also you can specify size at the time of creation if u know size you will consume
            //so here sb size starts with 50 capacity if 50 gets full then its size become 100 i.e mul by 2 and so on                                               
           for (int i = 1; i < 100000; i++)
            {
                sb.Append(i); //so 100000 times stringBuilder(sb) will be updated 
            }
            swStringBuild.Stop();

            Console.WriteLine("Time taken by the string class in milliseconds : " + swString.ElapsedMilliseconds);
            Console.WriteLine("Time taken by the stringBuilder class in milliseconds : " + swStringBuild.ElapsedMilliseconds);
            //40619 millisec taken by string class
            //51 millisec taken by stringBuilder class
            //its huge difference which tells stringBuilder is very fast then string

            Console.ReadKey();

        }
    }
}
