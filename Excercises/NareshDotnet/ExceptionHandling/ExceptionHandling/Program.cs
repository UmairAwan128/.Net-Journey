using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    //Exception handling is the process of stopping the abnormal runtime termination of a program

    //While Developing an application we come accross two types of error
    //1. CompileTime error (Syntax error gotted on compile time)
    //2. Runtime Error (Error that occur while the code is running)
    //   there may be some reason for runtime error
    //     *  wrong implemenation of logic (logical error) (e.g accessing array beyond its size)
    //     *  wrong input supplied to program  (e.g program asked user to enter int but user entered char or any other)
    //     *  missing required resources   (e.g program is trying to read a file from hard disk that is being deleted)
    //e.g if our code has 100 line and a rutime error occur on line 100 program abnormally stops on 100 line
    // and remaining 900 lines will not execute..
    //Runtime errors are dangerous e.g a money tranfering app money is transfered from one side but its not 
    // recieved on the other side due to runtime error..

    //Exception is not just a runtime error but 
    //whenever a runtime error occurs in our code the either of the exception class abnormally terminates our program    
    //e.g indexOutOfBoundException stops our program when we try to access array out of its range
    //      overflowException stops our program when we try to assign a value greater then the limit e.g we assign int very large value it can,t hold
    //      FormatException stops our program when we try to convert double/int value to string
    //    like thses there are so many so for almost every error on runtime we have a seperate exception class like this 

    //Exception class is parent class of all exception classes
    //Exception class contains logic for abnormal termination(this logic will be same for all child class) and a readonly virtual property "Message" 
    //to display the error message i.e overrideable in child classes so these both will be in all child classes..
    //Exception class has two child classes or types   
    //1. System Exception (Fatal error)(when program trys to do an action that cannot be performed or sytem don,t allow to perform) (e.g divide by 0) (under system exception we have all built in exception like we disscussed abobe )
    //2. Application Exception (non Fatal error)(are such actions that can be performed but we don,t want to perform them) 
    //     (e.g this is our program logic that is for our program req that no must not be div by odd no so we created logic when this division occurs Application exception occurs)

    //clr(common language runtime) manages execution of c# program and converts compiled code to machine code for execution 
    //how exception occurs : 
    //e.g a program that takes two no from user and divide them so if user enter 2nd no zero as we know its not allowed what clr do here is
    //it will select an exception class(DivByZeroExcep) associated with this error then create object of this class
    //and throws that object and that object will perform the abnormal termination and related msg will be shown
    //so for handling exception try/catch block is used try contains statements that may through exception
    //and catch block catch that very object thrown by clr to this class and stops the abnormal termination..

    //advantages of handing an exception :
    // statements that are not related with error will execute.
    // we can display user frienly message about error.
    // we can perform corrective action on rutime if it affects other in the specified catch block.

    //we have 3 block
    //1. try block contains
    //     statements that may cause runtime error
    //     and statements that are not needed to be executed when runtime error occurs 
    //          so when runtime error occurs on any line in try block all statments after this will not execute
    //     all statements in try will execute if there is no exception in code    
    //2. Catch Block
    //     conatins statements that will only execute when runtime error/exception occurs   
    //3. finally Block
    //     conatins statements that will execute either runtime error/exception occurs or not that is on any cost e.g can contain code for closing file


    // normal execution/no error:                    finally block and code after also catch,finaly executes
    // exception occur in try block:                 finally block and code after also catch,finaly executes
    // from try block we "return" or use return statement in try block as we know all methods have one return
    //when its executed control jumps to closing brace of the method skip all the code after return but also
    //in this case finally executes                  finally block executes but not the code after catch,finaly block   

    // so finnally block will execute in any case if we have entered the try block even return is accessed
    //in try block...

    //we can also have a combination of try and finnaly in which finnaly block executed even when exception
    //occur as there is no catch block so exceptions will not be caught


    // All the System Exceptions are handled and thrown by clr but in Application Exception we will create 
    //instance of the exception and throw it e.g in our program logic we want that, divide by odd no 
    // should through an exception so such exception will not be thrown by System/clr but we will throw it
    // we do this as create object of application class and pass msg as parameter and then use throw keyword
    // to throw that exception i.e same as what clr also does so
    //ApplicationException ap = new ApplicationException("Can,t divide by odd no");//named instance
    //throw ap;


    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the First Number : ");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Second Number : ");
                int y = int.Parse(Console.ReadLine());

                if (y % 2 > 0) //if y is an odd number
                {
                    //so here we throw our application exception
                    //ApplicationException ap = new ApplicationException("Can,t divide by odd no");   //named instance
                    //throw ap;
                    //or both are same    //if error msg is not passed then default error msg will be displayed that is in the Exception class Message property we disscussed above
                    //throw new ApplicationException("Can,t divide by odd no"); // runtime instance 
                    throw new DivideByOddNumberException(); // our created exception as now it got name so its better then above 
                                                            //runtime instance is better as we create named instance when we want to call members of the
                                                            //class but as we don,t want to call members of the class so we prfer runtime instance method..
                }

                int z = x / y;
                Console.WriteLine("Result : " + z);
                Console.WriteLine("End of the program");
            }

            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (DivideByOddNumberException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)  //will handle any other excetion
            {
                Console.WriteLine(e.Message);
            }

            finally {
                Console.WriteLine("Finally block executed");
            }

            //code after the try catch
            Console.WriteLine("End of the program");
            Console.ReadKey();


        }
    }
}
