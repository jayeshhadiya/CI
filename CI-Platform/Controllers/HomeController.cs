using CI_Platform.entites.Models;
using CI_Platform.Models;
using CI_Platform.repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CI_Platform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<User> LstUsers = _userRepository.GetUsersList();
            return View(LstUsers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }
        [HttpPost]

 /*       public IActionResult login(User user)
        {   
            _userRepository.InsertUser(user);
            return RedirectToAction("HomeLandingPage","Home");
        }*/

        public IActionResult Login(loginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUsersList().FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    return RedirectToAction("HomeLandingPage", "Home");
                }
                else
                {
                }
            }
            return View(model);
        }
        

        public IActionResult Reset()
        {
            return View();
        }

        /*public IActionResult Register()
        {
            return View();
        }*/
        public IActionResult Register(RegisterModelcs model)
        {
            if (ModelState.IsValid)
            {
                var olduser = _userRepository.GetUsersList().FirstOrDefault(u => u.Email == model.Email);
                if (olduser != null)
                {
                    ModelState.AddModelError("Email", "This email is already in use");
                    return View(model);
                }
                if (model.FirstName == null)
                {
                    ModelState.AddModelError("First_name", "The First Name field is required.");
                }

                if (model.Password != model.ConformPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "The password does not match");
                    return View(model);
                }

                if (ModelState.IsValid)
                {
                    var newuser = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password,
                        PhoneNumber= model.PhoneNumber
                    };
                    _userRepository.Add(newuser);
                }
                return RedirectToAction("login", "Home");
            }
            return View(model);
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public IActionResult HomeLandingPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}