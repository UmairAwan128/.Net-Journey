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
    //On the click of Insert Button in CRUDOperationsForm.cs this form will will be created 
    //in which we enter data and we can save it in Database.. 
    public partial class CRUDForm : Form
    {
        public CRUDForm()
        {
            InitializeComponent();
        }



        //the click on save button CRUDForm.cs will either Insert/update the record in the
        //gridview of CRUDOperationsForm.cs we will write its code in save button i.e both codes here but how
        //how we will differentiate these two different codes as we know that when we insert 
        //EmpNo textBox will not have text as EmpNo is Identity but in case of update EmpNo will have a value as
        // will be read from DB and Shown so write the code with these condtion..
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //connect to database
            CompanyDB_LINQDataContext connectDB = new CompanyDB_LINQDataContext();

            if (EmpNoTxtBox.Text == ""){ //so insert will be done            
                //now we want to insert data into DB i.e a table and here it is Employee table
                //and we can insert into it by creating Employee class Instance and assign values
                //to its attributes that are the columns of Employee table..
                Employee newEmp = new Employee();
                //newEmp.ENo = int.Parse(EmpNoTxtBox.Text);   //don,t need to insert as its Identity
                newEmp.Ename = EmpNameTxtBox.Text;
                newEmp.Job = JobTxtBox.Text;
                newEmp.Salary = decimal.Parse(SalaryTxtBox.Text);
                newEmp.Dname = DNameTxtBox.Text;
                //now add this newEmp record to the table so for this first 
                //get reference of Employee table i.e (connectDB.Employees) then call built in 
                //method InsertOnSubmit() with Employee class obj i.e newEmp
                connectDB.Employees.InsertOnSubmit(newEmp); //but its not inserted yet but in pending state 
                connectDB.SubmitChanges(); //now after this the data will be inserted so two methods will insert data
                MessageBox.Show("Record inserted into the Database");

                //also in the CRUDOperationsForm.cs we need to update the gridview after this insert but we cannot write that
                //code here but in Insert button click method in CRUDOperationsForm.cs...

            }
            else { //so update will be performing

                // so save button is presses so we updated now we need reference to reccord for which need to update so
                // we will get the value from EmpNoTextbox and use it to find reord against it in database and there we will update those values with new 
                // so here we know each record is represented by instance of class so to get this we first get to
                // Employee table i.e(connectDB.Employees) then call method with codition where ENo same as in EmpNoTextbox
                // where E => E.ENo will be changing and comparing with textbox value if match
                //so it will identify the recod and provide its ref in toUpdateRec
                Employee toUpdateRec = connectDB.Employees.SingleOrDefault( E => E.ENo == int.Parse(EmpNoTxtBox.Text));
                //as we get ref now just move new values from textboxes to toUpdateRec(Employee) fields
                toUpdateRec.Ename = EmpNameTxtBox.Text;
                toUpdateRec.Job = JobTxtBox.Text;
                toUpdateRec.Salary = decimal.Parse(SalaryTxtBox.Text);
                toUpdateRec.Dname = DNameTxtBox.Text;
                //then call it as updated value
                connectDB.SubmitChanges();
                MessageBox.Show("Record Updated");
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            //this.Controls will get all the controls(labels,textbox e.t.c) reference 
            //and using foreach loop we will get one by one each element/control
            foreach (Control ctrl in this.Controls) {

                if (ctrl is TextBox) {  //if control is textbox
                    TextBox tb = ctrl as TextBox;  // type cast it to Textbox in tb
                    tb.Clear(); // now clear this textbox
                }
            }
            //after clearing all the textboxes Move cursor to FirstTextBox
            EmpNameTxtBox.Focus();
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CRUDForm_Load(object sender, EventArgs e)
        {

        }
    }
}
