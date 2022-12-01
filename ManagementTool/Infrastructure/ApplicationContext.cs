using Domain.Entities;
using Domain.Entities.OportunityEntities;
using Domain.Entities.TeamEntities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.TeamEntities.Task;

namespace Infrastructure
{
    public class ApplicationContext : DbContext

        //it's virtual representation of the database
    {
        //DbSet represents the collection of all entities in the context or that can be queried from the database, of a given type

        //Intuitively, a DbContext corresponds to your database(or a collection of tables and views in your database) 
        //whereas a DbSet corresponds to a table or view in your database.

        public DbSet<User> Users{get;set;}
        public DbSet<Team> Teams { get;set;}
        public DbSet<Chat> Conversations { get; set; }
        public DbSet<ToDo> ToDoLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Oportunity> Oportunities { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<CoreTeamPosition> CoreTeamPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection database providing connection string
            optionsBuilder.UseSqlServer("Data Source=WINDOWS-7MAF9I6\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True").LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name})
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<Team>().ToTable("Teams");


        }
    }
    
}
