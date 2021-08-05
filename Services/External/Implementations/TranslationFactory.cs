using Services.External.Interfaces;
using Services.Internal.Models;

namespace Services.External.Implementations
{
    /// <summary>
    /// Creates translation services
    /// </summary>
    public class TranslationFactory : ITranslationFactory
    {
        /// <summary>
        /// Creates a translation service based on the properties of the species provided
        /// </summary>
        /// <param name="species">The species whose properties determine which translation service is created</param>
        /// <returns>A translation service</returns>
        public ITranslationService CreateService(Species species)
        {
            if (species.Habitat == "cave" || species.IsLegendary)
            {
                return new YodaTranslationService();
            }

            return new ShakespeareTranslationService();
        }
    }
}
