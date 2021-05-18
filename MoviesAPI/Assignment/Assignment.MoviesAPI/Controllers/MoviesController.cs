using Assignment.DAL.Repository;
using Assignment.Entity;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [EnableQuery()]
        [HttpGet]
        public ActionResult<IQueryable<Movie>> GetAll()
        {
            var movies = _movieRepository.GetMovies();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}", Name = "GetMovieById")]
        public ActionResult<IEnumerable<Movie>> GetMovieById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var movie = _movieRepository.GetMovie(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            }
            return BadRequest();
        }

    }
}
