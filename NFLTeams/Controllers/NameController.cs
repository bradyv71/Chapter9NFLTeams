using Microsoft.AspNetCore.Mvc;

using NFLTeams.Models;

namespace NFLTeams.Controllers 
{
    public class NameController : Controller
    {
      
        [HttpGet]
        public IActionResult Index()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamListViewModel
      
            {
                UserName = session.GetUserName()

            };

            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Change(TeamListViewModel model)
        {
            var session = new NFLSession(HttpContext.Session); session.SetUserName(model.UserName);
            return RedirectToAction("Index", "Home", new
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            });
        }
        


    }

}
