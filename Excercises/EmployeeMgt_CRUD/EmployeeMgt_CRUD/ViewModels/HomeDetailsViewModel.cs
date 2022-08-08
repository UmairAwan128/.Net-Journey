using EmployeeMgt_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.ViewModels
{

    //as in detailsView.cshtml we need specific Employee data and additionally we want to send the title of the page
    //also one way is use ViewBag to send pageTitle and model to send the Employee data. but we should avoid using
    //ViewBag/ViewData as they are looselyTyped so solution is create a ViewModel(which is a model specific for a specific view) we create
    //them in ViewModels folder and will have all the properties that a specific view wants in our case the DetailsView
    //wants two things Employee object and PageTitle string so we created both in "HomeDetailsViewModels" and used it here.
    // so we create a viewModel when model does not have all the properties that View needs. 
    //ViewModels are also called dataTransferObjects(DTO)
    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }
    }
}
