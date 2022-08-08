using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7NewFeature
{
    //Pattern Matching means that there will be a method and we will call that forvarious purposes or
    //will be callled by various classes and will have the needed functionality for all of them seprated by conditions

    public class Shape {
        public const float pi=3.14f;  //we declared pi here as in future there may be cone class that will also need pi so defined here not in both  
    }

    public class Rectangle : Shape
    {
        public double width { get; set; }
        public double height { get; set; }
    }
    public class Circle : Shape
    {
        public double radius { get; set; }
    }
    class PatternMatching
    {
        static void Main() {
            Rectangle r1 = new Rectangle { width=12.34, height=56.78 };
            Rectangle r2 = new Rectangle { width = 56.23, height = 56.23 }; //which is a squre as width==height
            Circle c = new Circle { radius = 34.56 };
            printArea(r1);
            printArea(r2);
            printArea(c);
            Console.ReadKey();
        }

        //to recieve here in this method all the shapes/figures passed we required here Shape
        //parameter so either pass it or its child...
        public static void printArea(Shape givenShape) {
            //but as the logic for area of rectangle and circle are completely different so
            //earlier before C#7.0 we first check what shape is this and then convert the Shape
            //variable to the shape e.g rectangle passed i.e...

            //if (givenShape is Rectangle)
            //{  //identify shape
            //    Rectangle rect = givenShape as Rectangle;          //convert to shape passed
            //    Console.WriteLine("Area of rectangle : " + rect.height * rect.width);
            //}
            //else if (givenShape is Circle) {
            //    Circle cir = givenShape as Circle;
            //    Console.WriteLine("Area of Circle : " + cir.radius* cir.radius*Circle.pi);
            //}

            //but the new way intriduced is C#7.0
            //if (givenShape is Rectangle rect)   //here in one line we identify shape and convert and create obj 
            //{  //identify shape
            //    Console.WriteLine("Area of rectangle : " + rect.height * rect.width);
            //}
            //else if (givenShape is Circle cir)
            //{
            //    Console.WriteLine("Area of Circle : " + cir.radius * cir.radius * Circle.pi);
            //}

            //or do this using switch statement which is much better as also can have conditions
            switch(givenShape){
                case Rectangle rect when rect.height==rect.height:  //condition is here as we know about this but this condition should be Before Main 
                    Console.WriteLine("Area of Square : " + rect.height * rect.width);// Rectangle case as if that is before that would be executed and it will never.. 
                break;
                case Rectangle rect:
                    Console.WriteLine("Area of rectangle : " + rect.height * rect.width);
                break;
                case Circle cir:
                    Console.WriteLine("Area of Circle : " + cir.radius * cir.radius * Circle.pi);
                break;

            }
        }
    }
}
