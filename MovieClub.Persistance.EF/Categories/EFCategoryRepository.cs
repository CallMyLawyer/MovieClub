using Microsoft.EntityFrameworkCore;
using MovieClub.Entities.Categories;
using MovieClub.Entities.Movies;
using MovieClub.Services.Categories.Contracts.CatetoryManagersContracts.Exceptions;
using MovieClub.Services.Genders.Contracts;
using MovieClub.Services.Genders.Contracts.Dtos;

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

    public bool IsExistCategoryTitle(string title)
    {
        if (_context.Categories.Any(_=>_.Title==title))
        {
            return true;
        }

        return false;
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

    public Category? FindCategoryById(int id)
    {
        var category = _context.Categories.FirstOrDefault(_ => _.Id == id);
        return category;
    }

    public List<GetCategoryDto> GetAllOrOne(int? id)
    {
        var categories = _context.Categories.Select(_ => new GetCategoryDto()
        {
         Id = _.Id,
         Title = _.Title,
         Rate = _.Rate,
         Movies = _.Movies
        }).ToList();
        if (id!=null)
        {
            var category = categories.Where(_ => _.Id == id).ToList();
            return category;
        }

        return categories;
    }

    public void Delete(int id)
    {
        var category = _context.Categories.Include(category => category.Movies).FirstOrDefault(_ => _.Id == id);
        if (category.Movies!=null)
        {
            throw new ThisCategoryHasMovieException();
        }
        _context.Categories.Remove(category);
    }
}