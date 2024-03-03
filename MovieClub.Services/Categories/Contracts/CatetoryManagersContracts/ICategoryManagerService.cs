using MovieClub.Services.Genders.Contracts.Dtos;

namespace MovieClub.Services.Genders.Contracts;

public interface ICategoryManagerService
{
    Task Add(AddCategoryDto dto);
}