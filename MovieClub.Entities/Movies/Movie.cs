using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieClub.Entities.Movies;

public class Movie
{
    [Key]
    public int Id{ get; set; }
    [Required , MaxLength(50)]
    public string Name{ get; set; }
    
    [MaxLength(300)]
    public string Description{ get; set; }

    public DateTime PublishedDate{ get; set; }
    
    [Required]
    public int DailyRentPrice{ get; set; }
    
    [Required]
    public int AgeLimit{ get; set; }

    [Required]
    public int PenaltyPrice{ get; set; }
    
    public int Duration{ get; set; }
    
    public int Rate{ get; set; }
    
    public int Count{ get; set; }
    
    [MaxLength(100)]
    public string Director{ get; set; }
    
    [Required ,ForeignKey("CategoryId")]
    public int CategoryId{ get; set; }
}