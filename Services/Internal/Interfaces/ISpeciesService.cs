using System.Threading.Tasks;
using Services.Internal.Models;

namespace Services.Internal.Interfaces
{
    /// <summary>
    /// Coordinates the retrieval of Pokemon species information
    /// </summary>
    public interface ISpeciesService
    {
        /// <summary>
        /// Gets basic information about a Pokemon species, with the option of translating the description of the species
        /// </summary>
        /// <param name="name">The name of the Pokemon species</param>
        /// <param name="doTranslation">TRUE if the description of the species should be translated</param>
        /// <returns>The basic information about the Pokemon species, description translated if specified</returns>
        Task<Species> Get(string name, bool doTranslation = false);
    }
}
