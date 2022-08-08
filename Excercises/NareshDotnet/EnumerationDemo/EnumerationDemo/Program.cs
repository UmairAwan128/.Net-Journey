using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationDemo
{
    //enum is also a userdefined data type we can also define it under the class or struct but better is to define it outside 
    //when we have a list of supported values under a variable we want the user to select the value for
    //the variable from that list

    //enum is value type and by default all its values are int type i.e we assign them integer value
    //but it suports all int types these are 8 e.g byte,short,int,long,uint,ushort,ulong,ubyte by default its int
    public enum Days : byte {  //so now it can have byte values 

        //by default values are assigned starting from 0 like 0,1,2....  so next value is +1 of pre if not assigned
        //but we can force fully assign values
        //remember : names are not important but type as we cannot represent every thing with name i.e
        //e.g there are millions of colors some of them have a name all other have a RGB value i.e an integer
        Monday = 12,Tuesday =15,Wednesday,Thursday = 18,Friday,Saturday=34,Sunday
    }

    class Program
    {

        //e.g we need to schedule a day for meeting so creating property
        public static Days MeetingDay
        {
            get; set;
        } = Days.Monday;   //here we write default value for the property so default meeting day is Monday

        static void Main(string[] args)
        {
            //Console Color is a built_int enum having a group of color
            //right click Console Color and select Go to Def from dropdown to see color it supports 
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("umair");

            //how a value is assigned to an enum type
            Days d = 0;  //first value of enum can be directly accessed without conversion
            Console.WriteLine(d);
            d = (Days)1;    //d = 1; //will not work as to access 2nd and later values of enumn we need to type cast value to Days(enum type)
            Console.WriteLine(d);
            d = (Days)5;
            Console.WriteLine(d);
            d = Days.Friday;  //also another way 
            Console.WriteLine(d);
            d = Days.Thursday;  //to get integer value for the enum value
            Console.WriteLine((int)d);

            //to get all the values of the enum we used foreach loop
            //as GetValues need Type obj so we used typeof() method 
            foreach (byte i in Enum.GetValues(typeof(Days))) {
                Console.WriteLine(i+" : "+(Days)i); //will type cast int to Days(name of day)
            }
            foreach (string s in Enum.GetNames(typeof(Days)))  //for names of enum
            {
                Console.WriteLine(s);
            }

            //accessing here the property
            Console.WriteLine("Meeting day is : " + MeetingDay);
            MeetingDay = Days.Friday;   //the benifit here is user cannot write any value out of the list and also see the options
            Console.WriteLine("Meeting day changed to : "+MeetingDay);
            Console.ReadKey();
        }
    }
}
