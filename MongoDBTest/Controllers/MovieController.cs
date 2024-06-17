using Microsoft.AspNetCore.Mvc;
using MongoDBTest.Models;
using MongoDBTest.Services;

namespace MongoDBTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _movieService.GetAsync());
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult> Get(string id)
        {
            var item = await _movieService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie item)
        {
            await _movieService.CreateAsync(item);

            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Movie item)
        {
            await _movieService.UpdateAsync(item);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _movieService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _movieService.RemoveAsync(id);

            return NoContent();
        }
    }
}