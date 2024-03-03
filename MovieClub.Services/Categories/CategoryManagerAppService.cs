using MovieClub.Contracts.Interfaces;
using MovieClub.Entities.Categories;
using MovieClub.Services.Genders.Contracts.Dtos;

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
        var category = new Category()
        {
         Title = dto.Title,
         Rate = dto.Rate,
         Movies= dto.Movies
        };
        _categoryRepository.Add(category);
        await _unitOfWork.Complete();
    }
}