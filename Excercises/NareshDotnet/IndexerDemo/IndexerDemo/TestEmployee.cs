using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerDemo
{

    public class TestEmployee
    {
        static void Main(string[] args)
        {
            //once a class creates an indexer it starts working like a virtual array 
            Employee emp = new Employee(1001, "scoot", "manager", 21000, "Sales", "lahore");
            Console.WriteLine("Eno : "+ emp[0]);  //calling the get part of the indexer in Employee class
            Console.WriteLine("Ename : " + emp[8]); 
            Console.WriteLine("Job : " + emp[2]);
            Console.WriteLine("Salary : " + emp[3]);
            Console.WriteLine("Dname : " + emp[4]);
            Console.WriteLine("Location : " + emp[5]);
            
            emp[0] = 2001;  //setting new empNo  i.e  calling set of the indexer in employee class 
            emp[8] = "umair";
            Console.WriteLine("new Eno : " + emp[0]);  
            Console.WriteLine("new Ename : " + emp[8]);
            Console.ReadKey();

            //accessing the emplyee class using string indexer as now we have two indexers i.e int,string so its 
            //indexer overloading
            Console.WriteLine("Eno : " + emp["Eno"]);  //calling the get part of the indexer in Employee class
            Console.WriteLine("Ename : " + emp["Ename"]);
           
            emp[0] = 3001;  //setting new empNo  i.e  calling set of the indexer in employee class 
            emp[8] = "ali";
            Console.WriteLine("new Eno : " + emp["Eno"]);
            Console.WriteLine("new Ename : " + emp["Ename"]);
            Console.ReadKey();

        }
    }
}
