using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{

    class Student :IComparable<Student>
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Class { get; set; }
        public float Marks { get; set; }


        //will sort in ascending order tosort in descending order return -1 where we return 1 and vice versa
        //to sort according to marks write marks where iD is written
        public int CompareTo(Student other)
        {
            if (this.ID > other.ID)
                return 1;   
            else if (this.ID < other.ID)
                return -1;  
            else
                return 0;
        }
    }

    class testStudent
    {
        static void Main()
        {
          
            Student s1 = new Student { ID = 400, Name = "umair", Marks = 56, Class = 10 };
            Student s2 = new Student { ID = 100, Name = "Ali", Marks = 60, Class = 4 };
            Student s3 = new Student { ID = 200, Name = "Talha", Marks = 26, Class = 10 };
            Student s4 = new Student { ID = 300, Name = "Sohail", Marks = 64, Class = 1 };
            Student s5 = new Student { ID = 250, Name = "Danish", Marks = 12, Class = 9 };

            List<Student> Students = new List<Student>() { s1, s2, s3, s4, s5 };

            //to print
            foreach (Student obj in Students)
            {
                Console.WriteLine(obj.ID + " " + obj.Name + " " + obj.Marks + " " + obj.Class);
            }
            //all the students will be shown as in sequence we entered them in the List but we want to sort 
            //this list according to ID but builtin sort mehtod of the list class don,t work on this as it
            //is a complex list as it has multiple attributs and Sort method get confuse that
            //according to which he should sort so we tell him by implemting (IComparable)inerface to our
            //class and providing iplementation to its compareTo() or telling him sort according to this field e.g ID
            //or in other word if we want to apply sort method on List with UserdefinedClass that class should implement (IComparable) 
            Students.Sort();
            //Students.Reverse();             //  will reverse the order of the list
            Console.WriteLine("\n Sorted by ID ");

            foreach (Student obj in Students)
            {
                Console.WriteLine(obj.ID + " " + obj.Name + " " + obj.Marks + " " + obj.Class);
            }
            Console.WriteLine("\n by Marks ");

            //lets say we don,t have the source code of the Student class and i want to sort students list according
            //to marks but as we don,t have the source code and sort method sorts according to ID as Student has Logic
            //for sortinng by ID so we will create a new class and we will implement IComparer interface to our class
            // and implemt its method Compare() which needs logic for comparing so we will write here logic for comparing 
            // Students by Marks and then we create object of this class and use an overload for Sort Method that takes 
            //IComparer interface obj as parameter but we cannot pass that but its child so we will pass it here 
            //and our list will be sorted according to Marks
            CompareByMarks cbm = new CompareByMarks();
            Students.Sort(cbm);
            foreach (Student obj in Students)
            {
                Console.WriteLine(obj.ID + " " + obj.Name + " " + obj.Marks + " " + obj.Class);
            }
            Console.WriteLine("\nagain ");

            //the fourth overload for the for the sort method takes three parameters first starting index where to
            //startsorting from next is 'count' for telling that sort next n elements after this and third is
            //IComparer interface obj or its child i.e sorting mechanism
            Students.Sort(1,3,cbm); //start from index 1 sort next 3 elements or upto 3 index and cbm is IComparer interface 
            foreach (Student obj in Students)
            {
                Console.WriteLine(obj.ID + " " + obj.Name + " " + obj.Marks + " " + obj.Class);
            }

            Console.WriteLine("\n by Name ");

            //the last overload of the Sort() method is which requires requires a Comparision Delegate So for this
            //first create a method having same signature as Comparision Delegate with logic for sorting logic then
            //pass that method to the comparision delegate as 
            Comparison<Student> CompDel = new Comparison<Student>(CompareName);
            //now pass this comparision delegate as parameter as required
            Students.Sort(CompDel);   //will sort Student List according to Name  
            
            foreach (Student obj in Students)
            {
                Console.WriteLine(obj.ID + " " + obj.Name + " " + obj.Marks + " " + obj.Class);
            }

            //we can simplify this as 
            // i.e directly pass method Name which have same signature, as here delegate required so method can be
            // passed as in this case Delegate object is auto created and this method is assigned to it so direct way  
            Students.Sort(CompareName); 

            //we can even more simplify this as skip method creation and create annonymous method right here as parameter 
            Students.Sort(delegate(Student st1, Student st2) {
                              return (st1.Name).CompareTo(st2.Name);
                          });
            //we can even more simplify this by using Lamda Expression 
            Students.Sort((st1,st2) => (st1.Name).CompareTo(st2.Name));
            
            Console.ReadKey();
        }

        //as we want to campare/sort according to name so logic will be changed as we cannot apply  
        //relational operator on strings  so we use CompareTo() method for comparing two strings 
        public static int CompareName(Student s1,Student s2) {
           return (s1.Name).CompareTo(s2.Name);   //returns 1 is s1 is greater then s2, 0 if equal, -1 s2 is greater so compete logic in one line
        }
    }
    class CompareByMarks : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Marks > y.Marks)
                return 1;
            else if (x.Marks < y.Marks)
                return -1;
            else
                return 0;
        }
    }
}
