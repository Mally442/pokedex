using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services.External.Interfaces;
using Services.External.Models;

namespace Services.External.Implementations
{
    /// <summary>
    /// Coordinates requests to the Pokemon API
    /// </summary>
    public class PokemonService : IPokemonService
    {
        /// <summary>
        /// Gets information about a Pokemon species
        /// </summary>
        /// <param name="name">The name of the Pokemon species</param>
        /// <returns>The information about the Pokemon species, null if the species is not found or an error occurs</returns>
        public async Task<Species> Get(string name)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon-species/{name}/");

            if (response.IsSuccessStatusCode == false)
            {
                return null;
            }

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Species>(responseString);
        }
    }
}
