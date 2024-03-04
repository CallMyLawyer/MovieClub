using Microsoft.AspNetCore.Mvc;
using MovieClub.Services.Genders.Contracts;
using MovieClub.Services.Genders.Contracts.Dtos;

namespace MovieClub.RestApi.Controllers.Categories;
[Route("api/Managers")]
public class CategoryManagerController : Controller
{
    private readonly ICategoryManagerService _service;

    public CategoryManagerController(ICategoryManagerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task Add([FromBody]AddCategoryDto dto)
    {
        await _service.Add(dto);
    }

    [HttpPatch("id")]
    public async Task Update([FromQuery] int id, [FromBody] UpdateCategoryDto dto)
    {
        await _service.Update(id, dto);
    }

    [HttpGet("id")]
    public void Get([FromQuery] int id)
    {
        _service.Get(id);
    }

    [HttpDelete("id")]
    public async Task Delete([FromQuery] int id)
    {
        await _service.Delete(id);
    }


}