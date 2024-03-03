using MovieClub.Entities.Categories;
using MovieClub.Entities.Movies;

namespace MovieClub.Services.Genders.Contracts;

public interface ICategoryManagerRepository
{
    bool IsExistCategoryId(int? id);
    Category? AddMovieToCategory(Movie movie);
}