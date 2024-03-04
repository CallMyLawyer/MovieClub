using MovieClub.Contracts.Interfaces;
using MovieClub.Entities.Categories;
using MovieClub.Services.Categories.Contracts.CatetoryManagersContracts.Exceptions;
using MovieClub.Services.Genders.Contracts.Dtos;
using MovieClub.Services.Movies.Contracts.Exceptions;

namespace MovieClub.Services.Genders.Contracts;

public class CategoryManagerAppService : ICategoryManagerService
{
    private readonly ICategoryManagerRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryManagerAppService(
        ICategoryManagerRepository categoryManagerRepository
        , IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryManagerRepository;
    }
    public async Task Add(AddCategoryDto dto)
    {
        if (_categoryRepository.IsExistCategoryTitle(dto.Title))
        {
            throw new CategoryTitleAlreadyExistException();
        }
        var category = new Category()
        {
         Title = dto.Title,
         Rate = dto.Rate,
         Movies= dto.Movies
        };
        _categoryRepository.Add(category);
        await _unitOfWork.Complete();
    }

    public async Task Update(int id ,UpdateCategoryDto dto)
    {
        if (_categoryRepository.IsExistCategoryId(id))
        {
            throw new CategoryIdDoesNotExistException();
        }

        if (_categoryRepository.IsExistCategoryTitle(dto.Title))
        {
            throw new CategoryTitleAlreadyExistException();
        }
        var category = _categoryRepository.FindCategoryById(id);

        category.Title = dto.Title;
        category.Movies = dto.Movies;
        category.Rate = dto.Rate;

        await _unitOfWork.Complete();
    }

    public List<GetCategoryDto> Get(int? id)
    {
        if (_categoryRepository.IsExistCategoryId(id))
        {
            throw new CategoryIdDoesNotExistException();
        }

        var category = _categoryRepository.GetAllOrOne(id);
        return category;
    }

    public async Task Delete(int id)
    {
        if (_categoryRepository.IsExistCategoryId(id))
        {
            throw new CategoryIdDoesNotExistException();
        }

        if (_categoryRepository.MovieExistInCategory(id))
        {
            throw new ThisCategoryHasMovieException();
        }
        _categoryRepository.Delete(id);
        await _unitOfWork.Complete();
    }
}