using FluentAssertions;
using MovieClub.Persistance.EF;
using MovieClub.Services.Movies.Contracts;
using MovieClub.Services.Movies.Contracts.Exceptions;
using MovieClub.test.Taools.Categories;
using MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;
using MovieClub.test.Taools.Movies;
using MovieClub.test.Taools.Movies.DtoFactories;
using Xunit;

namespace MovieClub.Srvices.Unit.Testss.Movies.Managers;

public class UpdateMovieServiceTests
{
    private readonly EFDataContext _context;
    private readonly EFDataContext _readContext;
    private readonly IMovieManagerService _sut;

    public UpdateMovieServiceTests()
    {
        var db = new EFInMemoryDatabase();
        _context = db.CreateDataContext<EFDataContext>();
        _readContext = db.CreateDataContext<EFDataContext>();
        _sut = MovieServiceFactory.Create(_context);
    }

    [Fact]
    public async Task Update_update_a_movie_properly()
    {
        var category = new CategoryBuilder().Build();
        _context.Save(category);
        var movie = new MovieBuilder().Build();
        _context.Save(movie);
        
        var dto = UpdateMovieDtoFactory.Create();
        await _sut.Update(movie.Id, dto);

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
    public async Task Update_throws_exception_when_movie_id_does_not_exist()
    {
        var dto = UpdateMovieDtoFactory.Create();
        var act =()=> _sut.Update(2, dto);
        await act.Should().ThrowExactlyAsync<MovieIdDoesNotExistException>();
    }

    [Fact]
    public async Task Update_throws_exception_when_category_id_does_not_exist()
    {
        var category = new CategoryBuilder().Build();
        _context.Save(category);
        var movie = new MovieBuilder().Build();
        _context.Save(movie);
        
        var dto = UpdateMovieDtoFactory.Create();
        dto.CategoryId = 54;
        
        var act = () => _sut.Update(movie.Id, dto);
        await act.Should().ThrowExactlyAsync<CategoryIdDoesNotExistException>();
    }

    [Fact]
    public async Task Update_throws_exception_when_movie_name_is_duplicated()
    {
        var category = new CategoryBuilder().Build();
        _context.Save(category);
        var movie1 = new MovieBuilder().WithName("naser").Build();
        _context.Save(movie1);
        var movie2 = new MovieBuilder().WithName("Karim").WithId(2).Build();
        _context.Save(movie2);

        var dto = UpdateMovieDtoFactory.Create();

        var act = () => _sut.Update(movie1.Id, dto);
        await act.Should().ThrowExactlyAsync<TheMovieNameAlreadyExistsException>();
    }
}