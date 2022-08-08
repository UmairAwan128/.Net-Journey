using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritenceDemo
{
    class Class1
    {
        private int i;

        //this constructor must also be created in child class as that will call this and this will initialize fields of this class
        //so that child class will use it otherwise it will not use these so error..
        public Class1(int i) {
            Console.WriteLine("Class1 Constructor called"+ i);
            this.i = i;
        }
        public void Test1() {
            Console.WriteLine("Method 1");
        }
        public void Test2()
        {
            Console.WriteLine("Method 2");
        }

        //there are two types of inheritence
        //single(If a classs has one imediate parent class to it)
        //Multiple(If more then one imediate parent class to it)
        //but in C# there is no multiple inheritence in case of classes


    }
}
