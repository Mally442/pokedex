using Services.External.Interfaces;
using Services.Internal.Interfaces;
using Services.Internal.Models;
using System.Threading.Tasks;

namespace Services.Internal.Implementations
{
    /// <summary>
    /// Coordinates the retrieval of Pokemon species information
    /// </summary>
    public class SpeciesService : ISpeciesService
    {
        #region Private Fields

        private readonly IPokemonService _pokemonService;
        private readonly ITranslationFactory _translationFactory;

        #endregion Private Fields

        #region Constructors

        public SpeciesService(IPokemonService pokemonService, ITranslationFactory translationFactory)
        {
            _pokemonService = pokemonService;
            _translationFactory = translationFactory;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gets basic information about a Pokemon species, with the option of translating the description of the species
        /// </summary>
        /// <param name="name">The name of the Pokemon species</param>
        /// <param name="doTranslation">TRUE if the description of the species should be translated</param>
        /// <returns>The basic information about the Pokemon species, description translated if specified</returns>
        public async Task<Species> Get(string name, bool doTranslation = false)
        {
            var speciesExternal = await _pokemonService.Get(name);
            if (speciesExternal == null)
            {
                return null;
            }

            var species = Species.MapFrom(speciesExternal);

            if (doTranslation)
            {
                var translationService = _translationFactory.CreateService(species);
                var translatedDescription = await translationService.Get(species.Description);
                if (string.IsNullOrWhiteSpace(translatedDescription) == false)
                {
                    species.Description = translatedDescription;
                }
            }

            return species;
        }

        #endregion Public Methods
    }
}
