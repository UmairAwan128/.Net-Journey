using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    //say Program is the class in which we want to add a method and we don,t have source code of that class so   
    //right now Program class contains two methods only
    //step 1. create a new static class so it has all static members so its created here 
    static class HasExtensionMethods  
    {
        //2. define methods in it what you want
        public static void test3(this Program p){     //3. now bind these methods with the class/struct we want..
            //this Program p    means now "this" test3() is binded/added to "Program" class 
            Console.WriteLine("test3()  executed");
        }

        //extension method having one parameter and requires one parameter
        // this Program p    is not input parameter but binding parameter as it has 'this', it must be the first parameter
        public static void test4(this Program p,int i)
        {     //3. now bind these methods with the class/struct we want..
            //this Program p    means now "this" test3() is binded/added to "Program" class 
            Console.WriteLine("test4() executed : "+i);
        }


        // * If an extension method is created/added/binded with the same name and signature of an existing method in the class
        //   so when we call the method the orignal method will be called the extension method will not be added...
        public static void test2(this Program p)
        {     //3. now bind these methods with the class/struct we want..
            //this Program p    means now "this" test3() is binded/added to "Program" class 
            Console.WriteLine("test2() extension Method executed");
        }


        //creating here factorial extension method for the "int" built in struct
        //but we will use here its orignal name i.e goto int class defination by hovering mouse and holing ctrl and click
        //you will see its struct named Int32 so use that here    
        public static long Factorial(this Int32 i) {  //both int or Int32 can be used here
            // i contains the value user assigned in the variable while creating    int x = 10  so in this case i has 10  
            //so no need to have a input parameter..

            if (i == 1 || i == 0)
            {
                return 1;
            }
            else if (i == 2)
            {
                return 2;
            }
            else
            {
                return i * Factorial(i - 1);
            }
        }

        public static string toProper(this String str)
        {  //both string or String can be used here
           // str contains the value user assigned in the variable while creating    String x = "hello"  so in this case str has "hello"  
           //so no need to have a input parameter..

            //all logic will execute if the str has a letter even one not even spaces only so trim method(removes spaces)
            if ((str.Trim().Length) > 0) {  //if after removing spaces length of string is greater then 0 then do this
                String properCase = null;
                str = str.ToLower(); //whole string is in lower
                String[] arr = str.Split(' '); //seperate in the bases of space

                //foreach (var st in arr)
                //{
                //    for (int i = 0; i < 1; i++)
                //    {
                //        arr[0] = arr[0].ToUpper();
                //    }
                //    if(properCase==null)
                //       properCase = st;
                //    else
                //        properCase += st;
                //}


                //or
                foreach (String st in arr)
                {
                    char[] charArr = st.ToCharArray(); //convert first word/(arr index) to char array
                    charArr[0] = char.ToUpper(charArr[0]);  //convert first char to upper
                    if (properCase == null) //i.e first time so = used at start propercase contains null
                       properCase = new String(charArr); //so converted the charArr back to string using the string
                    else                                  //class construcor that takes char array and created
                        properCase += new String(charArr); //string class object so its like converted to string
                    //but as propercase will contain one the word after each iteration not complete so 
                    //concatenate string 
                    properCase += " ";
                }
                return properCase;
            }
            //else
            return str; //as empty str passed so return as it is

        }
    }


    //remember:
    // * The following method will not be accessed by using this class but by the object of the class method is binded to i.e (Program)
    // * Extension methods are defined static but once they are binded to class they become nonstatic thats
    //   why we access test3() in TestExtensionMethod class by using object of Program class not directly... 
    // * If an extension method is created/added/binded with the same name and signature of an existing method in the class
    //   so when we call the method the orignal method will be called the extension method will not be added...
    // * Extension method can have only one binding parameter(e.g this Program p) and it must be the first parameter
}
