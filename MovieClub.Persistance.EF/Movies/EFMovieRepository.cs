using MovieClub.Entities.Movies;
using MovieClub.Services.Movies.Contracts;
using MovieClub.Services.Movies.Contracts.MovieUserContracts;

namespace MovieClub.Persistance.EF.Movies;

public class EFMovieRepository : IMovieManagerRepository , IMovieUserRepository
{
    private readonly EFDataContext _context;

    public EFMovieRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Movie movie)
    {
        _context.Movies.Add(movie); 
    }

    public bool MultiplyName(string name)
    {
        if (_context.Movies.FirstOrDefault(_ => _.Name==name)!=null)
        {
            return true;
        }

        return false;
    }
}