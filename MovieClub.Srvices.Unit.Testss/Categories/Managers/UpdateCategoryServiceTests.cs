using FluentAssertions;
using MovieClub.Persistance.EF;
using MovieClub.Services.Categories.Contracts.CatetoryManagersContracts.Exceptions;
using MovieClub.Services.Genders.Contracts;
using MovieClub.Services.Movies.Contracts.Exceptions;
using MovieClub.test.Taools.Categories;
using MovieClub.test.Taools.Categories.DtoFactories;
using MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;
using Xunit;

namespace MovieClub.Srvices.Unit.Testss.Categories.Managers;

public class UpdateCategoryServiceTests
{
    private readonly EFDataContext _context;
    private readonly EFDataContext _readContext;
    private readonly ICategoryManagerService _sut;

    public UpdateCategoryServiceTests()
    {
        var db = new EFInMemoryDatabase();
        _context = db.CreateDataContext<EFDataContext>();
        _readContext = db.CreateDataContext<EFDataContext>();
        _sut = CategoryServiceFactory.Create(_context);
    }

    [Fact]
    public async Task Update_update_a_category_properly()
    {
        var category = new CategoryBuilder().Build();
        _context.Save( category);

        var dto = UpdateCategoryDtoFactory.Create();
        await _sut.Update(category.Id, dto);

        var act = _readContext.Categories.Single();

        act.Rate.Should().Be(dto.Rate);
        act.Title.Should().Be(dto.Title);
    }

    [Fact]
    public async Task Update_throws_exception_when_category_title_duplicated()
    {
        var category1 = new CategoryBuilder().WithTitle("karim").Build();
        _context.Save(category1);
        var category2 = new CategoryBuilder().WithTitle("karim2").WithId(2).Build();
        _context.Save(category2);

        var dto = UpdateCategoryDtoFactory.Create();

        var act = () => _sut.Update(category1.Id, dto);

        await act.Should().ThrowExactlyAsync<CategoryTitleAlreadyExistException>();
    }

    [Fact]
    public async Task Update_throws_exception_when_Category_id_does_not_exist()
    {
        var dto = UpdateCategoryDtoFactory.Create();

        var act = () => _sut.Update(5, dto);

        await act.Should().ThrowExactlyAsync<CategoryIdDoesNotExistException>();
    }
}