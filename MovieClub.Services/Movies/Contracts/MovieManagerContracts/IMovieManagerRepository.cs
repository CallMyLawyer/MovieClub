using MovieClub.Entities.Movies;

namespace MovieClub.Services.Movies.Contracts;

public interface IMovieManagerRepository
{
    void Add(Movie movie);
    bool MultiplyName(string name);
}