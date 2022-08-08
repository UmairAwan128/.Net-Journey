using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaterDeligate
{
    class Program
    {
        static void Main(string[] args)
        {                        
            
            Validate<string> n = ValidateStudent.ValidateNameMethod;
            Validate<int> r = ValidateStudent.ValidateRollNoMethod;
            Student s = new Student();
            s.inValidEvent += (d,e) => e.InValidInput();
            s.Name = "a";
            s.Name = "umair";
            s.RollNo = -12;
            s.RollNo = 12;
            s.Name = "u";
            s.RollNo = -1;

            Console.WriteLine($"Name : {s.Name} \n RollNo : {s.RollNo}");
            Console.ReadKey();
        }
    }
}
