using FluentAssertions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MovieClub.Persistance.EF;
using MovieClub.Services.Movies.Contracts;
using MovieClub.Services.Movies.Contracts.Exceptions;
using MovieClub.test.Taools.Categories;
using MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;
using MovieClub.test.Taools.Movies;
using Xunit;

namespace MovieClub.Srvices.Unit.Testss.Movies.Managers;

public class DeleteMovieServiceTests
{
    private readonly EFDataContext _context;
    private readonly EFDataContext _readContext;
    private readonly IMovieManagerService _sut;

    public DeleteMovieServiceTests()
    {
        var db = new EFInMemoryDatabase();
        _context = db.CreateDataContext<EFDataContext>();
        _readContext = db.CreateDataContext < EFDataContext>();
        _sut = MovieServiceFactory.Create(_context);
    }

    [Fact]
    public async Task Delete_delete_a_movie_properly()
    {
        var category = new CategoryBuilder().Build();
        _context.Save(category);

        var movie = new MovieBuilder().WithId(2).Build();
        _context.Save(movie);

        await _sut.Delete(movie.Id);

        var act = _readContext.Movies.FirstOrDefault(_ => _.Id == movie.Id);

        act.Should().BeNull();
    }

    [Fact]
    public async Task Delete_throws_exception_when_id_does_not_exist()
    {
        var act = () => _sut.Delete(8);
        await act.Should().ThrowExactlyAsync<MovieIdDoesNotExistException>();
    }
}