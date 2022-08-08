using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace LINQToSqlForms
{
    public partial class StoredProcedureDemo : Form
    {

        //We can define stored procedures here in the visual studio move to ServerExplorer -> DataConnection -> StoredProcedures rightclick and select Add New StoredProcedure
        //in new window write stored procedure and then right click anywahere and select execute to compile/run the stored procedure is now it will be added to DB automatically and when u close it no need to save it 
        //now you can see stored procedure in ServerExplorer -> DataConnection -> StoredProcedures so now open CompanyDB_LINQ.dbml and now in its right pane drag and drop this stored procedure and 
        //Now after this some new code will be auto writen in CompanyDB_LINQ.designer.cs first a method same as the name of the stored procedure i.e Employee_Select which returns IExecutResult<Employee_SelectResult>  (that means returns a table)  
        //where  IExecutResult  is interface inheriting from IEnumerable so its  collection   and it is of type  <Employee_SelectResult>  which  is a class like (EMployee class whihc is against EMployee Table)   
        //Employee_SelectResult  class will have all the attributes that we write in the query as in this case in stored procedure we write all the attributes name so all fieds will be created now both Employee,Employee_SelectResult class look same 
        // but the benift of such claa is that we can have requirement of query which returns only two columns not all so in such cases such kind of classes will be useful
        //so now lets call this procedure and show its out put in GridView i.e in Load method below..

        public StoredProcedureDemo()
        {
            InitializeComponent();
        }

        private void StoredProcedureDemo_Load(object sender, EventArgs e)
        {
            CompanyDB_LINQDataContext connectDB = new CompanyDB_LINQDataContext();
            //connectDB.Employee_Select() whihc calls the Stored Precedure Employee_Select and this method returns ISingleResult<Employee_SelectResult> so created its obj to have result                                                       
           // ISingleResult<Employee_SelectResult> outputProcedureTable = connectDB.Employee_Select();
            //DGViewProc.DataSource = outputProcedureTable;     //outputProcedureTable will have table that we set in the gridview 
                                                               //Stored procedures are bettter way of retrieving data then what we did in Form1.cs as we can also pass here parmeters for particular result
                                                              //but there we called Employee property that return all records all columns of table... 

            //now lets alter this procedure procedure Employee_Select as now our req is  to retrieve data acoording to DName passed to it
            //and also we want that if user don,t want to pass DName it can skip it and in such case all records will be shown so we altered the procedure
            //and now again drag and drop this procedure into right as altered and now it also has parameter so delete the old one...
            //and no you can see in CompanyDB_LINQ.designer.cs the method ISingleResult<Employee_SelectResult> Employee_Select() takes parameter Dname i.e string so commented above line and rewrite here
            ISingleResult<Employee_SelectResult> outputProcedureTable = connectDB.Employee_Select(null);   //if Null passed here then we will get all records
            DGViewProc.DataSource = outputProcedureTable;


        }
    }
}
