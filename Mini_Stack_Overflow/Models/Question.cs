using Microsoft.AspNetCore.Identity;
using Mini_Stack_Overflow.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Stack_Overflow.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Answer> Answer { get; } = new List<Answer>();
        public bool CountUpvotes { get; set; }
        public bool CountDownvotes { get; set; }
        public DateTime? CreateAt { get; set; } = DateTime.UtcNow;

    }
}
