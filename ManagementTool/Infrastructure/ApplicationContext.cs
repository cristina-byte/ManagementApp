using Domain.Entities;
using Domain.MeetingEntities;
using Domain.OportunityEntities;
using Domain.TeamEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = Domain.TeamEntities.Task;

namespace Infrastructure
{
    public class ApplicationContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public override DbSet<User> Users{get;set;}
        public DbSet<Team> Teams { get;set;}
        public DbSet<MemberTeam> TeamMembers { get; set; }
        public DbSet<ToDo> ToDoLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Oportunity> Oportunities { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<MeetingInvited> MeetingInviteds { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<OportunityApplicant> OportunityApplicants { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //MemberTeam configuration
            modelBuilder.Entity<MemberTeam>().HasKey(mt => new { mt.MemberId, mt.TeamId });

            //UserTask configuration
            var userTask = modelBuilder.Entity<UserTask>();
            userTask.HasKey(ut => new { ut.TaskId,ut.UserId } );
            userTask.HasOne(ut => ut.User)
                    .WithMany(u => u.Tasks)
                    .HasForeignKey(ut => ut.UserId);
            userTask.HasOne(ut => ut.Task)
                    .WithMany(t => t.AssignedTo)
                    .HasForeignKey(ut => ut.TaskId);

            //Meeting configuration
            var meetingInvited = modelBuilder.Entity<MeetingInvited>();
            meetingInvited.HasKey(mI => new { mI.UserId, mI.MeetingId });

            meetingInvited.HasOne(mI => mI.User)
                          .WithMany(u => u.MeetingInvited)
                          .HasForeignKey(mI => mI.UserId);

            meetingInvited.HasOne(mI => mI.Meeting)
                            .WithMany(m => m.MeetingInvited)
                            .HasForeignKey(mI => mI.MeetingId);

            //OportunityApplicant configuration
            var oportunityApplicant = modelBuilder.Entity<OportunityApplicant>();
            oportunityApplicant.HasKey(oApp => new { oApp.UserId, oApp.OportunityId,oApp.PositionId });

            oportunityApplicant.HasOne(op => op.User)
                               .WithMany(u => u.OportunitiyApplicants)
                               .HasForeignKey(op => op.UserId);

            oportunityApplicant.HasOne(op => op.Oportunity)
                               .WithMany(o => o.OportunityApplicants)
                               .HasForeignKey(op => op.OportunityId);

            oportunityApplicant.HasOne(op => op.Position)
                             .WithMany(p=>p.PositionApplicants)
                             .HasForeignKey(op => op.PositionId);
        }
    }   
}
