using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMgt_CRUD.Controllers
{
    public class ErrorController : Controller
    {
        //the route we defined below means this action will be executed for url like "Error/statusCode" so "statusCode" here parameter 
        //e.g "Error/404" so only one action will handle all these various errors like "Error/500" e.t.c
        // this action is called from configure() of Startup.cs as "/Error/{0}" second thing here is a dynamic value i.e StatusCode will be placed here
        //e.g 404 so the value of statusCode/actionName will be stored in parameter name "{statusCode}" and then used by Action HttpStatusCodeHandler(statusCode). 
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            //if in configure() of Startup.cs we are using this middleware app.UseStatusCodePagesWithReExecute("/Error/{0}");
            //we can also get the path/url causing the 404 error here in this action using "OriginalPath" property
            //and also queryString using "OriginalQueryString" property
            //e.g to test use http://localhost:49371/foo/ht?a=2
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode) {
                case 404:
                    ViewBag.ErrorMessage = "Sorry the resource you requested not found";
                    ViewBag.Path = statusCodeResult.OriginalPath;  
                    ViewBag.QS = statusCodeResult.OriginalQueryString;
                break;
                //other errors for statusCodes b/w 400-500
            }
            return View("NotFound");
        }
    }
}