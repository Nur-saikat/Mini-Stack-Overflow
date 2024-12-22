using Mini_Stack_Overflow.Areas.Identity.Data;

namespace Mini_Stack_Overflow.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public bool IsUpvote { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Guid? UserId { get;  set; }
   

    }
}
