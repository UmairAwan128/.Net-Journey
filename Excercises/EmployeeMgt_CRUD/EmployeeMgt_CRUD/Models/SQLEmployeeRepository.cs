using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.Models
{
    //this class provides the implementation of for repository Pattern or IEmployeeRepository
    // and this class is implementing the interface IEmployeeRepository for SQL database storage i.e
    //stores and retrieves data from database.

    public class SQLEmployeeRepository : IEmployeeRepository 
    {
        private readonly AppDbContext context;

        //we injected the class AppDbContext in this this Controller by passing it as parameter in constructor, before injecting make sure
        //to add/register this class AppDbContext also called service to the configureServices() of the Startup.cs with     
        //   services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
        //this service/line will create object of that class the first time we request it and later in application whenever we request it that 
        //object will be used inpite of creating new so signle AppDbContext obj will be used it application and we don,t need to create or initialize to use members of this class. 

        public SQLEmployeeRepository(AppDbContext context)
        {
         //as here we used constructor to inject the AppDbContext class this is called constructor injection.
         //Injected(means we dont,t created object of AppDbContext with "new" keyword but directly assigned it value i.e "context")

            this.context = context;
        }

        public Employee Add(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if (employee != null) {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;  
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);  //we call attach() on employee we want to update
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified; //tell EFCore its modified
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
