using MovieClub.Entities.Movies;
using MovieClub.Services.Genders.Contracts.Dtos;

namespace MovieClub.test.Taools.Categories.DtoFactories;

public static class UpdateCategoryDtoFactory
{
    public static UpdateCategoryDto Create()
    {
        var dto = new UpdateCategoryDto()
        {
            Title = "karim2",
            Rate = 2,
            Movies = new List<Movie?>()
        };
        return dto;
    }
}