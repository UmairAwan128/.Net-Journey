using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    //HashTable here in Generic Collection is callled Dictionary so both are same but Dictionary is type safe 
    //as we tell both types of key and value while declaring it

    //the output will be in same sequence as we entered values in the Dictionary 

    class GenericCollection_Dictionary
    {
        static void Main() {
            //first we did same thing what we did using hashtable 
            Dictionary<string, object> dt = new Dictionary<string, object>();  
               
            dt.Add("Eid", 1011); //first is key and second is value against that key W  
            dt.Add("Ename", "Scott");
            dt.Add("Job", "Manager"); 
            dt.Add("Salary", 5200.50);
            dt.Add("Address", "Lahore");
            Console.WriteLine("Salary : " + dt["Salary"]);  //to get any value

            Console.WriteLine("\n\n");
            //to access all the Keys
            foreach (string key in dt.Keys)  //if we used here object then unboxing was needed
            {
                Console.WriteLine(key + " : " + dt[key]);
            }
            //the output will be in same sequence as we entered values in the Dictionary 
            

        }
    }

    class Coustomer {
        public string Name { get; set; }
        public int ID { get; set; }
        public string City { get; set; }
        public double Balance { get; set; }
    }

    class testCoustomer
    {
        static void Main() {
            //we can also use userdefined type in Dictonary or List
            List<Coustomer> coustomers = new List<Coustomer>();

            //ArrayList ar = new ArrayList();  arraylist hashtable can also do this but problem is that is not typeSafe 
           
            Coustomer c1 = new Coustomer{ ID=100, Name="umair", Balance=56000, City="lahore"  };
            Coustomer c2 = new Coustomer { ID = 500, Name = "ali", Balance = 5600, City = "lahore" };
            Coustomer c3 = new Coustomer { ID = 200, Name = "cs", Balance = 500, City = "laho" };
            Coustomer c4 = new Coustomer { ID = 400, Name = "usd", Balance = 5000, City = "hore" };
            //now add them to list
            coustomers.Add(c1); coustomers.Add(c2); coustomers.Add(c3); coustomers.Add(c4);

            //ar.Add(c1); ar.Add(c2); ar.Add(c3); ar.Add(c4);
            
            //to print
            foreach (Coustomer obj in coustomers) {
                Console.WriteLine(obj.ID+" "+ obj.Name + " " + obj.Balance + " " + obj.City);
            }

            Console.ReadKey();
        }
    }
}
