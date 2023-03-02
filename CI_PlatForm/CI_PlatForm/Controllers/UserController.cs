
using CI_Platform.Entities.Data;
using CI_Platform.Entities.Models;
using CI_Platform.Repository.Interface;
using CI_PlatForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace CI_PlatForm.Controllers
{
    public class UserController : Controller
    {
        private readonly CiplatformContext _db;

       
        public readonly IUserRepository _AccountRepository;
        public UserController(IUserRepository accountRepository, CiplatformContext db)
        {
            _AccountRepository = accountRepository;
            _db = db;
        }

        public IActionResult UserList()
        {
            var listOfUsers = _AccountRepository.GetUserData();
            return View(listOfUsers);
        }
        public IActionResult Index()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User objLogin)
        {
            if (_db.Users.Any(u => u.Email == objLogin.Email && u.Password == objLogin.Password))
          
            {
                return RedirectToAction("PlatformLanding", "Home");
            }
            
            return View();
        }
        
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(User obj)
        {
            _AccountRepository.Registration(obj);
             return (RedirectToAction("Index", "User"));
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult Reset()
        {
            return View();
        }
    }
}
