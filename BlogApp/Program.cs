using BlogApp.Data;
using BlogApp.Repositories;
using BlogApp.Repositories.Interfaces;
using BlogApp.Services;
using BlogApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IPostsService , PostsService>();
builder.Services.AddScoped<IPostsRepository , PostsRepository>();
builder.Services.AddScoped<ICommentsService , CommentsService>();
builder.Services.AddScoped<ICommentsRepository , CommentsRepository>();
builder.Services.AddScoped<IUserRegisterService , UserRegisterService>();
builder.Services.AddScoped<IUserRegisterRepository , UserRegisterRepository>();
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))));

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // React app origin
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors("AllowSpecificOrigin");

app.Run();
