using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaterDeligate
{
    class Student
    {
        public event EventHandler<InValidInputEvent> inValidEvent;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                Validate<string> myName = ValidateStudent.ValidateNameMethod;
                if (myName(value)) { 
                    name = value;
                }
                else
                {
                    inValidEvent(this,new InValidInputEvent());
                }
    
            }
        }


        private int rollno;

        public int RollNo
        {
            get { return rollno; }
            set
            {                  
                Validate<int> myRoll = ValidateStudent.ValidateRollNoMethod;
                if (myRoll(value)) { 
                    rollno = value;
                }
                else {
                    inValidEvent(this, new InValidInputEvent());
                }
            }
        }

    }
}     