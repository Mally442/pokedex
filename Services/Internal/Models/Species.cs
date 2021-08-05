using System.Linq;
using System.Text.RegularExpressions;

namespace Services.Internal.Models
{
    /// <summary>
    /// Basic information about a Pokemon species
    /// </summary>
    public class Species
    {
        #region Public Properties

        /// <summary>
        /// The name of the Pokemon species
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the Pokemon species
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The habitat the Pokemon species can be encountered in
        /// </summary>
        public string Habitat { get; set; }

        /// <summary>
        /// Whether or not the Pokemon species is legendary
        /// </summary>
        public bool IsLegendary { get; set; }

        #endregion Public Properties

        #region Properties Mappers 

        /// <summary>
        /// Map the properties of a species from an external species object
        /// </summary>
        /// <param name="speciesExternal">The external species object to map from</param>
        /// <returns>The species with properties mapped, null if the external species object was null</returns>
        public static Species MapFrom(External.Models.Species speciesExternal)
        {
            if (speciesExternal == null)
            {
                return null;
            }

            var species = new Species
            {
                Name = speciesExternal.Name,
                Habitat = speciesExternal.Habitat.Name,
                IsLegendary = speciesExternal.IsLegendary
            };

            // If we can't find an English description, return a null object
            var englishEntries = speciesExternal.FlavorTextEntries.Where(x => x.Language.Name == "en").ToArray();
            if (englishEntries.Length == 0)
            {
                return null;
            }

            // Default to the description from the red version, otherwise just choose the first one
            var entry = englishEntries.FirstOrDefault(x => x.Version.Name == "red") ?? englishEntries.First();
            species.Description = Regex.Replace(entry.FlavorText, "\n|\f", " ");

            return species;
        }

        #endregion Properties Mappers 
    }
}