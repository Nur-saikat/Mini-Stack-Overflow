using Mini_Stack_Overflow.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Stack_Overflow.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public bool CountUpvotes { get; set; }
        public bool CountDownvotes { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

    }
}
