using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7NewFeature
{
    //Literal is just a value against a variable/type e.g 10,"umair",false
    //every literal has a type 10=int,"umair"=string,false=bool how computer store these as
    // first convert to value to Ascii then to binary e.g   'A' => 65 => 10000001 this binary value is stored
    class BinaryLiterals_DigitSeperators
    {
        static void Main() {
            //can we give/store binary value so we use 0b for this that will be written at start
            var itsInt = 1000001;
            var binary = 0b1000001;  //binary is int type but here it stores binary value
            Console.WriteLine("its"+ itsInt.GetType()+" : " + itsInt);
            Console.WriteLine("its" + binary.GetType() + " : " + binary +" in char form " + Convert.ToChar(binary));
            //like this every character has a binary value

            //now the digit seperator '_' its introduced to increase readablility of specially large int values e.g
            long lessReadable = 1000000000;  //less readable as we will count zeros to understand the value its hundred corore
            long MoreReadable = 1_00_00_00_000;  //more readable easy to count zeros
            Console.WriteLine(lessReadable + " : " + MoreReadable); //both values are same
            


            Console.ReadKey();


        }
    }
}
