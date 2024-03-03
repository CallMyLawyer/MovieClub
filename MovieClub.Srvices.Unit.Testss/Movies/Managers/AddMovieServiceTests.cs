using FluentAssertions;
using MovieClub.Persistance.EF;
using MovieClub.Services.Movies.Contracts;
using MovieClub.Services.Movies.Contracts.Dtos;
using MovieClub.Services.Movies.Contracts.Exceptions;
using MovieClub.test.Taools.Categories;
using MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;
using MovieClub.test.Taools.Movies;
using MovieClub.test.Taools.Movies.DtoFactories;
using Xunit;

namespace MovieClub.Srvices.Unit.Testss.Movies.Managers;

public class AddMovieServiceTests
{
   private readonly EFDataContext _context;
   private readonly EFDataContext _readContext;
   private readonly IMovieManagerService _sut;

   public AddMovieServiceTests()
   {
      var db = new EFInMemoryDatabase();
      _context = db.CreateDataContext<EFDataContext>();
      _readContext = db.CreateDataContext<EFDataContext>();
      _sut = MovieServiceFactory.Create(_context);
   }

   [Fact]
   public async Task Add_add_a_movie_to_a_category_properly()
   {
      var category = new CategoryBuilder().Build();
      _context.Save(category);
      var dto = AddMovieDtoFactory.Create();
      await _sut.Add(dto);
      var act = _readContext.Movies.Single();

      act.Description.Should().Be(dto.Description);
      act.Director.Should().Be(dto.Director);
      act.Count.Should().Be(dto.Count);
      act.Duration.Should().Be(dto.Duration);
      act.Name.Should().Be(dto.Name);
      act.AgeLimit.Should().Be(dto.AgeLimit);
      act.CategoryId.Should().Be(dto.CategoryId);
      act.PenaltyPrice.Should().Be(dto.PenaltyPrice);
      act.PublishedDate.Should().Be(dto.PublishedDate);
      act.DailyRentPrice.Should().Be(dto.DailyRentPrice);
   }

   [Fact]
   public async Task Add_throws_exception_when_CategoryId_Does_Not_Exist()
   {
      var dto = AddMovieDtoFactory.Create();
      var act = () => _sut.Add(dto);
      await act.Should().ThrowExactlyAsync<CategoryIdDoesNotExistException>();
   }

   [Fact]
   public async Task Add_throws_exception_when_the_movie_name_already_exist()
   {
      var category = new CategoryBuilder().Build();
      _context.Save(category);
      var movie = new MovieBuilder().WithName("KarimPoor").Build();
      _context.Save(movie);
      var dto = AddMovieDtoFactory.Create();
      var act =()=> _sut.Add(dto);

      await act.Should().ThrowExactlyAsync<TheMovieNameAlreadyExistsException>();

   }
}