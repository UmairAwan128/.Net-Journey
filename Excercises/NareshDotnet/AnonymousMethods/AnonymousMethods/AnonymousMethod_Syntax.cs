 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    class AnonymousMethod_Syntax
    {
        //in anonymous method we bind a code block to the delgate inspite of binding method..
        public static string Greetings(string name) {
            return "Hello " + name + " a very good morning";
        }

        //step 1 : define delegate
        public delegate string greetingsDelegate(string name);

        static void Main() {
            greetingsDelegate gd = new greetingsDelegate(Greetings);
            string s = gd.Invoke("umair");
            Console.WriteLine(s);
            Console.ReadKey(true);

            //now same thing with annonymous method here method is defined a method using delegate keyword
            //we don,t write here modifiers, return type and name of method, as they will be known from the
            //delegate i.e this anonymous method is assigned to a delegate and his modifiers, return type will be its...
            //we only need to write method body and parameter so its advantage is that we write less
            //to declare method and they are suggested to use when methods body have very less code and
            //if we want to see the logic of the method most often i.e don,t need to wind where method is written..
            greetingsDelegate gdAnonymous = delegate (string name)
                                            { 
                                               return "Hello " + name + " a very good morning";
                                            };
            string s1 = gdAnonymous.Invoke("umair");
            Console.WriteLine(s1);
            Console.ReadKey(true);

        }
    }
}
