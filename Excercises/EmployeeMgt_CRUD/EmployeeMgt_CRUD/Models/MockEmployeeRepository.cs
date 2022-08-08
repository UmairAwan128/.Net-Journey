using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.Models
{
    //this class provides the implementation of for repository Pattern or IEmployeeRepository
    // and this class is implementing the interface IEmployeeRepository for in memeory data storage i.e
    //stores and retrieves data from an memory or ram in runtime.
    public class MockEmployeeRepository : IEmployeeRepository 
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>() {
                new Employee(){ Id=1, Name="Mary", Department=Dept.HR, Email="mary@gmail.com" },
                new Employee(){ Id=2, Name="John", Department=Dept.IT, Email="john@gmail.com" },
                new Employee(){ Id=3, Name="Sam", Department=Dept.IT, Email="sam@gmail.com" }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id)+1; //find max id value and add 1 in it to get new id value
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int Id)
        {
           Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
           if (employee!=null) {
                _employeeList.Remove(employee);
           }
           return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
           return _employeeList;   
        }

        public Employee GetEmployee(int Id)
        {
            //return employee with specific Id passed
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}
