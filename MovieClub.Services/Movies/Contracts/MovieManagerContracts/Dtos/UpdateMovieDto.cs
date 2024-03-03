namespace MovieClub.Services.Movies.Contracts.Dtos;

public class UpdateMovieDto
{
    public string Name{ get; set; }
    public string Description{ get; set; }
    public DateTime PublishedDate{ get; set; }
    public int DailyRentPrice{ get; set; }
    public int AgeLimit{ get; set; }
    public int PenaltyPrice{ get; set; }
    public int Duration{ get; set; }
    public int Count{ get; set; }
    public string Director{ get; set; }
    public int CategoryId{ get; set; }
}