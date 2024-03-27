using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FashionHeaven.Infrastructure.Data
{
    public class FashionHeavenContext : IdentityDbContext
    {
        public FashionHeavenContext(DbContextOptions<FashionHeavenContext> options)
            : base(options)
        {
        }
    }
}
