using Mini_Stack_Overflow.Areas.Identity.Data;

namespace Mini_Stack_Overflow.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public bool IsUpvote { get; set; }
        public string Email { get; set; }
        public int AnswerCount { get; set; }
        public int QuestionCount {  get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
