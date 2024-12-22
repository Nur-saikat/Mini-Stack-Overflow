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
    public class QuestionsController1 : Controller
    {
        private readonly Mini_Stack_OverflowContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionsController1(Mini_Stack_OverflowContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.ToListAsync());
        }

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

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswerId,Text,UserId1,QuestionId")] Answer answer)
        {
            // Retrieve the user_id from the current user
            var user_id_string = _userManager.GetUserId(this.User);
            var user_email_string = _userManager.GetUserName(this.User);

            //bool isDuplicate = _context.Answers.Any(p => p.UserId == );

            // Attempt to parse the user_id to a Guid
            if (Guid.TryParse(user_id_string, out Guid user_id))
            {
                // If the ModelState is valid, assign the user_id and save the answer
                if (ModelState.IsValid)
                {
                    answer.UserId = user_id;  // Assign parsed Guid to UserId1
                    answer.Email = user_email_string;  // Assign parsed Guid to UserId1

                    // Optionally, you could also assign the User navigation property:
                    // answer.User = await _userManager.FindByIdAsync(user_id_string);

                    _context.Add(answer);  // Add the new answer to the context
                    await _context.SaveChangesAsync();  // Save changes asynchronously

                    return RedirectToAction(nameof(Index));  // Redirect to the Index action
                }
            }
            else
            {
                // If the user_id couldn't be parsed, show an error
                ViewData["Error"] = "Invalid user ID.";
            }

            // Pass the list of questions for the dropdown (SelectList)
            ViewData["QuestionId"] = new SelectList(_context.Questions, "QuestionId", "Description");

            // Return the view with the answer model (if there were issues)
            return View(answer);
        }



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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,Title,Description,Tags,UserId")] Question question)
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
