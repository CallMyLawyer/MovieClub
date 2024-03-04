using MovieClub.Entities.Movies;
using MovieClub.Services.Genders.Contracts.Dtos;

namespace MovieClub.test.Taools.Categories.DtoFactories;

public static class AddCategoryDtoFactory
{
    public static AddCategoryDto Create()
    {
        var dto = new AddCategoryDto()
        {
            Title = "karim",
            Rate = 0,
            Movies = new List<Movie?>()
        };
        return dto;
    }
}