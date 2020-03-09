using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainTeamWebsite.Models;
using DomainTeamWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DomainTeamWebsite.Controllers
{
    public class HomeController : Controller
    {
    private IEmployeeRepository _employeeRepository;
    public HomeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }        
    [Route("")]
    [Route("Home")]
    [Route("Home/Index")]
    public ViewResult Index(){
        var emplist =  _employeeRepository.GetAllEmployees();
        return View(emplist);
    }
    [Route("Home/DetailsAPI/{id?}")]
     public ObjectResult DetailsAPI(int? id){
         Employee empdetails = _employeeRepository.GetEmployee(id??1);
        return new ObjectResult(empdetails);
    }  
    [Route("Home/DetailsView/{id?}")]
    public ViewResult DetailsView(int? id){
        HomeDetailsViewModels _hDViewModel = new HomeDetailsViewModels(){
            employee = _employeeRepository.GetEmployee(id??1),
            PageTitle = "Domain Team"
        };

        return View(_hDViewModel);
    }   
    }
}