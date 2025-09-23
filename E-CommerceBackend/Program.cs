using E_CommerceBackend.Data;
using E_CommerceBackend.Handlers;
using E_CommerceBackend.MappingProfiles;
using E_CommerceBackend.Models;
using E_CommerceBackend.Repository;
using E_CommerceBackend.Repository.IRepository;
using E_CommerceBackend.Services;
using E_CommerceBackend.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IAccountService, AccountService>();


builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<CategoryProfile>();
    cfg.AddProfile<ProductProfile>();
    // Add other profiles here if needed
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorE_CommerceApp",
        policy => policy.WithOrigins("https://localhost:7192") 
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BlazorE_CommerceApp");
app.UseExceptionHandler();

app.UseStaticFiles();

app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
