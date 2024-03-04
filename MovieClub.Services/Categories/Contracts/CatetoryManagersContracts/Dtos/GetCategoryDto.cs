using System.ComponentModel.DataAnnotations;
using MovieClub.Entities.Movies;

namespace MovieClub.Services.Genders.Contracts.Dtos;

public class GetCategoryDto
{
    public int Id { get; set; }
    public string Title{ get; set; }
    public int Rate{ get; set; }
    public List<Movie?> Movies{ get; set; }
}