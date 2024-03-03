using MovieClub.Persistance.EF;
using MovieClub.Persistance.EF.Categories;
using MovieClub.Persistance.EF.Movies;
using MovieClub.Services.Movies;
using MovieClub.Services.Movies.Contracts;

namespace MovieClub.test.Taools.Movies;

public static class MovieServiceFactory
{
    public static IMovieManagerService Create(EFDataContext context)
    {
        return new MovieManagerAppService(new EFUnitOfWork(context) ,
            new EFMovieRepository(context),
            new EFCategoryRepository(context));
    }
}