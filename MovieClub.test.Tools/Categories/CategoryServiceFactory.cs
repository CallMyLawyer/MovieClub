using MovieClub.Persistance.EF;
using MovieClub.Persistance.EF.Categories;
using MovieClub.Services.Genders.Contracts;

namespace MovieClub.test.Taools.Categories;

public static class CategoryServiceFactory
{
    public static ICategoryManagerService Create(EFDataContext context)
    {
        return new CategoryManagerAppService(
            new EFCategoryRepository(context)
            , new EFUnitOfWork(context));
    }
}