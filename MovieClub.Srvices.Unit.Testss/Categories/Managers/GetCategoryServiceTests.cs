using FluentAssertions;
using MovieClub.Persistance.EF;
using MovieClub.Services.Genders.Contracts;
using MovieClub.Services.Movies.Contracts.Exceptions;
using MovieClub.test.Taools.Categories;
using MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;
using Xunit;

namespace MovieClub.Srvices.Unit.Testss.Categories.Managers;

public class GetCategoryServiceTests
{
    private readonly EFDataContext _context;
    private readonly EFDataContext _readContext;
    private readonly ICategoryManagerService _sut;

    public GetCategoryServiceTests()
    {
        var db = new EFInMemoryDatabase();
        _context = db.CreateDataContext<EFDataContext>();
        _readContext = db.CreateDataContext<EFDataContext>();
        _sut = CategoryServiceFactory.Create(_context);
    }

    [Fact]
    public void Get_get_a_category_properly()
    {
        var category = new CategoryBuilder().Build();
        _context.Save(category);

        var act = _sut.Get(category.Id);

        act.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Get_should_throws_exception_when_category_id_does_not_exist()
    {
        var act = () => _sut.Get(5);
        act.Should().ThrowExactly<CategoryIdDoesNotExistException>();
    }
}