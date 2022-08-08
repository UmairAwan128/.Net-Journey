using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQToSqlForms
{
    static class Program
    {

        //we have to first convert 
        //  all relational objects into Object oriented types this process is also known as ORM(Object Relational Mapping) 
        //  for this conversion we have a tool known as 'OR Designer' 
        //

        //  in LINQ to SQL we have pure (OOP)object oriented programming so no double quotes strings here 
        //  every table is Class, every column is an property , every record of table is an instance of class and stored procedures are going to be Methods..
        //  SO working with LINQ means pure OOP no relational Database and if we want to use it we have three steps for this
        //  1. Perform ORM by adding 'ORdesigner' to do this "Right click project and move to 'Add' and select 'new item' from dropdown 
        //         and then from Addnewitem Window choose 'LINQ to SQL classes' having extension .dbml(database markup language) 
        //         give it a name prefered name is your database name create it so a window with two panes will open which are 
        //         the two files(CompanyDB_LINQ.dbml.Layout and CompanyDB_LINQ.dbml.Designer) under ('CompanyDB_LINQ.dbml')(i.e LINQ to SQL classes) 
        //         and during this reference of System.Data.Linq.dll file is automatically inserted in References File so step 2 is also done
        //         as we know in CompanyDB_LINQ.dbml.Designer file we don,t write code its auto generated depends on our drag/drop and we should no edit this   
        //         this file has a class CompanyDB_LINQDataContext that inherits from DataContext which helps us connecting with database each time we create 
        //         obj of this class. This class is same as connection class in ADO.net where we pass connectionstring as its constructor parameter for connection
        //         This class also needs connection strin and auto reads connectionstring from config file...
        //         Comming to the two panes in left pane we drag and drop tables of database from server explorer and in right pane drop Stored procedures once you drop 
        //         a dialogbox appears click either Yes or No, I clicked Yes  once you do this automatically connectionstring will be written in the config file so step 3 done
        //         and a new parameterless constructor will be added to CompanyDB_LINQ.dbml.Designer file which will read connectionstring from config file and helps
        //         connecting to database and also a property named same as your table name is also added which return a table Of employee i.e records of Employee in the form of table
        //          and also a new class will be created same as table name i.e Employee and this have properties with same name like its columns and finally the rows/records of the table will 
        //         the instance of the class and will be generated at runtime and the property Employee as we disscussed will load data from table Employee when called..
        //         We Loaded data of Employee table in Form1.cs... 
        //  2.Add a reference for an assembly i.e System.Data.Linq.dll in the 'References' file of this project...    
        //  3.Write Connection string in 'App.Config' file..   


        //  we will Manage the data in 'Employee' Table in 'CompanyDB_LINQProj' Database using LINQ(i.e insert/update/del) operations..
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UsingLINQQueries());    //to run any specific form call here its connstructor
        }
    }
}
