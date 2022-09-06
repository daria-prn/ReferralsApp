using Microsoft.EntityFrameworkCore;

namespace ReferralsApp.Models
{
    public class ReferralContext : DbContext
    {
        public ReferralContext(DbContextOptions<ReferralContext> options)
            : base(options) { 
        
        }

        public DbSet<Referral> Referrals { get; set; } = null!;
    }
}
