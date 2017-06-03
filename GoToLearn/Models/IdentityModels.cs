using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace GoToLearn.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser

    {

        // [Required]
        [StringLength(255)]
        public string Login { get; set; }

        //[Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        
        //[Required]
        [StringLength(255)]
        public string LastName { get; set; }


        ////[Required]
        public DateTime Birthdate { get; set; }

       // [Required]
        [StringLength(255)]
        public string Country { get; set; }

        //[Required]
        [StringLength(255)]
        public string Gender { get; set; }


        //[StringLength(255)]
        public string membershipType { get; set; }

        [StringLength(255)]
        public string FOE { get; set; }

        [StringLength(255)]
        public string Level { get; set; }

        [StringLength(255)]
        public string Diploma { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<VideoConference> VideoConferences { get; set; }
        public DbSet<ChatMessages> ChatMessages { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}