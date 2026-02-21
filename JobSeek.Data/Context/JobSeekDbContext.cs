using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace JobSeek.Data
{
    public class JobSeekDBContext : IdentityDbContext<UserAccount>
    {
        public JobSeekDBContext(DbContextOptions<JobSeekDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserAccount>().ToTable("UserAccounts");

            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateDocument> CandidateDocuments { get; set; }
        public DbSet<Company> Companies{ get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobListing> JobListings { get; set; }



    }
}
