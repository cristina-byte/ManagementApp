using Application.Abstraction;
using Application.Commands.UserCommand;
using AutoMapper;
using Infrastructure;
using Infrastructure.Repositories;
using ManagementTool.API;
using ManagementTool.API.Dto;
using ManagementTool.API.Profiles;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IEventRepository), typeof(EventRepository));
builder.Services.AddScoped(typeof(IMeetingRepository), typeof(MeetingRepository));
builder.Services.AddScoped(typeof(IMemberRepository), typeof(MemberRepository));
builder.Services.AddScoped(typeof(IMessageRepository), typeof(MessageRepository));
builder.Services.AddScoped(typeof(IOportunityRepository), typeof(OportunityRepository));
builder.Services.AddScoped(typeof(ITeamRepository), typeof(TeamRepository));
builder.Services.AddScoped(typeof(IToDoRepository), typeof(ToDoRepository));
builder.Services.AddScoped(typeof(ITaskRepository), typeof(TaskRepository));
builder.Services.AddScoped(typeof(IChatRepository), typeof(ChatRepository));
builder.Services.AddScoped(typeof(IMessageRepository), typeof(MessageRepository));
builder.Services.AddScoped(typeof(IOportunityPositionRepository), typeof(OportunityPositionRepository));
builder.Services.AddScoped(typeof(ICoreTeamPositionRepository), typeof(CoreTeamPositionRepository));
builder.Services.AddMediatR(typeof(CreateUserCommand).Assembly);
builder.Services.AddAutoMapper(typeof(AssemblyMarketPresentatio));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
