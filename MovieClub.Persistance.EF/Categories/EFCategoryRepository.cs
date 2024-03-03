using MovieClub.Entities.Categories;
using MovieClub.Entities.Movies;
using MovieClub.Services.Genders.Contracts;

namespace MovieClub.Persistance.EF.Categories;

public class EFCategoryRepository : ICategoryManagerRepository
{
    private readonly EFDataContext _context;

    public EFCategoryRepository(EFDataContext context)
    {
        _context = context;
    }
    public bool IsExistCategoryId(int? id)
    {
        if (_context.Categories.FirstOrDefault(_=>_.Id==id) != null)
        {
            return false;
        }

        return true;
    }

    public Category? AddMovieToCategory(Movie movie)
    {
        var category = _context.Categories.FirstOrDefault(_ => _.Id == movie.CategoryId);
        return category;
    }

    public void Add(Category category)
    {
        _context.Categories.Add(category);
    }
}