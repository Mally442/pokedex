using System.Threading.Tasks;

namespace Services.External.Interfaces
{
    /// <summary>
    /// Coordinates requests to the Translation API
    /// </summary>
    public interface ITranslationService
    {
        /// <summary>
        /// Gets the translation of the specified text
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <returns>The translation of the specified text, null if the text could not be translated</returns>
        public Task<string> Get(string text);
    }
}
