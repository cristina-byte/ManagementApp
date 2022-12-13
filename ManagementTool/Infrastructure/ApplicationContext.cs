using Domain.Entities;
using Domain.Entities.OportunityEntities;
using Domain.Entities.TeamEntities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.TeamEntities.Task;

namespace Infrastructure
{
    public class ApplicationContext : DbContext   
    {
        public DbSet<User> Users{get;set;}
        public DbSet<Team> Teams { get;set;}
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }
        public DbSet<MemberTeam> TeamMembers { get; set; }
        public DbSet<ToDo> ToDoLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Oportunity> Oportunities { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<MeetingInvited> MeetingInviteds { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<CoreTeamPosition> CoreTeamPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection database providing connection string
            optionsBuilder.UseSqlServer("Data Source=WINDOWS-7MAF9I6\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True; TrustServerCertificate=True").LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name})
                .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberTeam>().HasKey(mt => new { mt.MemberId, mt.TeamId });

            //UserTask configuration
            var userTask = modelBuilder.Entity<UserTask>();
            userTask.HasKey(ut => new { ut.UserId, ut.TaskId });
            userTask.HasOne(ut => ut.User)
                    .WithMany(u => u.Tasks)
                    .HasForeignKey(ut => ut.UserId);
            userTask.HasOne(ut => ut.Task)
                    .WithMany(t => t.AssignedTo)
                    .HasForeignKey(ut => ut.TaskId);

            //ChatMember configuration
            var chatMember=modelBuilder.Entity<ChatMember>();
            chatMember.HasKey(cm => new { cm.UserId, cm.ChatId });
            chatMember.HasOne(cm => cm.Chat)
                      .WithMany(c => c.Participants)
                      .HasForeignKey(cm => cm.ChatId);

            chatMember.HasOne(cm => cm.User)
                      .WithMany(m => m.Conversations)
                      .HasForeignKey(cm => cm.UserId);

            var meetingInvited = modelBuilder.Entity<MeetingInvited>();
            meetingInvited.HasKey(mI => new { mI.UserId, mI.MeetingId });

            meetingInvited.HasOne(mI => mI.User)
                          .WithMany(u => u.MeetingInvited)
                          .HasForeignKey(mI => mI.UserId);

            meetingInvited.HasOne(mI => mI.Meeting)
                            .WithMany(m => m.MeetingInvited)
                            .HasForeignKey(mI => mI.MeetingId);

        }
    }   
}
