using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSharp7NewFeature
{
    
    //The First feature is to return more then one values from a method...
    class ReturnMultipleValues
    {
        //lets try to return two values 
        public int SimpleMethod(int a, int b) {
            int c = a + b;
            int d = a * b;
            return c;   //when control reach here it exits the loop
            return d;   //the control will never come here so only c will be returned
        }

        //this is the new feature in which we can skip return type and pass two ref type parameters to method and it will change there
        //value and return there refernce back from where it was called...
        public void refMethod(int a, int b,ref int c,ref int d)
        {
            //we can also skip the code or body of this method as ref parameters values are initialized while calling this method
            //so we can skip initializing values to c and d
            Console.WriteLine(c + " " + d);  //works here

            c = a + b;
            d = a * b;

        }

        public string refMethodWithReurn(int a, int b, ref int c, ref int d)
        {
            c = a + b;
            d = a * b;
            
            return "using Ref Method";
        }
        
        //another way is using out keyword inspite of Ref both does same work but only difference is we canot skip the code/body inside
        //i.e the values c and d must be initialized in the method as while calling what values we pass don,t come here in c and d..
        public void outMethod(int a, int b, out int c, out int d)
        {
            //so we can not skip initializing values to c and d as while calling what values we pass don,t come here in c and d i.e
           //Console.WriteLine(c + " " + d); //will not work here as c, d are not initialized
            c = a + b;
            d = a * b;
          
        }

        public string outMethodWithReturn(int a, int b, out int c, out int d)
        {
            c = a + b;
            d = a * b;
            return "using Out Method";

        }

        //the third way is using the builtin Tupel class so return type will be this and using it we can return upto 8 values so
        public Tuple<int, int> tupelMethod(int a, int b) { //so this class needs a Tuple class Generic object as return type which want two values
            int c = a + b;
            int d = a * b;
            Tuple<int, int> t = Tuple.Create(c,d);  // calling create method Create Tuple with two values and stored it in t
            return t;
        }
        //shorter and new way of using Tuple here we don,t write Tuple but its by default tuple or will be auto

        //public (int sum, int product) newtupelMethod(int a, int b)           //commented as not working 
        //{   int c = a + b;
        //    int d = a * b;
        //    return (c,d);
        //}

        static void Main(string[] args)
        {
            ReturnMultipleValues obj = new ReturnMultipleValues();
            int m = 10;  int n = 20; //we cnnot skip initialization here as these two values will get into method and assigned to c and d the ref parameters 
            obj.refMethod(10, 20,ref m, ref n); //the method will be called and these m and n values will be assigned to c and d and in
                                                //the method after performing computation on these c and d will be return back and we will use them here no need to recieve 
                                                //after calling there values will be changed its like reference/address in memory we changed its value so its changed for every body..
            Console.WriteLine(m + " " + n);
            //if return type
            Console.WriteLine(obj.refMethodWithReurn(10, 20, ref m, ref n));

            int o = 10; int p = 20;
            obj.outMethod(10, 20, out o, out p);
            //as while calling what values we pass don,t get to mehtod in c and d so we can skip method declaring/initialing and do it right there
            obj.outMethod(10, 20, out int l, out int r);
            Console.WriteLine(o + " " + p);
            Console.WriteLine(l + " " + r);

            //calling the Tuple method
            Tuple<int,int> result = obj.tupelMethod(10, 20);
            Console.WriteLine(result.Item1 + " " + result.Item2);  //to access the values returned use item 1 to n variables u returned
            //calling the newtupelMethod()  that is commented as was not working
            // var (SumRes,ProdRes) = obj.newtupelMethod(100,25)   //call it as this Sumres have first res and ProdRes has second res
            //Console.WriteLine(SumRes + " " + ProdRes);
            // var result = obj.newtupelMethod(100,25)   //or call it as
            //Console.WriteLine(result.sum+ " " + result.product);   //as we named the returning variables in method so we access them using there name 


            Console.ReadKey();
        }
    }
}
