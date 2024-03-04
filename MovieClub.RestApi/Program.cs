using MovieClub.Contracts.Interfaces;
using MovieClub.Persistance.EF;
using MovieClub.Persistance.EF.Categories;
using MovieClub.Persistance.EF.Movies;
using MovieClub.Services.Genders.Contracts;
using MovieClub.Services.Movies;
using MovieClub.Services.Movies.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EFDataContext>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ICategoryManagerService, CategoryManagerAppService>();
builder.Services.AddScoped<ICategoryManagerRepository, EFCategoryRepository>();
builder.Services.AddScoped<IMovieManagerService, MovieManagerAppService>();
builder.Services.AddScoped<IMovieManagerRepository, EFMovieRepository>();
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