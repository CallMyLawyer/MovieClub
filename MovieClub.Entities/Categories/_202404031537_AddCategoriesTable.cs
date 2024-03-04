using System.ComponentModel.DataAnnotations;
using MovieClub.Entities.Movies;

namespace MovieClub.Entities.Categories;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required , MaxLength(50)]
    public string Title{ get; set; }
   [Required] 
    public int Rate{ get; set; }
    
    public List<Movie?> Movies{ get; set; }
}