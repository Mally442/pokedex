namespace Services.External.Implementations
{
    /// <summary>
    /// Coordinates requests to the Shakespeare translation API
    /// </summary>
    public class ShakespeareTranslationService : TranslationService
    {
        /// <summary>
        /// The URL where Shakespeare translation requests are sent
        /// </summary>
        protected override string Url => "https://api.funtranslations.com/translate/shakespeare";
    }
}
