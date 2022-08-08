using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiersDemo
{
    //public so accessible from any where
    //class can be public or internal by default its internal
    public class Program
    {
        //all methods have diff modifiers

        //as private so accessible only in the class in which it was defined 
        private void testPrivate() {
            Console.WriteLine("Private Method");
        }

        
        //as Internal so accessible only within the project
        internal void testInternal() {
            Console.WriteLine("Internal Method");
        }

        //only accessible in this class and child class either in this project or other projects 
        protected void testProtected() {
            Console.WriteLine("Protected Method");
        }

        //protected internal has two thing protected and internal if any of these is accessible
        //where we are calling this method then method will be available else not
        //so accessible in same project as internal
        //accessible in child classes in and outside project as protected
        //this method not accessible outside project when instance of this class is created to use it
        protected internal void testProtectedInternal()
        {
            Console.WriteLine("Protected Internal Method");
        }

        public void testPublic()
        {
            Console.WriteLine("Public Method");
        }

        //members of a class like variables and methods are by default private
        void test()
        {
            Console.WriteLine("Method");
        }
        static void Main(string[] args)
        {
            //all methods are accessible in this very class
            
            Program p = new Program();
            p.testInternal();
            p.testPrivate();
            p.testProtected();
            p.testProtectedInternal();
            p.testPublic();

            Console.ReadKey();
        }
    }
}
