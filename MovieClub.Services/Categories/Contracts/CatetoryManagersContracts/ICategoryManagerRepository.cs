using MovieClub.Entities.Categories;
using MovieClub.Entities.Movies;
using MovieClub.Services.Genders.Contracts.Dtos;

namespace MovieClub.Services.Genders.Contracts;

public interface ICategoryManagerRepository
{
    bool IsExistCategoryId(int? id);
    bool IsExistCategoryTitle(string title);
    Category? AddMovieToCategory(Movie movie);
    void Add(Category category);
    Category? FindCategoryById(int id);
    List<GetCategoryDto> GetAllOrOne(int? id);

    void Delete(int id);
    bool MovieExistInCategory(int id);
}