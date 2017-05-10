using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Models;

namespace QuestPlatform.Domain.Context
{
    public class DataDbContext : IdentityDbContext<ApplicationUser>
    {
        public DataDbContext() : base("QuestsDbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DataDbContext>());
        }
        public DbSet<Beacon> Beacons { get; set; }
        public DbSet<BeaconInPark> BeaconsInPark { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<QuizTask> QuizTasks { get; set; }
        public DbSet<UserInGame> UsersInGame { get; set; }


        public static DataDbContext Create()
        {
            return new DataDbContext();
        }
    }
}
