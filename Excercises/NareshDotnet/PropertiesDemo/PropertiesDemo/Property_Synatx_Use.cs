using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesDemo
{
    class Property_Synatx_Use
    {
        //property is a member of a class which using which we can expose values associated with the class
        // to the outside environment
        //A class should have private fields/variables why?
        //as if its public any one can get and set the value
        //so solution is use get,set methods or property they are public
        //the benifit is we can only create get method, get part of property to provide only get value access
        //to the field but not the set access 
        //or we can only create set method, set part of property to provide only set value access or changing value
        //to the field but not the get value access i.e don,t tell that value to anybody


        //good industry practice is that both the name of property and field should be same but if 
        //same name and case it gets an error overcome this we place underscore at the start of the
        //field of the class it's another benifit is if a class has 100 fields and we want only 10
        //to be get and set outside the class so i will create property for them and place underscore in the
        //start of their name and all other fields will not have an undersore so if another person
        //see my code he will understand that this class has 100 fields and 10 have property by seeing the undersore 
        private int _Radius;
        public int Radius
        {
            get { return _Radius; }  //this block will execute when some one try to get vlaue of Radius
            set { _Radius = value; } //this block will execute when some one try to set/change vlaue of Radius
        }

        //Advantage of property
        //property restricts access to the fields of class by

        //1 . by creating set only property
        private int _setOnly;
        public int setOnly
        {
            get { return _setOnly; }
        }

        //2. by creating read only property
        private int _readOnly;
        public int readOnly
        {
            set { _readOnly = value; }
        } 

        //3.by providing Conditionl access of the property, if the field is public and we don,t create property we can not have such conditions 
        //e.g set/change the value only if the new value assigned is greater then the old one's.
        //e.g to open an account in a bank there is a restriction that atleast 100 rupees needed to open
        //account so we assigned 100 here so while opening the account in main with a specific amount passed
        //we will check if that amount is greater then this or 100 if yes we will open the account..
        private int _Amount = 100;
        public int Amount
        {
            get { return _Amount; }   
            set//has all the conditions i want to access when someone try to set new value to Amount also getter can have conditions 
            {
                if(value > _Amount)     //so if newly assigned value is greater then the old value this 
                    _Amount = value;   //statement will be executed i.e the new value will be assigned
            }
        }


    }

    class propertyAccing {
        static void Main(string[] args)
        {
            Property_Synatx_Use p = new Property_Synatx_Use();
            //p._Amount = 101; //will not work as field is private
            Console.WriteLine(p.Amount);//calling the get part of the property 
            p.Amount = 10; //there will be no error but the value of Amount will not change as its less 
            Console.WriteLine(p.Amount); //then the previous so account not opened
            p.Amount = 15; //as new value of Amount is greater so the new value will be set to Amount and account will be opend
            Console.WriteLine(p.Amount);//calling the get part of the property 
            Console.ReadKey();
        }
    }
}
