using MovieProject.DataAccess.Contexts;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.Service.Abstracts;
using MovieProject.Service.Concretes;
using MovieProject.Service.Mappers.Categories;
using MovieProject.Service.Mappers.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dependecy Injection Lifecycle
//AddScoped() : Uygulama boyunca 1 tane nesne �retir. Nesnenin �mr� ise istek cevaba d�nene kadar.
//AddSingleton() : Uygulama boyunca 1 tane nesne �retir.
//AddTransient() : Uygulamada her istek i�in ayr� nesne olu�turur.

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryMapper,CategoryAutoMapper>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));   

builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
