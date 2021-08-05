using Microsoft.AspNetCore.Mvc;
using Services.Internal.Interfaces;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Provides endpoints to get information about Pokemon
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        #region Private Fields

        private readonly ISpeciesService _speciesService;

        #endregion Private Fields

        #region Constructors

        public PokemonController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        #endregion Constructors

        #region Read Operations

        /// <summary>
        /// Gets basic Pokemon information
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     GET /pokemon/mewtwo
        ///
        /// </remarks>
        /// <param name="name">The name of the Pokemon</param>
        /// <returns>The basic information about the Pokemon</returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var species = await _speciesService.Get(name);

            if (species == null)
            {
                return NotFound();
            }

            return Ok(species);
        }

        /// <summary>
        /// Gets translated Pokemon description and other basic information
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     GET /pokemon/translated/mewtwo
        ///
        /// </remarks>
        /// <param name="name">The name of the Pokemon</param>
        /// <returns>The translated description and other basic information about the Pokemon</returns>
        [HttpGet("translated/{name}")]
        public async Task<IActionResult> GetTranslated(string name)
        {
            var species = await _speciesService.Get(name, true);

            if (species == null)
            {
                return NotFound();
            }

            return Ok(species);
        }

        #endregion Read Operations
    }
}
