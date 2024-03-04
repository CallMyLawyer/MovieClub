using MovieClub.Services.Genders.Contracts.Dtos;

namespace MovieClub.Services.Genders.Contracts;

public interface ICategoryManagerService
{
    Task Add(AddCategoryDto dto);
    Task Update(int id ,UpdateCategoryDto dto);
    List<GetCategoryDto> Get(int? id);
    Task Delete(int id);
}