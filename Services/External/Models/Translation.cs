namespace Services.External.Models
{
    /// <summary>
    /// Data retrieved from the Translation API
    /// </summary>
    public class Translation
    {
        /// <summary>
        /// Indicates the success of a API request
        /// </summary>
        public Success Success { get; set; }

        /// <summary>       
        /// The contents of a API response
        /// </summary>
        public Contents Contents { get; set; }
    }

    /// <summary>
    /// Translation API success
    /// </summary>
    public class Success
    {
        /// <summary>
        /// A number greater than 0 indicates success
        /// </summary>
        public int Total { get; set; }
    }

    /// <summary>
    /// Translation API contents
    /// </summary>
    public class Contents
    {
        /// <summary>
        /// The translated text
        /// </summary>
        public string Translated { get; set; }
    }
}
