using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    //a delgate holding reference of various methods is a multicast delegate
    class MulticastDelegate
    {

    }

    class Rectangle
    {
        //these both methods have same signature so we will create a single delegate for both 
        public delegate void RectDelegate(double width, double height);
        public void GetArea(double width,double height) {
            Console.WriteLine("Area is : " + (width * height));
        }

        public void GetPerimeter(double width, double height)
        {
            Console.WriteLine("Perimeter is : " + (2*(width + height)));
        }

        //folling is the delegate for the method that takes two double parameter and return double
        public delegate double RectValueDelegate(double width, double height);
        public double GetAreaValue(double width, double height)
        {
            return (width * height);
        }

        public double GetPerimeterValue(double width, double height)
        {
            return (2 * (width + height));
        }
        static void Main() {
            //we want to find area and perimeter of a specific rectangle
            Rectangle r = new Rectangle();
            r.GetArea(12.34,56.78);       //calling
            r.GetPerimeter(12.34, 56.78);

            RectDelegate rd = r.GetArea; // or  RectDelegate rd = new RectDelegate(r.GetArea);
            rd += r.GetPerimeter;  // binding/adding the second method to the delgate instance

            rd.Invoke(12.34, 56.78); // or rd(12.34,56.78) both will call two methods
                                     //so in this way if we want to call all the same methods at once we use this

            //but if the all methods have return type and we assigned them to a delegate so all methods
            //will return value and the delgate will return only the last method return value as it's 
            //being overwritten and finnaly we have return value of the method that execute last
            RectValueDelegate rvd = r.GetAreaValue;
            rvd += r.GetPerimeterValue; //as its last assigned so its value will be return by the delegate
            double result = rvd.Invoke(12.34, 56.78); //will tell result of last method only not the first
            Console.WriteLine(result); //tells only perimeter

            //so when using multicast delegate we should use non value returning methods i.e methods having void return type
            Console.ReadKey();
        }
    }
}
