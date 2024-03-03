using MovieClub.Services.Movies.Contracts.Dtos;

namespace MovieClub.test.Taools.Movies.DtoFactories;

public static class UpdateMovieDtoFactory
{
 public static UpdateMovieDto Create()
 {
  var dto = new UpdateMovieDto()
  {
   AgeLimit = 18,
   CategoryId = 1,
   Count = 1,
   DailyRentPrice = 100,
   Description = "Naser",
   Director = "Karim",
   Duration = 2,
   Name = "Karim",
   PenaltyPrice = 120,
   PublishedDate = new DateTime(2005 / 02 / 01)
  };
  return dto;
 }
}