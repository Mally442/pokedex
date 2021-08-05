using System.Threading.Tasks;
using Services.External.Models;

namespace Services.External.Interfaces
{
    /// <summary>
    /// Coordinates requests to the Pokemon API
    /// </summary>
    public interface IPokemonService
    {
        /// <summary>
        /// Gets information about a Pokemon species
        /// </summary>
        /// <param name="name">The name of the Pokemon species</param>
        /// <returns>The information about the Pokemon species, null if the species is not found or an error occurs</returns>
        public Task<Species> Get(string name);
    }
}
