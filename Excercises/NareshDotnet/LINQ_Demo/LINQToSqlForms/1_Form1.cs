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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //on loading of the form1 the datagridview will be filled with the records of Employee table
        private void Form1_Load(object sender, EventArgs e)
        {
            //will give us connection to database
            CompanyDB_LINQDataContext conectDB = new CompanyDB_LINQDataContext();
            // dataGridView1.DataSource will get ref of datagridview
            //conectDB.Employees       means in CompanyDB_LINQDataContext access the  property Employee named same as your table name return a table Of employee i.e records of Employee in the form of table
            dataGridView1.DataSource = conectDB.Employees;       //so just these two lines will read data and we don,t  need to write select method as we did in     AL-Maidah-Form app
        }
    }
}
