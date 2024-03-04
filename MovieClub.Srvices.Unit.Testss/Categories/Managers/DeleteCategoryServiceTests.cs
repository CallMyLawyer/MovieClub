using FluentAssertions;
using MovieClub.Persistance.EF;
using MovieClub.Services.Genders.Contracts;
using MovieClub.Services.Movies.Contracts.Exceptions;
using MovieClub.test.Taools.Categories;
using MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;
using Xunit;

namespace MovieClub.Srvices.Unit.Testss.Categories.Managers;

public class DeleteCategoryServiceTests
{
    private readonly EFDataContext _context;
    private readonly EFDataContext _readContext;
    private readonly ICategoryManagerService _sut;

    public DeleteCategoryServiceTests()
    {
        var db = new EFInMemoryDatabase();
        _context = db.CreateDataContext<EFDataContext>();
        _readContext = db.CreateDataContext<EFDataContext>();
        _sut = CategoryServiceFactory.Create(_context);
    }

    [Fact]
    public async Task Delete_delete_a_category_properly()
    {
        var category = new CategoryBuilder().Build();
        _context.Save(category);

        await _sut.Delete(category.Id);

        var act = _readContext.Categories;

        act.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task Delete_throws_exception_when_is_does_not_exist()
    {
        var act = () => _sut.Delete(3);
        await act.Should().ThrowExactlyAsync<CategoryIdDoesNotExistException>();
    }

}