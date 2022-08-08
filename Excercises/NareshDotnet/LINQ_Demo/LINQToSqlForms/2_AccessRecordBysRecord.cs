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
    public partial class AccessRecordBysRecord : Form
    {
        CompanyDB_LINQDataContext connectDB;  //declared it here so it will be accessible throughout classs
        List<Employee> employes;
        int RecordNo = 0;   //will be used to access specific indexed record from List

        public AccessRecordBysRecord()
        {
            InitializeComponent();
        }

        //onLoad of the Page we want the first record in the form and with next
        //and pre button we want to move b/w all records.. so we want to access records
        // row by row from the table
        private void AccessRecordBysRecord_Load(object sender, EventArgs e)
        {
            //Initailizaing CompanyDB_LINQDataContext obj here
            connectDB = new CompanyDB_LINQDataContext();
            //connectDB.Employees;  // will return a table but we want the first record then on the
            //click of Next we need next record and on the click of Previous we need previous record 
            //this can be only possible with index based access but in table records can,t be accessed in this way..
            //so we use index of type Employee... we declared in start of class and used here
            employes = (connectDB.Employees).ToList();  //as data was in the form of table so converted to list
                                                        //now we have all records in 'employes' and we can access then with index as its list

            ShowDataInTextBoxes();

        }

        private void ShowDataInTextBoxes() {

            //we get Employee record using 'RecordNo' from employee List then its ENo and converted it to string and set that in TextBox
            EmpNoTxtBox.Text = (employes[RecordNo].ENo).ToString();
            EmpNameTxtBox.Text = (employes[RecordNo].Ename);
            JobTxtBox.Text = (employes[RecordNo].Job);
            SalaryTxtBox.Text = (employes[RecordNo].Salary).ToString();
            DNameTxtBox.Text = (employes[RecordNo].Dname);


        }

        private void NxtButton_Click(object sender, EventArgs e)
        {
            if (RecordNo < (employes.Count-1) )  //if it is not last record then increment
            {  // for pre record just -1 the index
                RecordNo += 1;
                ShowDataInTextBoxes();  //display the record
            }
            else
                MessageBox.Show("It is the Last Record");
        }

        private void PreButton_Click(object sender, EventArgs e)
        {
            if (RecordNo > 0)
            {  // for pre record just -1 the index
                RecordNo -= 1;
                ShowDataInTextBoxes();
            }
            else
                MessageBox.Show("It is the First Record");
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
