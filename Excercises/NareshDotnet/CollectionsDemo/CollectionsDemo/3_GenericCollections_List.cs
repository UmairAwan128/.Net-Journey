using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    //We want to store n integer values what should we choose 

    //Collections are nothing but a Dynamic Array but the problem is they are not type safe
    //i.e we can store differnt type of value on different indexes i.e if we want to store all int values
    //we need to take care of this own our own as there will be no error but it has a feature of autoresizing

    //Whereas Array is type safe i.e all its loction will have same type of values of type what we write while declaring..
    //i.e we will declare it as type int and there will be no error when any other value is tried to stor but problem is we can,t change its size 

    //So We Use Generic Collection they have auto resizeing feature as well as are type safe and has all
    //what collection has i.e ArryList is called here List,Stack,queue,hashtable here is called Dictionary e.t.c but in generic(typeSafe form)...
    //all are under System.Collection.Generic   Namespace(contains collections for storing specified type of values)
    class ListDemo
    {
       static void Main()
        {
            //Its same as ArryList i.e Nongenric Collection only diff is List is Generic i.e ArryList is called here List
            //A Generic Collection LIST that will store n integer values 
            List<int> li = new List<int>();
            li.Add(200); li.Add(100); li.Add(300); li.Add(500); li.Add(800);
            //li.Add(200.25); li.Add("ds"); li.Add('sd'); will not work as List is type safe i.e it accepts integer only 
            for (int i = 0; i < li.Count; i++)  //Count is a readonly property in List class
                Console.Write(li[i] + " ");   //or print using foreach loop
            Console.WriteLine();

            //to insert new item on any index
            li.Insert(2, 50);
            for (int i = 0; i < li.Count; i++)  //Count is a readonly property in List class
                Console.Write(li[i] + " ");   //or print using foreach loop
            Console.WriteLine();

            //to remove item on any index
            li.Remove(3);
            for (int i = 0; i < li.Count; i++)  //Count is a readonly property in List class
                Console.Write(li[i] + " ");   //or print using foreach loop
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
