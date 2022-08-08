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
    public partial class CRUDOperationsForm : Form
    {
        CompanyDB_LINQDataContext concectDB;
        public CRUDOperationsForm()
        {
            InitializeComponent();
        }

        private void LoadDataIntoGridView() {
            //as we want all data in gridview on runtime
            concectDB = new CompanyDB_LINQDataContext(); //connected to db
            DGViewCRUD.DataSource = concectDB.Employees; //so data loaded to gridview 
            //but bydefault datagridview is editable so lets disable it
            //for this select Properties for gridView and from propertiesPan select 'readonly' value to 'true'
        }

        private void CRUDOperationsForm_Load(object sender, EventArgs e)
        {
            //calling LoadDataIntoGridView() to load data into gridview
            LoadDataIntoGridView();
        }

        //now on the click of Insert Button we want to launch CRUDForm.cs in which we enter
        //data and that will be inserted to Database..
        private void Insert_CRUD_Click(object sender, EventArgs e)
        {
            CRUDForm f = new CRUDForm();
            f.ShowDialog(); // will open the CRUDForm on the center of this form or we can also use show() method 
            //the code after this will be executed after we close the opened form or CRUDForm
            //so we can write here code to update the gridview after the insert into Database
            // so we will update the gridview after the insert we will just call LoadDataIntoGridView() 
            LoadDataIntoGridView();
        }

        //for updating, first a record will be selected from grid view and then its values
        // will be shown in CRUDForm.cs and there we will update any value we want and save
        //butproblem here is how we will set the gridviewRecord values to textBoxes of CRUDForm.cs
        //as those fields are private and accessible only with in that class only we can access them
        //by changing their modifier to Internal(accessible within current project) but how can
        //we change it again it can be done by selecting TextBox properties and from properties
        //pane select Modifiers option and change its value to internal so change all 
        //textboxes and Save and clear button Modifier to Internal...
        private void UpdateButtonCRUD_Click(object sender, EventArgs e)
        {
            //user can also select a single value and press update button an error will occur
            if (DGViewCRUD.SelectedRows.Count > 0)
            { //so to avoid the error this condition means if a complete row or more is selected then do this
                CRUDForm selectedRec = new CRUDForm();  //where SelectedRows is the built in method that has ref of row selected

                selectedRec.EmpNoTxtBox.ReadOnly = true;  //so we cannot change EMPNo
                selectedRec.ClearButton.Enabled = false; // means now while update we don,t have clear button as not needed
                selectedRec.SaveButton.Text = "Update"; // also change the text of save button as it should be update
                //so that's why we make these buttons internal

                selectedRec.EmpNoTxtBox.Text = DGViewCRUD.SelectedRows[0].Cells[0].Value.ToString();
                selectedRec.EmpNameTxtBox.Text = DGViewCRUD.SelectedRows[0].Cells[1].Value.ToString();
                selectedRec.JobTxtBox.Text = DGViewCRUD.SelectedRows[0].Cells[2].Value.ToString();
                selectedRec.SalaryTxtBox.Text = DGViewCRUD.SelectedRows[0].Cells[3].Value.ToString();
                selectedRec.DNameTxtBox.Text = DGViewCRUD.SelectedRows[0].Cells[4].Value.ToString();
                selectedRec.ShowDialog();   //and then open/show the CRUDForm.cs

                LoadDataIntoGridView(); //again load records as when CRUDForm.cs will be closed control will be here and
                                        //here we need to update GridView so
            }
            else {
                MessageBox.Show("Please select a record to update","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            //after this click on save button CRUDForm.cs we want to update the record in the
            //gridview of CRUDOperationsForm.cs we will write its code in save button click method of CRUDForm.cs
            //but there is already code written for insert so how we will differentiate these two different codes
            //as we know that when we insert EmpNo textBox will not have text as EmpNo is Identity but in case of
            //update EmpNo will have a value as will be read from DB and Shown so write the code with these condtion
        }

        private void DeleteButtonCRUD_Click(object sender, EventArgs e)
        {
            //user can also select a single value and press update button an error will occur
            //so to avoid the error this condition means if a complete row or more is selected then only delete 
            if (DGViewCRUD.SelectedRows.Count > 0)
            {

                if (MessageBox.Show("Are you sure you want to Delete the selected record", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    //if user selects the yes button    
                    int EnoRecToDel = Convert.ToInt32(DGViewCRUD.SelectedRows[0].Cells[0].Value);
                    // so here we know each record is represented by instance of class so to get this we first get to
                    // Employee table i.e(connectDB.Employees) then call method with codition where ENo in EnoRecToDel
                    // where E => E.ENo will be changing and comparing with EnoRecToDel value if match
                    //so it will identify the recod and provide its ref in RecToDel
                    Employee RecToDel = concectDB.Employees.SingleOrDefault(E => E.ENo == EnoRecToDel);
                    //to del rec
                    concectDB.Employees.DeleteOnSubmit(RecToDel);
                    concectDB.SubmitChanges();
                    //again reload the Record from DB
                    LoadDataIntoGridView();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to Delete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ClosebuttonCRUD_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
