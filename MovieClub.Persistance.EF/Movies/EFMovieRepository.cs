using System.Runtime.CompilerServices;
using MovieClub.Entities.Movies;
using MovieClub.Services.Movies.Contracts;
using MovieClub.Services.Movies.Contracts.Dtos;
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
        var category = _context.Categories.First(_ => _.Id == movie.CategoryId);
        category.Movies.Add(movie);
    }

    public bool MultiplyName(string name)
    {
        if (_context.Movies.FirstOrDefault(_ => _.Name==name)!=null)
        {
            return true;
        }

        return false;
    }

    public Movie?FindById(int? id)
    {
        return _context.Movies.FirstOrDefault(_ => _.Id == id);
    }

    public List<GetMovieDto> Get(int? id)
    {
        var movies = _context.Movies.Select(_ => new GetMovieDto()
        {
            Id = _.Id,
            Name = _.Name,
            AgeLimit = _.AgeLimit,
            CategoryId = _.CategoryId,
            Count = _.Count,
            DailyRentPrice = _.DailyRentPrice,
            Description = _.Description,
            Director = _.Director,
            Duration = _.Duration,
            PenaltyPrice = _.PenaltyPrice,
            Rate = _.Rate,
            PublishedDate = _.PublishedDate

        }).ToList();
        if (id!=null)
        {
            var movie = movies.Where(_ => _.Id == id).ToList();
            return movie;
        }

        return movies;
    }

    public void Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(_ => _.Id == id);
         _context.Movies.Remove(movie);
    }
}