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
    public partial class Insert_StoredProcedure : Form
    {
        CompanyDB_LINQDataContext connectDB;
        public Insert_StoredProcedure()
        {
            InitializeComponent();
        }

        //WE have done inserting in 3_CRUDOperationsForm.cs but here we do then inserting
        //by using the stored procedure that is even shorter and easier code and we use it if there is
        //some condition like say we didn,t applied Identity on Eno now as we know its PK and should be unique 
        //and user can enter any value so to restrict in this form it will be readonly and user will 
        //enter all other attributes and this Eno will be entered be entered by the stored procedure so it will be unique
        //the name of procedure is Employee_Insert that needs four input parameter and returns one output parameter i.e ENo
        //first drag and drop the procedure into the rightpane i.e for Procedures to use it again its method and class will
        //be created named method named Employee_Insert()...
        private void Insert_StoredProcedure_Load(object sender, EventArgs e)
        {
            connectDB = new CompanyDB_LINQDataContext();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            int? Eno = null;  //if question mark we can assign null to even integer values and
                              //by default in case of passing parameter to this Mthod if they are int they will also accept null
                              //if we don,t want to pass values  such value has ? with them
                              //as the values of the textbox will be passed so
            Eno=connectDB.Employee_Insert(EmpNameTxtBox.Text, JobTxtBox.Text, decimal.Parse(SalaryTxtBox.Text), DNameTxtBox.Text, ref Eno);
            EmpNoTxtBox.Text = Eno.ToString();  //so this Eno returned will be set to the Eno text box

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            //this.Controls will get all the controls(labels,textbox e.t.c) reference 
            //and using foreach loop we will get one by one each element/control
            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is TextBox)
                {  //if control is textbox
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
    }
}
