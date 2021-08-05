using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services.External.Interfaces;
using Services.External.Models;

namespace Services.External.Implementations
{
    /// <summary>
    /// Coordinates requests to the Translation API
    /// </summary>
    public abstract class TranslationService : ITranslationService
    {
        /// <summary>
        /// The URL where translation requests are sent, needs to be overridden by the concrete class 
        /// </summary>
        protected abstract string Url { get; }

        /// <summary>
        /// Gets the translation of the specified text
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <returns>The translation of the specified text, null if the text could not be translated</returns>
        public async Task<string> Get(string text)
        {
            using var client = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("text", text)
            });

            var response = await client.PostAsync(Url, content);

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var translation = JsonConvert.DeserializeObject<Translation>(responseString);

            if (translation == null || translation.Success.Total == 0 || string.IsNullOrWhiteSpace(translation.Contents.Translated))
            {
                return null;
            }

            return translation.Contents.Translated;
        }
    }
}
