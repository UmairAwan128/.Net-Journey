using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7NewFeature
{
    public class Employee
    {
        int _Eno;
        string _name, _job;
        double _salary;
        public Employee(int Eno,string name, string job, double salary) {
            _Eno = Eno;
            _name = name;
            _job = job;
            _salary =salary;

        }
        //now here creating a DeContructor it is used to access the private fields of the class like we use property/method for this
        //its a method with out parameters and its name should be      Deconstruct 
        public void Deconstruct(out int Eno, out string name, out string job, out double salary) {
            Eno = _Eno;
            name = _name;
            job = _job;
            salary = _salary;

        }
        
        //Deconstructor overloading can be used if u wana return only some fields not all
        public void Deconstruct(out int Eno, out string name)
        {
            Eno = _Eno;
            name = _name;
            
        }
    }
    class DeconstructorDemo
    {
        static void Main() { 
            Employee emp = new Employee(12, "umair", "manger", 12.5);
            //now to access these values we will use Deconstructor   i.e  Deconstruct
            //    (int Eno, string name, string job, double salary) = emp;  //pass Employee class obj and get all values
            //or call like this
            //   (var Eno, var name, var job, var salary) = emp;
            //or call like this
            var (Eno, name, job, salary) = emp;

            Console.WriteLine("Eno : "+Eno);                        
            Console.WriteLine("name : "+name);
            Console.WriteLine("job : "+job);
            Console.WriteLine("salary : " + salary);
            //calling overloaded Decontruct 
            var (NewEno, Newname) = emp;
            //or better way to access only some fields is nnow we are calling the main Deconstructor and avoid any value by placing there _ 
            var (NewEno1,_,job1,_) = emp;

            Console.ReadKey();
        }
    }
}
