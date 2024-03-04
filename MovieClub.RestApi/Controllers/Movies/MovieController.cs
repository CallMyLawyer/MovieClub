using Microsoft.AspNetCore.Mvc;
using MovieClub.Services.Movies.Contracts;
using MovieClub.Services.Movies.Contracts.Dtos;

namespace MovieClub.RestApi.Controllers.Movies;
[Route("api/Managers")]
public class MovieController : Controller
{
    private readonly IMovieManagerService _service;

    public MovieController(IMovieManagerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task Add([FromBody] AddMovieDto dto)
    {
        await _service.Add(dto);
    }

    [HttpPatch("{id}")]
    public async Task Update([FromQuery] int id, [FromBody] UpdateMovieDto dto)
    {
        await _service.Update(id, dto);
    }

    [HttpGet("{id}")]
    public void Get([FromQuery] int id)
    {
        _service.GetAllOrOne(id);
    }

    [HttpDelete("{id}")]
    public async Task Delete([FromQuery] int id)
    {
        await _service.Delete(id);
    }
}