namespace MovieClub.Services.Genders.Contracts;

public interface ICategoryManagerRepository
{
    bool IsExistCategoryId(int? id);
}