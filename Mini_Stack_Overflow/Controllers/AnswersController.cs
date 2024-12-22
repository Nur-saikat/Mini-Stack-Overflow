using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mini_Stack_Overflow.Areas.Identity.Data;
using Mini_Stack_Overflow.Models;

namespace Mini_Stack_Overflow.Controllers
{
    [Authorize]
    public class AnswersController : Controller
    {
        private readonly Mini_Stack_OverflowContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswersController(Mini_Stack_OverflowContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            var totalAnaswers = await _context.Answers.CountAsync();
            ViewData["Anaswers"] = totalAnaswers;
            var totalCountUpvotes = await _context.Answers.CountAsync(v => v.CountUpvotes);
            ViewData["TotaAnaswerslUp"] = totalCountUpvotes;
            var totalCountDownvotes = await _context.Answers.CountAsync(v => v.CountDownvotes);
            ViewData["TotalAnaswersDown"] = totalCountDownvotes;

            var mini_Stack_OverflowContext = _context.Answers.Include(a => a.Question);
            return View(await mini_Stack_OverflowContext.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.AnswerId == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Answers/Create
        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "Tags");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswerId,Text,UserId,Email,CountUpvotes,CountDownvotes,CreateAt,QuestionId")] Answer answer)
        {
            // Retrieve the ID of the currently logged-in user
            var useremail = _userManager.GetUserName(User);
            var useid = _userManager.GetUserId(User);

            //bool checkUserVote = _userManager.Users.Any(c => c.Id == answer.UserId);
            bool checkUserVote = _userManager.Users.Any(c => c.Id == answer.UserId.ToString());
            if (checkUserVote)
            {
                
            }
            else { 
                
            }

                if (Guid.TryParse(useid, out Guid user_id))
                {
                    answer.Email = useremail;
                    answer.UserId = user_id;
                    _context.Add(answer);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                 }


                ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "Title", answer.QuestionId);
                return View(answer);
            
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", answer.QuestionId);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnswerId,Text,UserId,Email,CountUpvotes,CountDownvotes,CreateAt,QuestionId")] Answer answer)
        {
            if (id != answer.AnswerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.AnswerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "QuestionId", answer.QuestionId);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answers
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.AnswerId == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerExists(int id)
        {
            return _context.Answers.Any(e => e.AnswerId == id);
        }
    }
}
