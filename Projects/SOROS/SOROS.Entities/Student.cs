using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOROS.Entities
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Class Class { get; set; }
        public int Class_ID { get; set; }  //like foreignkey not needed
    }
}
