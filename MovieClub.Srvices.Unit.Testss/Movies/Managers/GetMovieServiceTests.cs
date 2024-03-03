using FluentAssertions;
using MovieClub.Persistance.EF;
using MovieClub.Services.Movies.Contracts;
using MovieClub.Services.Movies.Contracts.Exceptions;
using MovieClub.test.Taools.Categories;
using MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;
using MovieClub.test.Taools.Movies;
using Xunit;

namespace MovieClub.Srvices.Unit.Testss.Movies.Managers;

public class GetMovieServiceTests
{
   private readonly EFDataContext _context;
   private readonly EFDataContext _readContext;
   private readonly IMovieManagerService _sut;

   public GetMovieServiceTests()
   {
      var db = new EFInMemoryDatabase();
      _context = db.CreateDataContext<EFDataContext>();
      _readContext = db.CreateDataContext<EFDataContext>();
      _sut = MovieServiceFactory.Create(_context);
   }

   [Fact]
   public void Get_get_all_or_one_movie_properly()
   {
      var category = new CategoryBuilder().Build();
      _context.Save(category);
      
      var movie1 = new MovieBuilder().Build();
      _context.Save(movie1);
      var movie2 = new MovieBuilder().WithId(2).Build();
      _context.Save(movie2);

      var act =_sut.GetAllOrOne(2);

      act.Should().NotBeNullOrEmpty();

   }

   [Fact]
   public void Get_throws_exception_when_id_does_not_exist()
   {
      var act = () => _sut.GetAllOrOne(5);
      act.Should().ThrowExactly<MovieIdDoesNotExistException>();
   }
}