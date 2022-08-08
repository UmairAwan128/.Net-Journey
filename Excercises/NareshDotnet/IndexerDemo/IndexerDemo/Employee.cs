using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerDemo
{
    //indexers are something like property to access private fields of class
    //but indexer is like an array it make our class an array 
    //and all its fields become its various indexes starting from 0 so or class will be come an array
    //of size=noOfFields in it and will be accessed like an array
    public class Employee
    {

        int Eno;
        string Ename, Job, Dname, Location;
        double Salary;

        public Employee(int Eno, string Ename, string Job, double Salary, string Dname, string Location) {
            this.Eno = Eno;
            this.Ename = Ename;
            this.Job = Job;
            this.Dname = Dname;
            this.Location = Location;
            this.Salary = Salary;
        }

        //as we are expecting three types(int,double,string) so object used
        //or as indexer will return all three types (int,double,string) so object used as it will return any type
        //"this" tells that indexer is defined on the current class so that when object/instance of class ic created
        //it will be now used to access the fields of this class
        //this indexer will be used to get and set fields of this class
        //indexer is access only outside the class not inside as inside we can access fields even if private 
        public object this[int index] {  //index can be of any type like sting even

            get {
                if (index == 0)
                    return Eno;
                else if (index == 8)  //we can also give any value/no to index it don,t depend on order
                    return Ename;
                else if (index == 2)
                    return Job;
                else if (index == 3)
                    return Salary;
                else if (index == 4)
                    return Dname;
                else if (index == 5)
                    return Location;
                else
                    return null;
            }
            set
            {
                if (index == 0)
                    Eno = (int)value;  //value is of type object so can have any value so type cast
                else if (index == 8)  //we can also give any value/no to index it don,t depend on order
                    Ename = (string)value; 
                else if (index == 2)
                    Job = (string)value; 
                else if (index == 3)
                   Salary = (double)value; 
                else if (index == 4)
                    Dname = (string)value;
                else if (index == 5)
                    Location = (string)value;

            }
        }


        public object this[string index]
        {  //index can be of any type like char(like 'a','b') ,double(like 1.1,1.2,1.3)

            get
            {
                if (index.ToUpper() == "ENO")  //toUpper() method benifit is either user enter index in upper or lower 
                    return Eno;                //here it will be converted to Upper case and compared
                else if (index.ToUpper() == "ENAME")  //we can also give any value/no to index it don,t depend on order
                    return Ename;
                else if (index.ToUpper() == "JOB")
                    return Job;
                else if (index.ToUpper() == "SALARY")
                    return Salary;
                else if (index.ToUpper() == "DNAME")
                    return Dname;
                else if (index.ToUpper() == "LOCATION")
                    return Location;
                else
                    return null;
            }
            set
            {
                if (index.ToUpper() == "ENO")
                    Eno = (int)value;  //value is of type object so can have any value so type cast
                else if (index.ToUpper() == "ENAME")  //we can also give any value/no to index it don,t depend on order
                    Ename = (string)value;
                else if (index.ToUpper() == "JOB")
                    Job = (string)value;
                else if (index.ToUpper() == "SALARY")
                    Salary = (double)value;
                else if (index.ToUpper() == "DNAME")
                    Dname = (string)value;
                else if (index.ToUpper() == "LOCATION")
                    Location = (string)value;

            }
        }
    }
}
