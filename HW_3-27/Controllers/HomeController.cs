using HW_3_27.Models;
using Microsoft.AspNetCore.Mvc;
using PeopelListData;
using System.Diagnostics;

namespace HW_3_27.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People; Integrated Security=true";

        public IActionResult Index()
        {
            PeopleListDB db = new PeopleListDB(_connectionString);
            PeopleViewModel viewModel = new PeopleViewModel
            {
                people = db.SelectAll(),
            };
            
           
            return View(viewModel);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<People> people)
        {
            PeopleListDB db = new PeopleListDB(_connectionString);
            db.AddMany(people);
            return Redirect("/Home/Index");
        }


    }
}