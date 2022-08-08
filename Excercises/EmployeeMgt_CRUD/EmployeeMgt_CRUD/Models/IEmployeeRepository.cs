using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.Models
{
    //we used interface to define our Model class related methods because of follwoing reasons 
    // - using interface allow us to use dependency injection 
    // - if we use interface our application becomes easy to mantain and change
    // - using this interface makes unit testing easy
    public interface IEmployeeRepository
    {
        //We defined all the CRUD methods in this interface for accessing Employee Table and wrote word Repository at end and and a class that will implement this interface will provide implementaion for these methods basically we are following the repositoy pattern
        //  What is Repository Pattern
        //Repository Pattern is an abstraction of the Data Access Layer.It hides the details of how exactly the data is saved or retrieved from the underlying
        //data source, dataSource can be Memory,File, Database .The details of how the data is stored and retrieved is in the respective repository class.
        // variouse classes may be implementing this interface depending upon we how and where they want to save data For example, you may have a class implementing this repository that 
        //stores and retrieves data from an in-memory e.g we have MockEmployeeRepository which In-Memory-Repository. You may have another repository that stores and retrieves data from a database like SQL Server e.g . 

        //So repository interface only specfies operation that are supported by repository inspite of details how they will be performed.e.g to GetEmployee by id we need to pass id
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployees();
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int Id);
    }
}
