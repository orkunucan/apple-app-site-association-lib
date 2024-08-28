using System.Text.Json.Serialization;

namespace AppleAppSiteAssociation.AspNet.Responses
{
    /// <summary>
    /// Represents the response for the Apple App Site Association file.
    /// </summary>
    public class AppleAppSiteAssociationResponse
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AppLinkResponse"/>.
        /// </summary>
        [JsonPropertyName("applinks")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AppLinkResponse AppLinks { get; set; }
        
        /// <summary>
        /// Initializes a new instance of <see cref="WebCredentialResponse"/>.
        /// </summary>
        [JsonPropertyName("webcredentials")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WebCredentialResponse WebCredentials { get; set; }
        
        /// <summary>
        /// Initializes a new instance of <see cref="AppClipResponse"/>.
        /// </summary>
        [JsonPropertyName("appclips")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AppClipResponse AppClips { get; set; }
    }
}