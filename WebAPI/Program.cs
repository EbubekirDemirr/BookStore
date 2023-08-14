using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Core.EmailSender;
using Core.Redis;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using DataAccess.UnitOfWork;
using Entities.Concrete.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors();

var configuration = builder.Configuration;
builder.Services.AddIdentity<AppUser, IdentityRole>()
.AddEntityFrameworkStores<LibraryContext>()
.AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options => options.SignIn.RequireConfirmedEmail = true);

builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<IBookImageService, BookImageManager>();
builder.Services.AddScoped<IBookImageDal, EfBookImageDal>();
builder.Services.AddScoped<IFileHelper, FileHelperManager>();
builder.Services.AddScoped<IBookAndCategoryService, BookAndCategoryManager>();
builder.Services.AddScoped<IBookAndCategoryDal, EfBookAndCategoryDal>();
builder.Services.AddScoped<IBookAndAuthorService, BookAndAuthorManager>();
builder.Services.AddScoped<IBookAndAuthorDal, EfBookAndAuthorDal>();
builder.Services.AddScoped<IOtpCodeDal, EfOtpCodeDal>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<IUserService, UserServiceManager>();
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<IBookDal, EfBookDal>();
builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<IAuthorDal, EfAuthorDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<IPublisherService, PublisherManager>();
builder.Services.AddScoped<IPublisherDal, EfPublisherDal>();
builder.Services.AddScoped<IUnitOfWorkDal, UnitOfWork>();




builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddEntityFrameworkNpgsql().AddDbContext<LibraryContext>(opt =>
opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RedisCacheDemo",
        Version = "v1"
    });
});
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
var mapper = app.Services.GetRequiredService<IMapper>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RedisCacheDemo v1"));
}


app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();