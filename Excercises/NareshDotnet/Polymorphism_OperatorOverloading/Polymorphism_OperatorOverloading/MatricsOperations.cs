using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_OperatorOverloading
{
    //Method Overloading is an approach of definning multiple behaviour to a method based on parameters

    //rembember:    int z=x+y           operators( + , - , * , / )    operanads(a,b,x,y e.t.c)
    //Parameters Overloading is also an approach of definning multiple behaviour to an operator 
    // and those behaviours will vary according to the operand types b/w which operator is used..
    //e.g=>>>  +  operator is addition operator when used b/w two numbers
    //            and is an concatenation operator when used b/w strings..
    //      i.e    number + number => Add operator
    //             string + string => concatenation operator

    //how its done 
    //using operatorMethods e.g operator method for + is and other
    //1. public static int  operator +(int x, int y) 
    //2. public static string  operator +(string x, string y) 
    //3. public static bool  operator ==(string x, string y) 
    //4. public static bool  operator >(int x, int y) 

    //so when we write this
    //int x = 10 + 15;               // 1 method calls
    //string x = "sd" + "sda";       // 2 method calls 
    //bool x = z > b;                //4 method called
    //bool x = str1 == str2;                //3 method called

    // but string x = "sd" - "sda";        //doesnot work as its method/implementation is not created..
    //but we can create this using this syntax
    // <modifer> static <return type> operator <operator>(operand type , operand type){  logic  }
    //we here create logic for adding two matrices using this method

    class Matrix : Object{      //right click on the Object and from drop down select GoToDefination to see code of object class
        public int a, b, c, d;
        public Matrix(int a, int b,int c, int d) {
            this.a = a;
            this.d = d;
            this.b = b;
            this.c = c;
        }

        //method for adding two matrixes
        public static Matrix operator +(Matrix m1, Matrix m2) {

            Matrix result = new Matrix(m1.a+m2.a, m1.b + m2.b, m1.c + m2.c, m1.d + m2.d);
            return result;
        }

        //method for subtracting two matrixes
        public static Matrix operator -(Matrix m1, Matrix m2)
        {

            Matrix result = new Matrix(m1.a - m2.a, m1.b - m2.b, m1.c - m2.c, m1.d - m2.d);
            return result;
        }

        //we overrided here the ToString method from Object class as its default functionality is to 
        //return fully qualified name but as i want that my class toString to return me the values of
        //all the indexes of the matrix in a specific format so we did this here..
        
        public override string ToString()
        {
            return a+"  "+b+"\n "+c+"  "+d;
        }
    }
    class MatricsOperations 
    {
        static void Main() {
            Matrix m1 = new Matrix(20, 18, 16, 14);
            Matrix m2 = new Matrix(10, 8, 6, 4);
            //we can add these two as
            // Matrix m3 = new Matrix(m1.a+m2.a, m1.b + m2.b, m1.c + m2.c, m1.d + m2.d);
            //but we want to do this using the method as but we get error which says no method to add two matrixs
            Matrix m3 = m1 + m2;   //so we created a method in the matrix class
            Matrix m4 = m1 - m2;   //benifit is we don,t need to rewrite the code and
            Matrix m5 = m1 + m2 + m3 + m4;  //we can add as much matrix as we can
            Console.WriteLine("\n "+m4);
            Console.WriteLine("\n " + m3);
            Console.WriteLine("\n " + m5);

            //what happens when writeline function is called with obj so whats inside it
            //public static void WriteLine(object value){        
            //     string typeName = value.ToString();     //first toString is called of which the obj is recieved
            //     WriteLine(typeName);                      
            // }
            //as by defult toString method returns name of class so fully qualified name of class is returned
            //then that name is passed to again itsself i.e its another overloaded WriteLine method  that
            // that taked string as a parameter which prints the fully qualified name Of the Class.....
            //remember WriteLine method has +9 overloaded methods
            Console.ReadLine();
        }
    }
}
