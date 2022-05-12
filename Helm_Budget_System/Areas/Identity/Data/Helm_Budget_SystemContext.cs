using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Helm_Budget_System.Areas.Identity.Data;

public class Helm_Budget_SystemContext : IdentityDbContext<Helm_SystemUser>
{
    public Helm_Budget_SystemContext(DbContextOptions<Helm_Budget_SystemContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}
