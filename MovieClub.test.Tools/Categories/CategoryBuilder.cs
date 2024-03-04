using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using MovieClub.Entities.Categories;
using MovieClub.Entities.Movies;

namespace MovieClub.test.Taools.Categories;

public class CategoryBuilder
{
    private readonly Category _category;

    public CategoryBuilder()
    {
        _category = new Category()
        {
         Id = 1,
         Title = "Mio",
         Rate = 1,
         Movies = new List<Movie?>()
        };
    }

    public CategoryBuilder WithId(int id)
    {
        _category.Id = id;
        return this;
    }
    public CategoryBuilder WithRate(int rate)
    {
        _category.Rate = rate;
        return this;
    }

    public CategoryBuilder WithTitle(string title)
    {
        _category.Title = title;
        return this;
    }

    public CategoryBuilder WithMovie(Movie movie)
    {
     _category.Movies.Add(movie);
     return this;
    }

    public Category Build()
    {
        return _category;
    }
}