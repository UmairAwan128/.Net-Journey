using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7NewFeature
{


    class Ref_PointerVaribales
    {

        //earlier we can use ref as method parameter but now we can use it as local variable
        //we cannot use ref on List
        static void Main() {
            string[] colors = { "Red","Blue","Green","Black","Purple","Magenta","Yellow" };
            Console.WriteLine(String.Join(" ",colors));  //Join method converts all values of array to single string based on first pararmeter i.e seperator " "
            string color = colors[3];   //taking a value from Colors array
            Console.WriteLine("color taken : "+color);
            color = "White";  //changing the value of color 
            Console.WriteLine("color taken changed : " + color);
            Console.WriteLine(String.Join(" ", colors));  // but this changing didnot effected the orignal array value
                                                          //but we can do such thing using ref type so again do 
            Console.WriteLine("\n\nNow using Ref :\n ");
            ref string refColor = ref colors[4];   //taking a value from Colors array
            Console.WriteLine("color taken : " + refColor);
            refColor = "White";  //changing the value of color 
            Console.WriteLine("color taken changed : " + refColor);
            Console.WriteLine(String.Join(" ", colors));  // but this time changes applied
            //as its(refColor) is like pointer i.e pointing to that index so if now if its value 
            //changes orignal will also change as both are same...
            //if colors Array is destroyed it will have no impact on color variable i.e
            
            //colors = null; //main array destroyed
            //Console.WriteLine("color taken : " + refColor);  //remains not effected

            Console.WriteLine(" \n\n Using the Methods\n\n"); 

            //now lets talk about ref in case of returntype //first see this simple
            Console.WriteLine(String.Join(" ", colors));  
            string colorReturned = GetIndexColor(colors, 3);   
            Console.WriteLine("color passed : " + colorReturned);
            colorReturned = "purple";  //changing the value of color 
            Console.WriteLine("color passed changed : " + colorReturned);
            Console.WriteLine(String.Join(" ", colors));  // but this changing didnot effected the orignal array value

            //now calling GetIndexColorRef() method
            Console.WriteLine(String.Join(" ", colors));
            ref string colorReturnedRef = ref GetIndexColorRef(colors, 3);
            Console.WriteLine("color passed Ref : " + colorReturnedRef);
            colorReturnedRef = "purple";  //changing the value of color 
            Console.WriteLine("color passed changedRef : " + colorReturnedRef);
            Console.WriteLine(String.Join(" ", colors));  // changing effected the orignal array value



            Console.ReadKey(); 
        }

        public static string GetIndexColor(string[] colors, int index)
        {
            return colors[index];
        }

        public static ref string GetIndexColorRef(string[] colors, int index)
        {
            return ref colors[index];
        }
    }
}
