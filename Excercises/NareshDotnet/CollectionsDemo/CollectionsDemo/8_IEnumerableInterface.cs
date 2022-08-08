using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo
{
    //IEnumerable interface is parent of all the Collection classes
    //all Collection Classes are definded like this 
    //base or at top its IEnumerable under this we have ICollection under this we have IList and IDictionary
    //All the classes which use index to store value Inherit from IList Like ArrayList,List class
    //All the classes which have a key value combination Inherit from IDictionary Like HashTable,Dictionary class 
    //So in Case of Dictionary it implements IDictionary,Icollection,IEnumerable as its interface not class so all will be implemented here
    //and in Case of List it implements IList,Icollection,IEnumerable

    //  Also on the basis of IEnumerable interface foreach loop works IEnumerable has GetEnumerator() method
    // that all collections implement so foreach loop work for them
    class Employee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }

    }

    class TestEmployee {
        static void Main() {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { ID = 101, Name = "Sohail", Job = "Manager", Salary = 25000.00 });
            employees.Add(new Employee { ID = 102, Name = "Talha", Job = "Saleman", Salary = 15000.00 });
            employees.Add(new Employee { ID = 103, Name = "Umair", Job = "Analyst", Salary = 35000.00 });
            employees.Add(new Employee { ID = 104, Name = "Haris", Job = "Salesman", Salary = 55000.00 });
            employees.Add(new Employee { ID = 105, Name = "Ali", Job = "Clerk", Salary = 26000.00 });
            employees.Add(new Employee { ID = 106, Name = "Ahmed", Job = "Salesman", Salary = 29000.00 });

            foreach (Employee obj in employees)
            {
                Console.WriteLine(obj.ID + " " + obj.Name + " " + obj.Salary + " " + obj.Job);
            }
            Console.WriteLine("\n\n");


            //here we will use our created class we want it to work like a collection or List class we created Add()
            //method in it also so
            Organiztion OrgEmploy = new Organiztion();
            OrgEmploy.Add(new Employee { ID = 101, Name = "Sohail", Job = "Manager", Salary = 25000.00 });
            OrgEmploy.Add(new Employee { ID = 102, Name = "Talha", Job = "Saleman", Salary = 15000.00 });
            OrgEmploy.Add(new Employee { ID = 103, Name = "Umair", Job = "Analyst", Salary = 35000.00 });
            OrgEmploy.Add(new Employee { ID = 104, Name = "Haris", Job = "Salesman", Salary = 55000.00 });
            OrgEmploy.Add(new Employee { ID = 105, Name = "Ali", Job = "Clerk", Salary = 26000.00 });
            OrgEmploy.Add(new Employee { ID = 106, Name = "Ahmed", Job = "Salesman", Salary = 29000.00 });

            //but Foreach loop don,t foreach loop works as the class don,t  GetEnumerator() method
            // that all collections implement so foreach loop work for them so first Implement IEnumerable then create Method 
            foreach (Employee obj in OrgEmploy)
            {
                Console.WriteLine(obj.ID + " " + obj.Name + " " + obj.Salary + " " + obj.Job);
            }
            Console.ReadKey();

        }
    }

    //is our class we want it to work like a collection or List class  
    class Organiztion :IEnumerable                                //Organization has many Employees
    {
        List<Employee> employees = new List<Employee>();
        public void Add(Employee Emp) {
            employees.Add(Emp);
        }

        //we can implement it in two ways first we can skip imlementaion and use implementation of List class i.e
        //Calling IEnumerator of List class as we use List to store Employee so it will also work
        //public IEnumerator GetEnumerator()
        //{
        //    return employees.GetEnumerator();
        //}

        //or implement Your own logic 
        public IEnumerator GetEnumerator()
        {
            //firstly this method returns an interface obj but we cannot create interface obj but we can pass 
            //interface child object where its required so we will create our own class first then the IEnumerator
            //class has three members 1.Current(Property) 2.MoveNext(Method) 3.Reset(Method) so we will need to
            //implement them all in our own created classs so lets do this
            return (new OrganizationEnumerator(this));
            //passed here this as the Class we are in is Organization and here req is also it obj so we passed it here
        }

        // but how can we know about no of items in list using the count property that every collection has but as 
        // Organiztion is our created collection so doesnot has Count property so we will create it in here
        public int Count {
            get { return employees.Count; }   //so we called count for the list we created above in this class
        }

        //how can we access that specific index of Organization collection i.e OrgCollection[CurrentIndex]
        //for this we need to create an index in Organization class which will return value/employee on
        //that specicfic index we passs to it so we used 'employees' List of this class and ret value on that index  
        public Employee this[int index] {
            get {
                return employees[index];
            }
        }
    }

    //as OrganizationEnumerator is implementing IEnumerator so it also becomes IEnumerator
    class OrganizationEnumerator : IEnumerator
    {

        //we need to give implementation to Current Property and MoveNext() method if we do this our foreach 
        //loop will work no need to give implemention for Reset() method so first let see how these two work
        //so we have in this case 6 employee objects to access them one by one we will have a pointer that points
        //to the current employee obj this value would be accessed by using 'Current' property and MoveNext() will have logic 
        //to move this pointer to next employee object and it returns true if data exist there and false if  
        // its 'AfterLast' location i.e list ends  but how it will identify the start and end of List so for
        //this we will have two more values  'BeforeFirst' that will be before our first employee or at start
        //and 'AfterLast' that will be after the last employee or at the end of list and in start the pointer 
        //will be pointing to 'BeforeFirst' and as all records are traversed it will be pointing to 'AfterLast'..

        // => 'BeforeFirst'  //at start pointer will be pointing here
        //     emp1
        //     emp2
        //     emp6
        //    'AfterLast'  

        //1st we need our collection class obj and int varaible that will represent the current index and one
        //employee variable which refers to current employee
        Organiztion OrgCollection;
        int CurrentIndex;
        Employee CurrentEmployee;

        //now create its constructor
        public OrganizationEnumerator(Organiztion org) {
            OrgCollection = org;
            CurrentIndex = -1;  //i.e pointer a 'BeforeFirst'
        }
        
        //this property returns the CurrentEmployee pointer is pointing to
        public object Current {
            get
            { //here we want to return the index of OrgCollection the pointer is pointing currently
                return CurrentEmployee;
            }
        }

        //will increment the currentIndex till the list ends and returns true if there is nextIndex in list has
        // a value and false if nextIndex is out list i.e at afterLast 
   
        public bool MoveNext()
        {
            // but how can we know about no of items in list using the count property that every collection has but as 
            // Organiztion is our created collection so doesnot haa Count() property so we will create it in Organiztion class
            if ( ++CurrentIndex >= OrgCollection.Count)
            {   //++CurrentIndex means it will first increment CurrentIndex each time this method is called then do either if or else part
                return false;
            }
            else {  //control enters else so next index is valid now we need to move this index reference to Current field of this Class but how 
                    //can we access that specific index of Organization collection i.e OrgCollection[CurrentIndex]
                    //for this we need to create an index in Organization class which will return value/employee on
                    //that specicfic index we passs to it so we created above
                CurrentEmployee = OrgCollection[CurrentIndex];  //first we pass it to our created variable CurrentEmployee as its
                                                                //employee type and list will also give an employee so   
            }
            return true;
        }

        public void Reset()
        {
                   //no need to implement this method anyway
        }
    }

}
