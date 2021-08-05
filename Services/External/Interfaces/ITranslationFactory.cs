using Services.External.Implementations;
using Services.Internal.Models;

namespace Services.External.Interfaces
{
    /// <summary>
    /// Creates translation services
    /// </summary>
    public interface ITranslationFactory
    {
        /// <summary>
        /// Creates a translation service based on the properties of the species provided
        /// </summary>
        /// <param name="species">The species whose properties determine which translation service is created</param>
        /// <returns>A translation service</returns>
        public ITranslationService CreateService(Species species);
    }
}
