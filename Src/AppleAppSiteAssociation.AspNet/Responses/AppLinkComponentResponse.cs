using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppleAppSiteAssociation.AspNet.Responses
{
    /// <summary>
    /// Represents the response for the Apple App Site Association file.
    /// </summary>
    public class AppLinkComponentResponse
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AppLinkComponentResponse"/>.
        /// </summary>
        public AppLinkComponentResponse()
        {
            // Query = new Dictionary<string, object>();
        }

        /// <summary>
        /// # Fragment identifier
        /// </summary>
        [JsonPropertyName("#")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Fragment { get; set; }

        /// <summary>
        /// / Path to content
        /// </summary>
        [JsonPropertyName("/")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Path { get; set; }

        /// <summary>
        /// ? Query parameters
        /// </summary>
        [JsonPropertyName("?")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, object> Query { get; set; }

        /// <summary>
        /// Comment for the app link.
        /// </summary>
        [JsonPropertyName("comment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Comment { get; set; }

        /// <summary>
        /// Exclude the app link.
        /// </summary>
        [JsonPropertyName("exclude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Exclude { get; set; }
    }
}