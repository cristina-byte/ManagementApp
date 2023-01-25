using Application.Abstraction;
using Application.Commands.UserCommand;
using Infrastructure;
using Infrastructure.Repositories;
using ManagementTool.API;
using ManagementTool.API.Middlewares;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o =>
    o.AddDefaultPolicy(b =>
        b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("x-total")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

builder.Services.AddMvc()
     .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = "http://localhost:3000",
            ValidIssuer = "https://localhost:7257",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5b1dc4c1-1fa3-4e3d-9f47-04d5a566ba55"))
        };
    });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
builder.Services.AddMediatR(typeof(CreateUserCommand).Assembly);
builder.Services.AddAutoMapper(typeof(AssemblyMarketPresentatio));
builder.Services.Configure<MyApplicationSettings>(builder.Configuration.GetSection(nameof(MyApplicationSettings)));
var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseExceptionMiddleware();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
