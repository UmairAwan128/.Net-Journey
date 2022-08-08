using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PropertiesDemo.Example
{
    public class Coustomer
    {

        //as property created for this field so we put undersore before its name
        private int _CustID;        //as I wan to provide this field get access only so create property for this 
        private bool _status;
        private string _custName;
        private double _Balance;
        //cities is an enum declared in seperate file in the example folder
        private Cities _City;

        // we want this field to be access get by any one but set by only child classes only
        //for this we can use modifiers with get and set so we use protected here, for set
        //e.g the requirement can be in case of ticket reservation every one can see the availabilty of ticket
        //but only members(child) can online book that ticket...
        private string _State;


        //follwoing is the auto implemented property that is it does not need a field so we don,t declare
        //field for this as the field is will be auto created and we don,t know its name....
        //it disadvantage is that as we don,t know name of field we cannot provide any condition here in set or get
        //so they will be written as it is
        //it can have either get or set  or both
        //in counstructor and other classes its accessed with the name of the property
        public string Country
        {
            get;  //its read only property
        } = "Pakistan"; //default value is pakistan and also its like constant as it will not change
        //1st property is read only 
        //if we want diff for each obj we initialze it in constructor 

        public Coustomer(bool status, string custName, double Balance, Cities city, string state)
        {
            this._status = status;
            //this.CustID = CustID;  
            this._custName = custName;
            this._Balance = Balance;
            this._City = city;
            this._State = state;
            // Country = country;  // calling get part of the prperty of the country we don,t do this as country name Pakistan will never change
        }


        public Cities City
        {
            get { return _City; }

            set
            {
                if (this._status == true)   //so if the coustomer status is false we don,t need to change its City.
                    _City = value;
            }
        }

        //as I wan to provide custID field get access only so here created read/get only property for this 
        //built in e.g of readonly property is length property of Array class i.e you can get that only but cannot set that
        public int CustID
        {
            get { return _CustID; }
        }

        public bool status
        {
            set { this._status = value; }
            get { return _status; }
        }

        //here we declared both get and set part we can do this with public field also but we did this as
        //we need condition here i.e when we try to change custName the status must be true....
        public string custName
        {
            set
            {

                if (this._status == true)   //so if the coustomer status is false its name will not change..
                    this._custName = value;
            }
            get { return _custName; }
        }

        public double Balance
        {
            set
            {
                if (this._status == true)   //so if the coustomer status is false its Blance will not change..
                {
                    if (value >= 500)
                    { //your account must have balance greter then 500
                      //this condition also avoid invalid with drwal i.e with drawing cash more than your account have
                      //as account have 900 and we try to with draw 1000 new balance will be -100 so to avoid this we created the property 
                      //but the as the bank policy is that u can with draw max 400 as balance is 900 because this makes new balance 500 i.e lowest valid balance      
                        this._Balance = value;

                    }
                }
            }
            get { return _Balance; }
        }


        //we can define scope for parts of the property
        // we want State field to be access get by any one(class) i.e public but set by only child classes only i.e protected
        //for this we can use modifiers with get and set, so we use protected here for set 
        //e.g the requirement can be in case of ticket reservation every one can see the availabilty of ticket
        //but only members(child) can online book that ticket...
        public string State
        {
            //as get has no modifier so it will be the modifier of property i.e public here
            get { return _State; }
            protected set { _State = value; }
        }


    }

    public class test_coustomer
    {

        public static void Main()
        {
            //initialzed values using the constructor
            Coustomer c = new Coustomer(false, "umair", 1000, Cities.Lahore, "punjab");
            //c.custId    but not any field in Coustomer can be accessed as they are private  so solution is make them public or create property/method 
            //c.custID = 10;              //  as readonly property so can,t set/ change its value
            Console.WriteLine("Coustomer ID :" + c.CustID);  //we can get its value as its read only property
            Console.WriteLine("Coustomer status :" + c.status);
            Console.WriteLine(" old Coustomer Name :" + c.custName);
            c.custName = "ali";  //this assignment will not work old value will be there as status is false
            Console.WriteLine("modified Coustomer Name :" + c.custName);

            Console.WriteLine(" old Coustomer Balance :" + c.Balance);
            c.Balance -= 100;  //this assignment/withdrawl will not work as status is false so old balance will be shown
            Console.WriteLine("modified Coustomer Balance :" + c.Balance);

            //setting the status : true;
            c.status = true;


            //we should also avoid invalid with drwal i.e with drawing cash more than your account have
            //as account have 900 and we try to with draw 1000 new balance will be -100 so to avoid this we created the property 
            Console.WriteLine(" old Coustomer Balance :" + c.Balance);
            c.Balance -= 1000;  //will not work as withdrawing more then allowed i.e 500 allowed for 1000 to have 500 in balance
            Console.WriteLine("modified Coustomer Balance after withdrawl of 1000 :" + c.Balance);
            c.Balance -= 300;  //will work as valid with drawl
            Console.WriteLine("modified Coustomer Balance withdrawl of 400:" + c.Balance);

            Console.WriteLine("Coustomer City:" + c.City);
            c.City = Cities.Faislabad;
            Console.WriteLine("modified Coustomer City:" + c.City);

            Console.WriteLine("Coustomer State:" + c.State);
            //c.State = "sindh"; //not work as current class is not the child of Coustomer class
            Console.WriteLine("Coustomer Country:" + c.Country);
            Console.ReadKey();
        }

    }

}