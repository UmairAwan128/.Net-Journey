using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindsOfVariables
{
    class Program
    {
        public int x = 100;
        public static int y = 200;
        public const int k = 500;
        public readonly int l;
        //its a static block
        static void Main(string[] args)
        {
            int z = 10;   //as inside static block so its by default static
                          //   Console.WriteLine(x);   will not work  as x is not accessible as its not static and method is static 
                          //so non static members required instance of the class to access

            

            Console.WriteLine(k);
            Console.WriteLine(y);

        }
    }
}
