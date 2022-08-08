using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonymousMethodExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //how all this works
        //when double clicked on the buton in form1.cs[design] this method is created in which we write our logic
        //then in backend (in initializeComponent() method in whose code can be checked by ctrl+click on it above in Form1 constructor)
        //this method is assigned to a delegate that is used to call this method so see 'this.button1.Click.... ' in   initializeComponent() 
        private void button1_Click(object sender, EventArgs e)
        {
            //on the click of the button1 in form create another button on the form on runtime/dynamically
            Button b = new Button(); //so create instance of Button, Button is class/control..
            b.Text = "Click me";
            b.Size = new Size(100, 50);
            b.Location = new Point(150, 150);
            this.Controls.Add(b);  //'this' means in this class/form Add a control i.e button on specific location  

            //now on the click of this new button i want to show message so how i will do this
            //i can see the builtin code of the above button as its click is also handled in backend
            //for creating a new button so goto initializeComponent() method by ctrl+click on it above in Form1 constructor
            //in ititalizComponent() its written as     
            //this.button1.Click += new System.EventHandler(this.button1_Click);
            //which means, creating new EventHandler delegate in System namespace and passing it the method(button1_Click) 
            //that we created above and then we are bounding this Eventhandler delegate with the click of the button1..  
            //we can also write it as  button1.Click += new EventHandler(button1_Click);
            //or  EventHandler obj = new EventHandler(button1_Click);
            //    button1.Click += obj;   //so this code we will use so first create method and bind it with new button click

            //so we have three ways of doing this first two by creating method third by creating annonymous method

            //1.     b.Click += new EventHandler(b_Click);
            //2.     or EventHandler obj = new EventHandler(b_Click);  //b.Click += obj;
         
            //3.     or also we can create annonymous method as event handler is a built in delegate so we did,nt created delegate and just
            //          need to pass what parameter it needs with delegate keyword and write logic. 
            b.Click += delegate (object sender1, EventArgs e1)
                                {
                                    MessageBox.Show("Hello world");
                                };

        }
        //method will be same as above
        private void b_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world");
        }

    }
}
