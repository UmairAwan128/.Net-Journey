using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQToSqlForms
{
    public partial class UsingLINQQueries : Form
    {
        //here in this class we  will use linq queries to retrieve data from Database which
        //makes our code even shoreter so first
        //what is the syntax for LINQ it like SQL.. i.e
        //  From <alias> in <Collection|Array|Table> [<Clauses>] select <alias>
        // i.e
        //  From <alias>(i.e like Table it can be any word/name i.e its obj of class againt table and using it we can access all columns/fields of table/class)
        //  in <Collection|Array|Table ref>(i.e KeyWord or ref) 
        //  [<Clauses>](i.e Groupby,where,orderBy any Condition)
        //  select <alias>(i.e like columns list) 
        //(since Alias is any name of Collection as Array/collection don,t have column name but table has so we access its columns using this alias like an object of class as Table in c# is class and its columns are attribute)

        
        CompanyDB_LINQDataContext connectDB;
        bool flag = false;  //means form is not loaded
 
        public UsingLINQQueries()
        {
            InitializeComponent();
        }

        private void UsingLINQQueries_Load(object sender, EventArgs e)
        {
            connectDB = new CompanyDB_LINQDataContext();
            ////so for e.g first lets write query for showing all records of table Employes 
            ////i.e like     select * from Employee          we write as   match it with the syntax above
            //    var allRec = from E in connectDB.Employees select E;   // where connectDB.Employees will aaccess the Employee table and E is like obj of Employee Class i.e agains Employeetable

            ////this like select * from Employee where job="Manager"
            //    var salesDep = from E in connectDB.Employees where E.Job == "Manager" select E;  //E.Job  means as we  know E is obj of Employee class/table so we accessed it column Job here

            ////to get only som specific columns(i.e ENo, Ename,Dname) of table we do this as
            //    var CSDepSpecific = from E in connectDB.Employees where E.Dname == "CS" select new { E.ENo, E.Ename, E.Dname };

            //but now now  here we will use new Tables like EMP and Dep so we use two table write query for them first in GridView
            //we will show all records of Emp table
            var AllEmps = from E in connectDB.Emps select E;
            dataGridView1.DataSource = AllEmps;
            //or in single line         dataGridView1.DataSource = from E in connectDB.Emps select E;

            //now from Emp column Job we will select all of them and display them in the combobox so
            var Jobs = from E in connectDB.Emps select new { E.Job };
            comboBox1.DataSource = Jobs.Distinct();   //Distinct() used as Jobs will be repeating so to avoid repetation
            comboBox1.DisplayMember = "Job";   //but now each job is written as 'Job={Clerk}'  in combo box so to write it as 'Clerk' only we used this

            //now on the select of a job from Combobox1 i want to display only that job records so double click ComboxBox1 and a method will be created i.e  comboBox1_SelectedIndexChanged
            //this method will be automaticlly called when we change an index so just one line code will write..
            comboBox1.SelectedIndex = -1;

            flag = true; //so now comboBox1_SelectedIndexChanged() can be called
        }

        //this method will be automaticlly called when we change or on the select of a job from Combobox1 so just one line code will write..
        //but there is a problem when we open form automatically First item of combobox is selected and its against records are shown
        //but we want all the records to be shown till we select any option from combobox so we write a line above   comboBox1.SelectedIndex = -1 
        //which will remove the auto selection but now we are not getting any rcords as       comboBox1_SelectedIndexChanged()   is auto called
        //each time we add a new values or call any of comboBox property or method so that's why no record is showing as we are doing all this in Load method   
        //so on the Load of this Form comboBox1_SelectedIndexChanged() will be called manny times so it changes data in gridview but we don,t want it to call on the load of the
        // form but only on the change of combo box value after the form is loaded so created a flag i.e bool for this if its true form means form is loaded if false form is not loaded
        //so when we declare it we will make it false so method will not be callable but we will make it true when form will be loaded so will be callable
        //we true the flag at then end of load method
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(flag == true)
            dataGridView1.DataSource = from E in connectDB.Emps where E.Job == comboBox1.Text orderby E.Ename descending select E;

            //additionally i want to option like that if in combbox i type letter it will show against it i.e search in combobox as there will
            // be a case when there will be soo maany Job so selecting will be difficult so for this move to properties for combo box
            // and from Events double click KeyPressEvent a method will be created in this class comboBox1_KeyPress()
        }

        //additionally i want to option like that if in combbox i type letter it will show records against it in gridview
        //as there may be a case when there will be soo maany Job so selecting will be difficult so for this move to properties for combo box
        // and from Events double click KeyPressEvent a method will be created here so fot this in query we use 'like' for such cases..
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)  //this event will be called on each keypress in combobox 
        {
            //Contains() method Works like 'Like' in SQL its same as where Job Like %comboBox1.Text%                                                                     
            dataGridView1.DataSource = from E in connectDB.Emps where E.Job.Contains(comboBox1.Text) select E;
        }

        private void OrderBySalarybutton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from E in connectDB.Emps orderby E.Sal select E; //by default orderby will be ascending   
        }

        private void OrderbyEnameButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = from E in connectDB.Emps orderby E.Ename descending select E; 
        }

        private void GetSelColbutton_Click(object sender, EventArgs e)
        {
            // The columns name of salaries values is Sal but its not understandable 
            //so Salary =E.Sal means ingridview the Sal column name will be Salary works like 'AS' is SQL i.e   Select Sal As Salary  
            dataGridView1.DataSource = from E in connectDB.Emps select new { E.Empno,E.Ename, Salary=E.Sal ,E.Job,E.Deptno};

        }

        private void CountEmpButton_Click(object sender, EventArgs e)
        {
            //our Query required in SQL its      Select Deptno,Count(*) As totalEmploys from Emp Group By Deptno
            dataGridView1.DataSource = from E in connectDB.Emps group E by E.Deptno into G select new { DeptNo=G.Key, TotalEmp = G.Count() };
        
            //first thing for SQL query in case of any groupby query we have two things in it in case of C#
            //1. Group Key        in query its Deptno      i.e group some records on the basis of this
            //2. Group Result     in query its Count(*)    i.e result againt each particular group

            //now for the LINQ Query 
            // first 'group E by E.Deptno into G'   means   Group the Employee table by Deptno 'into G' means move these Group ref into 'G' that can be any name 
            //and for this 'new { DeptNo=G.Key, TotalEmp = G.Count() }'  as we know in case of group by resultant column we can specify only those columns
            //that are connected to Groupby so to avoid any error first we created a ref to the group named 'G' and know we can access the columns mentioned in GroupBy
            //using G so G.Key here refers to Deptno  and we call here count() method using G also and show its column name as TotalEmp
        }


        private void JobsHavingEmpGre_Click(object sender, EventArgs e)
        {
            //If filteration is to be done before grouping use Where Clause
            //If filteration is to be done after grouping  use Having Clause 
            //query req:  Select Job,Count(*) As totalEmploys from Emp Group By Job having Count(*)<5    
            //in case of our query we need Having clause but LINQ don,t have Having Clause so what LINQ did for us is Where Clause
            //if we use Where before Groupby it work like Where clause  but if we use it after Groupby it will work like Having clause so.
            dataGridView1.DataSource = from E in connectDB.Emps group E by E.Job into G where G.Count()<5 select new { Job = G.Key, TotalEmp = G.Count() };
            //where G.Count()<2   where is working like having clause
        }

        private void CountClerksinEachDeptbutton_Click(object sender, EventArgs e)
        {
            //required query: Select DeptNo,count(*) As TotalClerks from Emp where Job='Clerk' Group by Deptno Having count(*)>1 Order By DeptNo desc
            //Select DeptNo,count(*) from Emp where Job='Clerk' will give all clerk and then group them by DeptNo
            dataGridView1.DataSource = from E in connectDB.Emps where E.Job == "Clerk" group E by E.Deptno into G where G.Count()>1 orderby G.Key descending select new { DeptNo = G.Key, TotalClerks = G.Count() };
            //so all four clauses are used in the Order/Seq of WGHO that must be followed
            //first Where Clause execute sends data to Groupby then Groupby Clause will Group the data and sends this data to Having 
            //will apply some filter on it remove unwanted data finnally Orderby will arrange/order and display the data
        }

        private void MaxSalaryEachDeptbutton_Click(object sender, EventArgs e)
        {          // Max method req parameter for column to find max from   E=>E.Sal
            dataGridView1.DataSource = from E in connectDB.Emps group E by E.Deptno into G select new { DeptNo = G.Key, MaxSalary = G.Max(E=>E.Sal) };
        }
    }
}
