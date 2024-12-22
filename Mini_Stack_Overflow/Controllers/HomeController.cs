using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Stack_Overflow.Areas.Identity.Data;
using Mini_Stack_Overflow.Models;

namespace Mini_Stack_Overflow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Mini_Stack_OverflowContext _context;

        public HomeController(ILogger<HomeController> logger,UserManager<ApplicationUser>userManager, Mini_Stack_OverflowContext context)
        {
            _logger = logger;
            this._userManager = userManager;
            this._context = context;
        }
        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            ViewData["UserName"]= _userManager.GetUserName(this.User);

            var totalAnaswers = await _context.Answers.CountAsync();
            ViewData["Anaswers"] = totalAnaswers;

            var totalCountUpvotes = await _context.Answers.CountAsync(v => v.CountUpvotes);
            ViewData["TotaAnaswerslUp"] = totalCountUpvotes;

            var totalCountDownvotes = await _context.Answers.CountAsync(v => v.CountDownvotes);
            ViewData["TotalAnaswersDown"] = totalCountDownvotes;

            var totalQuestions = await _context.Question.CountAsync();
            ViewData["Questions"] = totalQuestions;
            var totalQuestionsCountUpvotes = await _context.Question.CountAsync(v => v.CountUpvotes);
            ViewData["TotalQuestionsUp"] = totalQuestionsCountUpvotes;
            var totalQuestionsCountDownvotes = await _context.Question.CountAsync(v => v.CountDownvotes);
            ViewData["TotalQuestionsDown"] = totalQuestionsCountDownvotes;
            return View();
        }

        public IActionResult Privacy()
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
