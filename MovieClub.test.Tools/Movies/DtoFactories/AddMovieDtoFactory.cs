using MovieClub.Services.Movies.Contracts.Dtos;

namespace MovieClub.test.Taools.Movies.DtoFactories;

public static class AddMovieDtoFactory
{
    public static AddMovieDto Create()
    {
        var dto = new AddMovieDto()
        {
            AgeLimit = 18,
            CategoryId = 1,
            Count = 1,
            DailyRentPrice = 100,
            Description = "miobio",
            Director = "Karim",
            Duration = 2,
            Name = "KarimPoor",
            PenaltyPrice = 120,
            PublishedDate = new DateTime(2005 / 02 / 01)
        };
        return dto;
    }
}