using Microsoft.AspNetCore.Mvc;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.UI.ApiConsumeServices.Interface;

namespace SongRecommendation.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiConsumeService _userApiService;
        public UserController(IUserApiConsumeService userApiService)
		{
			_userApiService = userApiService;
		}
		public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userApiService.GetAllUsers();
            if (users == null)
            {
				return NotFound("No users found");
			}
            return View(users);
        }
        public async Task<IActionResult> AddUser()
        {
            return View();
		}
        [HttpPost]
		public async Task<IActionResult> AddUser(GetUserDto userCreate)
        {
            if (ModelState.IsValid)
            {
                try
                {
					bool success = await _userApiService.AddUser(userCreate);
                    if (success)
                    {
                        TempData["Success"] = "User added successfully";
						return RedirectToAction(nameof(GetAllUsers));
					}
					else
                    {
						ModelState.AddModelError(string.Empty, "Failed to Add User, Please try again");
					}
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, "An error occured" + ex.Message);
				}

			}
            return View(userCreate);
        }
    }
}
