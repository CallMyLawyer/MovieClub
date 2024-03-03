using System.Data;
using MovieClub.Entities.Movies;
using MovieClub.Services.Movies.Contracts.Dtos;

namespace MovieClub.Services.Movies.Contracts;

public interface IMovieManagerService
{
    Task Add(AddMovieDto dto);
    Task Update(int id,UpdateMovieDto dto );
    List<GetMovieDto> GetAllOrOne(int? id);

    Task Delete(int id);
}