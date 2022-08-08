using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMgt_CRUD.Controllers
{
    public class DepartmentsController : Controller
    {
        public string List()
        {
            return "List() Action of Department Controller";
        }

        public string Details()
        {
            return "Details() Action of Department Controller";
        }
    }
}