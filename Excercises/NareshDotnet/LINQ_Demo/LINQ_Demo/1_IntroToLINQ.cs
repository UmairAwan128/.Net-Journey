using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{   class IntroToLINQ
    {    
        //LINQ(Language Integrated Query) new query lang launched in (.net3.5) . it same as SQL(retrieve data from Table with simple queries) 
        //Before LINQ it was very complex process to search data inside Array or collestion e.g
        //we have an array =>  int[] arr = {12,78,24,18,77,85,26,1,23,45,28,59,76,14,75,95,86,85} and i want to pick
        //all values which are greater then 40 from this array and store under new array but problem arrayare fixed size so
        //first count all the values greater then 40 and declare that size array and move those values in newArray and then sort them..

        //so for this small task(of picking all values which are greater then 40 from array and sort them)
        //we write 5 loops i.e first for counting second for placing values third and fourth for Array.Sort/reverse
        //they will have a code in backend and fifth for displaying the output so its lot of code for this easy
        //task of retrieving data from Array... but if these values are in a table in case of SQL then we will 
        //Just write a query as =>  select col from tbl where col>40 orderby col desc
        //so Microsoft designed linq that is query language not for just Arrays but also for all COllections
        // DataBase Tables , Data Sets , XML Data for all these we can write LINQ query on any of these...


        static void Main(string[] args)
        {
            int[] arr = { 12, 78, 24, 18, 77, 85, 26, 1, 23, 45, 28, 59, 76, 14, 75, 95, 86, 85 };
            int count = 0;
            for (int i=0; i<arr.Length; i++) {  //count all values which are greater then 40 from arr
                if (arr[i] > 40) {
                    count += 1;
                }
            }
            Console.WriteLine("Same Task using Code");
            //declare that size(count=10) array
            int[] newArr = new int[count];
            int j = 0;
            for (int i=0;i<arr.Length; i++) {
                if (arr[i] > 40)
                {
                    newArr[j] = arr[i];
                    j += 1;
                }
            }
            //now for sorting this newArr we use sort them in ascending
            Array.Sort(newArr); //sorts in ascending order
            Array.Reverse(newArr); //sorts in descending order
            for (int i = 0; i < newArr.Length; i++)
            {  //count all values which are greater then 40 from arr
                Console.Write(" "+newArr[i]);
            }

            //so for this small task(of picking all values which are greater then 40 from array and sort them)
            //we write 5 loops i.e first for counting second for placing values third and fourth for Array.Sort/reverse
            //they will have a code in backend and fifth for displaying the output so its lot of code for this easy
            //task of retrieving data from Array... but if these values are in a table in case of SQL then we will 
            //Just write a query as =>  select col from tbl where col>40 orderby col desc
            //so Microsoft designed linq that is query language not for just Arrays but also for all COllections
            //DataBase Tables , Data Sets , XML Data for all these we can write LINQ query on any of these...
            //so what is the syntax for this it's like SQL.. i.e
            //  From <alias> in <Collection|Array|Table> [<Clauses>] select <alias>

            //  From <alias>(i.e like Table it an be name) in <Collection|Array>(i.e KeyWord) [<Clauses>](i.e Groupby,where,orderBy any Condition)
            //  select <alias>(i.e like columns list)        (since Alias is any name of Collection as Array/collection don,t have column name )

            //so lets write query for showing all values/indexes in array i.e like showing columns from Table...
            //i.e like     select * from table          we write as   match it with the syntax above
            //   From i in arr select i;   //i is the name of alias that can be any we skipped here clasuses as optional      
            //and for capturing the reslut of query we will use 'var'(becomes type what type of data is passed to it)
            var result = from i in arr select i;
            //now for our requirment to pick all values from arr which are greater then 40...
            var newArrRes = from i in arr where i > 40 select i;
            //for result in ascending order
            var newArrResAsc = from i in arr where i > 40 orderby i select i;
            //for result in descending order  this query is equvilent to the whole code we write above
            var newArrResDesc = from i in arr where i > 40 orderby i descending select i;
            Console.WriteLine("\n\nSame Task using LINQ Query in one Line");
            foreach(int x in newArrResDesc)
                Console.Write(" " + x);

            //Breaking Down the query according to syntax
            //from i                                    =>  From <alias> (like column as array has only one)     
            //in arr                                    =>  in <Collection|Array>(i.e KeyWord) 
            //where i > 40 orderby i descending         => [<Clauses>](i.e Groupby,where,orderBy any Condition)
            ///select i;                                => select <alias>(i.e like columns list)    

            Console.ReadKey();
        }
        
    }
}
