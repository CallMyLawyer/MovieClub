using MovieClub.Entities.Movies;
using MovieClub.Services.Movies.Contracts.Dtos;

namespace MovieClub.Services.Movies.Contracts;

public interface IMovieManagerRepository
{
    void Add(Movie movie);
    bool MultiplyName(string name);
    Movie? FindById(int? id);
    List<GetMovieDto> Get(int? id);
    void Delete(int id);
}