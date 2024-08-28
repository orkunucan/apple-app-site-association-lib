using System.Text.Json.Serialization;

namespace AppleAppSiteAssociation.AspNet.Responses
{
    /// <summary>
    /// Represents the response for the Apple App Site Association file.
    /// </summary>
    public class WebCredentialResponse
    {
        /// <summary>
        /// A list of app IDs that are associated with the web credentials.
        /// </summary>
        [JsonPropertyName("apps")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[] AppIds { get; set; }
    }
}