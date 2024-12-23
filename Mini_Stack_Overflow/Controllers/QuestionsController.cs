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
    public class QuestionsController : Controller
    {
        private readonly Mini_Stack_OverflowContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionsController(Mini_Stack_OverflowContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var totalQuestions = await _context.Question.CountAsync();
            ViewData["Questions"] = totalQuestions;
            var totalCountUpvotes = await _context.Question.CountAsync(v => v.CountUpvotes);
            ViewData["TotalQuestionsUp"] = totalCountUpvotes;
            var totalCountDownvotes = await _context.Question.CountAsync(v => v.CountDownvotes);
            ViewData["TotalQuestionsDown"] = totalCountDownvotes;
            return View(await _context.Questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Question question , Vote vote)
        {
            // Retrieve the ID of the currently logged-in user
            var useremail = _userManager.GetUserName(User);
            var useid = _userManager.GetUserId(User);

            if (Guid.TryParse(useid, out Guid user_id))
            {
                question.Email = useremail;
                question.UserId = user_id;
                if (question.CountUpvotes)
                {
                    vote.IsUpvote = true;
                }
                else
                {
                    if (question.CountDownvotes)
                    {
                        vote.IsUpvote = true;
                    }
                    else
                    {
                        vote.IsUpvote = false;
                    }
                }
                _context.Add(vote);
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Prepare SelectList for dropdown menu in case of validation failure
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "Description");
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,Title,Description,Tags,Email,countUpvotes,countDownvotes,CreateAt")] Question question)
        {
            if (id != question.QuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
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
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .FirstOrDefaultAsync(m => m.QuestionId == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }
}
