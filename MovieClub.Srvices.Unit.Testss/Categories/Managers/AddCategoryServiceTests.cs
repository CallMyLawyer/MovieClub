using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MovieClub.Persistance.EF;
using MovieClub.Services.Categories.Contracts.CatetoryManagersContracts.Exceptions;
using MovieClub.Services.Genders.Contracts;
using MovieClub.test.Taools.Categories;
using MovieClub.test.Taools.Categories.DtoFactories;
using MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;
using Xunit;

namespace MovieClub.Srvices.Unit.Testss.Categories.Managers;

public class AddCategoryServiceTests
{
    private readonly EFDataContext _context;
    private readonly EFDataContext _readContext;
    private readonly ICategoryManagerService _sut;

    public AddCategoryServiceTests()
    {
        var db = new EFInMemoryDatabase();
        _context = db.CreateDataContext<EFDataContext>();
        _readContext = db.CreateDataContext<EFDataContext>();
        _sut = CategoryServiceFactory.Create(_context);
    }

    [Fact]
    public async Task Add_add_a_category_properly()
    {
        var dto = AddCategoryDtoFactory.Create();
        await _sut.Add(dto);

        var act = _readContext.Categories.Single();

        act.Title.Should().Be(dto.Title);
        act.Rate.Should().Be(dto.Rate);
        act.Movies.Should().BeNull();
    }

    [Fact]
    public async Task Add_throws_exception_when_category_Title_already_exist()
    {
        var category = new CategoryBuilder().WithTitle("karim").Build();
        _context.Save(category);

        var dto = AddCategoryDtoFactory.Create();
        var act = () => _sut.Add(dto);

        await act.Should().ThrowExactlyAsync<CategoryTitleAlreadyExistException>();
    }
}