using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionsDemo
{
    //Collections are nothing but a Dynamic Array thy are not type safe i.e we can store differnt type of value on different indexes
    //but Array is type safe i.e all its loction will have same type of values of type what we write while declaring..

    //Problems while using Array 
    //we can,t change its size
    //we can,t insert or delete a value from middle of an array
    //To overcome such problems we use Collection i.e nothing but a Dynamic Array which can do all these

    //in C# we don,t need to create either stack,queue as all are builtin in the form of classes called Collections Can be either
    // Non Generic(e.g Stack,queue,LinkedList,ArrayList,HashTable e.t.c  All these are classes under System.Collection NameSpace)
    // Generic     (e.g Stack,queue,ArrayList here is callled List, HashTable here is callled Dictionary e.t.c  All these are classes under System.Collection.Generic NameSpace)

    //Difference b/w array and ArrayList is a common question, its same as diff b/w array and dynamic array
    //in case of Array what we mentioned above that array can,t do or Problems 
    //and ArrayList can do all that things that array can,t as mentioned above and its each index can have different type of value

    class ArrayListDemo
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10]; //normal array but problem is we can,t change its size and never
            Array.Resize(ref arr, 15);  //but Array class has Resize() method but this also not resizes array but
                                        //creates new array of this size move its elements and destroys this/old array 

            ArrayList al = new ArrayList();  //dynamically increases its size as required
            Console.WriteLine("ArrayList Capacity : "+al.Capacity); //as created in start capacity would be 0
            al.Add(10); //as 1 value is added capacity would be 4
            Console.WriteLine("ArrayList Capacity : " + al.Capacity);
            al.Add(13); al.Add(10); al.Add(10); al.Add(20);  //as 5th value is added capacity would be 8 so double each time capacity reached 
            Console.WriteLine("ArrayList Capacity : " + al.Capacity);

            ArrayList al2 = new ArrayList(10);  //or we can give it a capacity as we declare, also if this capacity 
                                               //is reached again it will double i.e 20 then 40

            Console.Write("\n\n\n");

            //To display ArrayList we use foreach loop
            foreach (object obj in al) {
                Console.Write(" " + obj);
            }
            Console.WriteLine();

            //to insert a value in the middle or any location of ArrayList use
            al.Insert(3, 350);  //so on third index add 350 that index value will be moved forward
            al.Insert(1, "umair"); //we can store any type of value even diferent type of vslue on different index
            foreach (object obj in al)  //again display to see changes
            {
                Console.Write(" " + obj);
            }
            Console.WriteLine();

            //to remove any value from list use
            al.Remove(10); //only the first index having value=10 will be removed
            foreach (object obj in al)  //again display to see changes
            {
                Console.Write(" " + obj);
            }
            Console.WriteLine();

            //or remove any value from list using the index position
            al.RemoveAt(1); //value at index 1 will be removed
            foreach (object obj in al)  //again display to see changes
            {
                Console.Write(" " + obj);
            }

            Console.ReadKey();
        }
    }
}
