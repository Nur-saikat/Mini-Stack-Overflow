using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mini_Stack_Overflow.Areas.Identity.Data;
using Mini_Stack_Overflow.Models;

namespace Mini_Stack_Overflow.Areas.Identity.Data;

public class Mini_Stack_OverflowContext : IdentityDbContext<ApplicationUser>
{
    public Mini_Stack_OverflowContext(DbContextOptions<Mini_Stack_OverflowContext> options)
        : base(options)
    {
    }
    //public virtual DbSet<Vote>Votes { get; set; }
    public virtual DbSet<Answer>Answers { get; set; }
    public virtual DbSet<Question>Questions { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<Mini_Stack_Overflow.Models.Question> Question { get; set; } = default!;
}
