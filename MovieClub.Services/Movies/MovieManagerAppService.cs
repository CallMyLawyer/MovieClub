using System.Diagnostics;
using System.Runtime.InteropServices;
using MovieClub.Contracts.Interfaces;
using MovieClub.Entities.Categories;
using MovieClub.Entities.Movies;
using MovieClub.Services.Genders.Contracts;
using MovieClub.Services.Movies.Contracts;
using MovieClub.Services.Movies.Contracts.Dtos;
using MovieClub.Services.Movies.Contracts.Exceptions;

namespace MovieClub.Services.Movies;

public class MovieManagerAppService : IMovieManagerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMovieManagerRepository _movieRepository;
    private readonly ICategoryManagerRepository _categoryRepository;

    public MovieManagerAppService(IUnitOfWork unitOfWork
    , IMovieManagerRepository movieRepository,
    ICategoryManagerRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _movieRepository = movieRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task Add(AddMovieDto dto )
    {
        if (_categoryRepository.IsExistCategoryId(dto.CategoryId))
        {
            throw new CategoryIdDoesNotExistException();
        }

        if (_movieRepository.MultiplyName(dto.Name))
        {
            throw new TheMovieNameAlreadyExistsException();
        }
        var movie = new Movie()
        {
         Name = dto.Name,
         AgeLimit = dto.AgeLimit,
         CategoryId = dto.CategoryId,
         Count = 1,
         DailyRentPrice = dto.DailyRentPrice,
         Description = dto.Description,
         Director = dto.Director,
         Duration = dto.Duration,
         PublishedDate = dto.PublishedDate,
         PenaltyPrice = dto.PenaltyPrice
        };
        _movieRepository.Add(movie);
        _categoryRepository.AddMovieToCategory(movie);
        await _unitOfWork.Complete();
    }

    public async Task Update(int id , UpdateMovieDto dto)
    {
        var movie = _movieRepository.FindById(id);
        if (movie==null)
        {
            throw new MovieIdDoesNotExistException();
        }
        if (_categoryRepository.IsExistCategoryId(dto.CategoryId))
        {
            throw new CategoryIdDoesNotExistException();
        }

        if (_movieRepository.MultiplyName(dto.Name))
        {
            throw new TheMovieNameAlreadyExistsException();
        }

        movie.Description = dto.Description;
        movie.PenaltyPrice = dto.PenaltyPrice;
        movie.CategoryId = dto.CategoryId;
        movie.Director = dto.Director;
        movie.Count = dto.Count = 1;
        movie.Duration = dto.Duration;
        movie.DailyRentPrice = dto.DailyRentPrice;
        movie.PublishedDate = dto.PublishedDate;
        movie.Name = dto.Name;
        movie.AgeLimit = dto.AgeLimit;
        
        

        await _unitOfWork.Complete();
    }

    public List<GetMovieDto> GetAllOrOne(int? id)
    {
        if (_movieRepository.FindById(id)==null)
        {
            throw new MovieIdDoesNotExistException();
        }
        var movies = _movieRepository.Get(id);
        return movies;
    }

    public async Task Delete(int id)
    {
        if (_movieRepository.FindById(id)==null)
        {
            throw new MovieIdDoesNotExistException();
        }
        _movieRepository.Delete(id);
        await _unitOfWork.Complete();
    }
}