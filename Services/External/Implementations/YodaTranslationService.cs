namespace Services.External.Implementations
{
    /// <summary>
    /// Coordinates requests to the Yoda translation API
    /// </summary>
    public class YodaTranslationService : TranslationService
    {
        /// <summary>
        /// The URL where Yoda translation requests are sent
        /// </summary>
        protected override string Url => "https://api.funtranslations.com/translate/yoda";
    }
}
