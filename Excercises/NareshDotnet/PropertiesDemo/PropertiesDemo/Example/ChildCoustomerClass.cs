using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesDemo.Example
{
    internal class ChildCoustomerClass : Coustomer
    {
        public ChildCoustomerClass(bool status, string custName, double Balance, Cities city, string state) : base(status, custName, Balance, city, state)
        {
        }

        public static void Main()
        {
            ChildCoustomerClass c = new ChildCoustomerClass(true, "umair", 2000, Cities.Peshawar, "sarahad");
            c.State = "punjab";  //so set part of the property is accessible here
            Console.WriteLine("Coustomer State Modified in child:" + c.State);

        }
    }
}
