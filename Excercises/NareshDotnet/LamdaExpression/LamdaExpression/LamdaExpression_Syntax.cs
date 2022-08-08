using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpression
{
    //as we anonymous method is short way of writting a method(there we skip writting name,return type,modifier) of method
    //and lamda expression is short way writting the  "annonymous method" so a shorter way of writting metods even. 

    //so first create a delegate
    public delegate string GreetingDelegate(string name);
    class LamdaExpression_Syntax
    {
        static void Main(string[] args)
        {
            //instantitaing th delgate using method
            GreetingDelegate gd = new GreetingDelegate(Greetings);
            //invoking the method
            string s = gd.Invoke("umair");
            Console.WriteLine(" using the method\n" + s);
            Console.ReadKey(true);  //true means the keywod enterd will not be displayed

            //instantitaing th delgate using Annonymous method so no need of outside method
            GreetingDelegate gdAnnonymous = delegate (string name)   
                                            {
                                                return "hello " + name + " a very good morning";
                                            };
            //invoking the method
            string s1 = gdAnnonymous.Invoke("Anonymous");
            Console.WriteLine(" \nusing the Anonymous method\n" + s1);
            Console.ReadKey(true);  //true means the keywod enterd will not be displayed

            //instantitaing th delgate using lamda expression shorter way of writting annonymous method
            //above in annoymous we were writting   delgate keyword additionly and type of  parameters that 
            //is also known to the delegtae... so in lamda expression we skip these two also so 
            GreetingDelegate gdLamda = (name) =>             // (=>) is the lamda operator
            {
                return "hello " + name + " a very good morning";
            };
            //invoking the method
            string s2 = gdLamda.Invoke("Anonymous");
            Console.WriteLine(" \nusing the Lamda expression method\n" + s2);
            Console.ReadKey(true);  //true means the keywod enterd will not be displayed

        }

        public static string Greetings(string name) {
            return "hello " + name + " a very good morning";
        }
    }
}
