using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace CollectionsDemo
{
    //HashTable is also like ArrayList its a key value pair its benifit is its key can of any type we want and we give it while we assign value
    //all the collections are key value pair e.g ArrayList also has key i.e its index of type int but problem is we can,t change its type.
    class HashTableDemo
    {
        static void Main() { 
          Hashtable ht = new Hashtable();
            //if we want to store such values we will use hash table then ArrayList as it will be difficult to rember int indexes of each value
            ht.Add("Eid",1011); //first is key and second is value against that key ( both can be of any type)  
            ht.Add("Ename", "Scott");   //both parameters are object type so they can be of any type  
            ht.Add("Job", "Manager");
            ht.Add("Salary",5200.50);
            ht.Add("Address", "Lahore");
            ht.Add(2, "Pakiistan");//both parameters are object type so they can be of any type

            Console.WriteLine("Salary : "+ ht["Salary"]);  //to get any value
            //to access all the values
            foreach (object value in ht.Values) { 
                Console.WriteLine(" " + value);  
            }
            Console.WriteLine("\n\n");
            //to access all the Keys
            foreach (object key in ht.Keys)
            {
                Console.WriteLine(key + " : " + ht[key]);  
            }

            //the output will not be in same sequence as we entered values in the hashtable as we know every value
            //has a key either in Array or Hashtable and imp is every key has a HashCode, HashCode is an integer
            //value can be +ve/-ve insort every string has HashCode and also every class has a method GetHashCode()
            Console.WriteLine(  "umair".GetHashCode());
            Console.WriteLine("\n\n\nGetting GetHashCode");
            foreach (object key in ht.Keys)
            {
                Console.WriteLine(key + " : " + key.GetHashCode());
            }

            //so for a key there will be a hash code value and according to that value and using HashingAlgo above values are sorted and sotred in HashTable
            //also what we get from here is every item has three things key,value and HashCode
            //as here we fetch data according to hashCode so its very fast then ArrayList and others
            Console.ReadKey();
        }

    }
}
