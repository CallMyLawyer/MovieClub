using MovieClub.Entities.Movies;

namespace MovieClub.test.Taools.Movies;

public class MovieBuilder
{
    private readonly Movie _movie;

    public MovieBuilder()
    {
        _movie = new Movie()
        {
         Id = 1,
         AgeLimit = 18,
         CategoryId = 1,
         Count = 1,
         DailyRentPrice = 100,
         Description = "miobio",
         Director = "Karim",
         Duration =2,
         Name = "KarimPoor",
         PenaltyPrice = 120,
         Rate = 3,
         PublishedDate = new DateTime(2005/02/01)
        };
    }

    public MovieBuilder WithName(string name)
    {
        _movie.Name = name;
        return this;
    }

    public MovieBuilder WithId(int id)
    {
        _movie.Id = id;
        return this;
    }

    public MovieBuilder WithCategoryId(int categoryId)
    {
        _movie.CategoryId = categoryId;
        return this;
    }

    public Movie Build()
    {
        return _movie;
    }
}