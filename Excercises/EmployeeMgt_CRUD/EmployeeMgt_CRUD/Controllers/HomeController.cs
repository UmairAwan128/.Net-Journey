using EmployeeMgt_CRUD.Models;
using EmployeeMgt_CRUD.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.Controllers
{
    //to avoid repeatation or writting same word for each of the action use it here and remove duplication from actions
    //    [Route("Home")]
    //We can also use Tokken so that we dont, need to write the name of action or controller it will be assigned on runTime so
    //benifit is if we change the name of the controller or action we don,t need to change the name in route as well.
    // [Route("[controller]")]
    // [Route("[controller]/[action]")]  //or also move the [action] here so remove redundancy in all the actions
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        //we want to access wwwroot folder i.e to save file in the Images folder there and so to access wwwroot folder or get
        //its physical path we need to ues IHostingEnvironment service so we injected it to the constructor and used it in the create() post method
        private readonly IHostingEnvironment _hostingEnvironment;

        //we injected the interface IEmployeeRepository in this this Controller by passing it as parameter in constructor, before injecting make sure
        //to add/register this interface also called service to the configureServices() of the Startup.cs with class which implements this interface as secondParameter e.g     
        //                    services.AddSingleton<IEmployeeRepository,MockEmployeeRepository>();
        //this service/line will create object of second parameter i.e here MockEmployeeRepository the first time we request it and later in application whenever we request it that 
        //object will be used inpite of creating new as AddSingleton() is used. so signle MockEmployeeRepository obj will be used in application 
        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironemt)
        {//as here we used constructor to inject the IEmployeeRepository this is called constructor injection.
         //Injected(means we dont,t created object of IEmployeeRepository with "new" keyword but directly assigned it value i.e "employeeRepository")

            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironemt;
        }

        //In MVC we have two kinds of routing convention and attribute roting, In convention routing we define route and
        //pass it as parameter in app.UseMvc() or using app.UseMvcWithDefaultRoute() method we do this in startUp.cs file
        //In this file or controller routing we did below is called attribute routing we use attribute routing in rest API's. 
        //and for attribute routing we use app.UseMvc() in startUp.cs so we don,t pass or route/parameter to it. but in such
        //case we define route for each of the action in its respective Controller file using the "Route()" attribute we 
        //use it at start/before the action or controllerClass so here in Controller file we used Route attribte as. 
        //in a single appilcatio we can use both attribute and conventional routing at the same time.
        
            
        //if the incoming request or url matches any of the below access the "Index" action.  
        //[Route("")]   //use this action as default action to be called when no route specified i.e run this action for url localhost:123/
        //[Route("Home")]   //if url is localhost:123/Home    run this action
        //[Route("Home/Index")]  //if url is localhost:123/Home/Index    run this action
        //[Route("myCont/myAct")] //attribute routing is independent of name of controller and action i.e we can use any url/path
        //what we want to access a specific action e.g here route we defined for this action is not matching with name of controller or action

        ////as we have wrote Rout("Home") at top of class so no need to write here write here only action name so 
        //[Route("")]   //if url is localhost:123/Home    run this action as we defined Rout("Home") on top of class but didn,t wrote action name here so  
        //[Route("Index")]  //if url is localhost:123/Home/Index    run this action
        //[Route("~/")]   //use this action as default action to be called when no route specified i.e run this action for url localhost:123/
        //                //as we used here "~/" so the controller name we wrote at top of class i.e Route("Home") will be ignored and its like we defined new Route here from start e.g is nex route   
        //[Route("~/myCont/myAct")] //attribute routing is independent of name of controller and action i.e we can use any url/path

        ////We can also use Tokken so that we dont, need to write the name of action or controller it will be assigned on runTime so
        ////benifit is if we change the name of the controller or action we don,t need to change the name in route as well.
        //[Route("")]   //if url is localhost:123/Home    run this action as we defined Rout("Home") on top of class but didn,t wrote action name here so  
        //[Route("[action]")]  //if url is localhost:123/Home/Index    run this action
        //[Route("~/")]   //use this action as default action to be called when no route specified i.e run this action for url localhost:123/
        //                //as we used here "~/" so the controller name we wrote at top of class i.e Route("Home") will be ignored and its like we defined new Route here from start e.g is nex route
        //[Route("~/myCont/myAct")] //attribute routing is independent of name of controller and action i.e we can use any url/path
        
        //or we can also omit [action] and move it to the top of class/controller so    
        // [Route("~/Home")]   //if url is localhost:123/Home      so we defined specific route for this from start ignoring the route we defined at the start of the controller class
        // [Route("~/")]   

        //public string Index()
        public ViewResult Index()
        {
            //return "Hello from index() of HomeCntroller";
            //return _employeeRepository.GetEmployee(1).Name;
            var model = _employeeRepository.GetAllEmployees();
            return View(model);

        }

        //[Route("DetailsJson")]
        //[Route("[action]")]
        public JsonResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return Json(model); //typeCast mode to Json format and return 
        }


        //[Route("DetailsContentNego")]
        //[Route("[action]")]
        //Above Details() method is always returning data in Json format but what if user wants the data in any other
        //format e.g xml so we use here ContentNegotation that means along with URL in request header user also pass the
        //format of response/data it requires as key value pair like "Accept : application/xml" and .NET see this and
        //return data in that format for that We should use here return type ObjectResult.
        //e.g if user want response data in xml format we additionally need to add its required service in configureService() in the startUp.cs
        //we can add this by chaining it with AddMvc() method i.e after it followed by dot add that service as  services.AddMvc().AddXmlSerializerFormatters();
        //so now this method can return data in xml format.
        public ObjectResult Details_ContentNego()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return new ObjectResult(model) ; //ObjectResult means convert data to format which user wants user sends the format it requires in request header  
        }

        //returning view
        //public ViewResult DetailsView()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    //return View(model); to return data to view having name same as the action name i.e in Home folder which is same as controller name.  
        //    //return View("Test", model); //to return View whose name is Test.cshtml from this Action inpite of DetailsView.cshtml and pass model.
        //    //return View("MyViews/Test.cshtml",model); //to return View whose name is Test.cshtml and is not in the view folder i.e in another folder
        //                                              //write its name MVC finds it in root directory additionally we should specify here extension of file i.e cshtml .
        //    //return View("../Test/update", model); //to access update.cshtml in Test folder we used "../" means go one level up then move to Test folder then select update.cshtml
        //    return View("../../MyViews/Test",model); //we can also follow same pattern to access Test.cshtml from MyViews folder so we go two level up then move to file.
        //}

        // [Route("Home/Details/{id?}")]  //optional id parameter
        // [Route("Details/{id?}")]  //optional id parameter
        // [Route("[action]/{id?}")]
        
        // [Route("{id?}")]   //we can also omit [action] and move it to the top of class/controller so    


        //passing data to view and returning view
        public ViewResult DetailsView(int? id) //Nullable id parameter so its now optional
        //public ViewResult DetailsView(int? id,string name) // id is route parameter because we defined it in default route but 
        { //to recieve name here also either pass it as query string parameter or define a new route with both id and name as route parameter.
            Employee employee = _employeeRepository.GetEmployee(id?? 1); //if "id" has value use that otherwise use 1 if error use "id.Value" 
                                                                     
            ////using ViewData to pass data to view.
            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "Employee Details";

            //using ViewBag to pass data to view.
            //ViewBag.Employee = model;

            //ViewBag.PageTitle = "Employee Details";
            //as in detailsView.cshtml we need specific Employee data and additionally we want to send the title of the page
            //also one way is use ViewBag to send pageTitle and model to send the Employee data. but we should avoid using
            //ViewBag/ViewData  as they are looselyTyped so solution is create a ViewModel(which is a model specific for a specific view) we create
            //them in ViewModels folder and will have all the properties that a specific view wants in our case the DetailsView
            //wants two things Employee object and PageTitle string so we created both in "HomeDetailsViewModels" and used it here.

            if (employee == null) { //if employee not found redirect to notFound page
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel() {
                Employee = employee,
                PageTitle = "Employee Details"
            }; 

            return View(homeDetailsViewModel);
        }

        //this method is telling about modelBinding i.e paramters passed to the action of controller  
        public string DetailsString(int? id, string name) // id is route parameter because we defined it in default route but 
        { //to recieve name here also either pass it as query string parameter or define a new route with both id and name as route parameter.
          //if we additionally pass the "id" as query string parameter also the value of route parameter will be shown and that will be ignored
          //and if the id parameter is passed in post req also along with it is also in route parameter and queryString parameter
          //so the value of id paramter i.e passed in post request will be shown.so the order is
          //1. Form values(post request)
          //2. Route values
          //3. Query String
            return id.Value.ToString() + " " + name; 
        }

        [HttpGet]
        public ViewResult create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };

            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult create(EmployeeCreateViewModel employee)
        {
            //if modelState is vlid i.e rules we applied in EmployeeCreateViewModel.cs like Name and Email are required
            //so if values are not passed validatation fails is IsValid() return false.
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (employee.Photos != null && employee.Photos.Count > 0) { //if user has uploaded 1 or more photo then

                    foreach (IFormFile photo in employee.Photos) {
                        //we want to save each to Images folder i.e in wwwroot folder and to access wwwroot folder or get
                        //its physical path we need to ues IHostingEnvironment service so we injected it to the constructor.
                        string uploadsFolder =  Path.Combine(_hostingEnvironment.WebRootPath,"images"); //we get images folder path
                        //"WebRootPath" provides absolute physical path for the wwwroot folder as we want images folder so combined with "images" which is name of folder inside the wwwroot
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder,uniqueFileName); //so we get complete file path

                        //we moved the FileStream code to using block so that its object gets disposed right after it saves the file
                        //the problem here was after if right after creating new Employee we edit it and upload new Image and save as 
                        //we know the Edit() deletes the old image and save the new image as it try to delete oldImage we get error
                        //because the file Edit() is trying to delete is in use by this "fileStream" object so we used here using block
                        //and disposed the fileStream right after we create file so other can access file. 
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            photo.CopyTo(fileStream); //copy/move the file to the "FilePath" provided and mode is create so new file created
                        }
                        //so file uploaded is moved to the images folder
                    }

                }
                Employee newEmployee = new Employee() {
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("detailsView", new { id = newEmployee.Id });
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                //as user is allowed to upload only one photo so here we don,t used foreach as in the create()
                if (model.Photo != null)
                {
                    //if user has uploaded a new photo and also has an existing photo so we should delete its existing/old photo we are getting its name using "ExistingPhotoPath" property
                    if (model.ExistingPhotoPath!=null) {
                        //getting the complete path for the users existing photo
                        string existingFilePath = Path.Combine(_hostingEnvironment.WebRootPath,"images",model.ExistingPhotoPath);
                        System.IO.File.Delete(existingFilePath); //now delete the file
                    }


                    string uniqueFileName = null;
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images"); //we get images folder path
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName); //so we get complete file path

                    //we moved the FileStream code to using block so that its object gets disposed right after it saves the file
                    //so other can access file for details see create() post 
                    using (var fileStream = new FileStream(filePath, FileMode.Create)) { 
                       model.Photo.CopyTo(fileStream); //copy/move the file to the "FilePath" provided and mode is create so new file created
                    }
                    employee.PhotoPath = uniqueFileName; //so only update image if user has provided a new

                }

                _employeeRepository.Update(employee);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
 