using Newtonsoft.Json;
using System.Collections.Generic;

namespace Services.External.Models
{
    /// <summary>
    /// Information about a Pokemon species retrieved from the Pokemon API
    /// </summary>
    public class Species
    {
        /// <summary>
        /// The name of Pokemon species
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A list of flavor text entries for the Pokemon species
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }

        /// <summary>
        /// The habitat the Pokemon species can be encountered in
        /// </summary>
        public Habitat Habitat { get; set; }

        /// <summary>
        /// Whether or not the Pokemon species is legendary
        /// </summary>
        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }
    }

    /// <summary>
    /// Localised flavor text for a Pokemon API resource in a specific language
    /// </summary>
    public class FlavorTextEntry
    {
        /// <summary>
        /// The localised text
        /// </summary>
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        /// <summary>
        /// The language the text is in
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// The game version the text is extracted from
        /// </summary>
        public Version Version { get; set; }
    }

    /// <summary>
    /// Language for translations of Pokemon API resource information
    /// </summary>
    public class Language
    {
        /// <summary>
        /// The name of the language
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Versions of the Pokemon games
    /// </summary>
    public class Version
    {
        /// <summary>
        /// The name of the version
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Habitats are generally different terrain Pokemon can be found in but can also be areas designated for rare or legendary Pokemon
    /// </summary>
    public class Habitat
    {
        /// <summary>
        /// The name of the habitat
        /// </summary>
        public string Name { get; set; }
    }
}
