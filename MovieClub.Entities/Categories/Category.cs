using System.ComponentModel.DataAnnotations;
using MovieClub.Entities.Movies;

namespace MovieClub.Entities.Categories;

public class Category
{
    [Required , Key]
    public int Id{ get; set; }

    public string Title{ get; set; }
    public List<Movie> Movies{ get; set; }
    public int Rate{ get; set; }
}