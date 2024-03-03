using MovieClub.Services.Movies.Contracts.Dtos;

namespace MovieClub.Services.Movies.Contracts;

public interface IMovieManagerService
{
    Task Add(AddMovieDto dto);
}