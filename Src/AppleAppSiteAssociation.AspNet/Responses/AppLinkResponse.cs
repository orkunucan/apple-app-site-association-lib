using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppleAppSiteAssociation.AspNet.Responses
{
    /// <summary>
    /// Represents the response for the Apple App Site Association file.
    /// </summary>
    public class AppLinkResponse
    {
        /// <summary>
        /// A list of app IDs that are associated with the app .
        /// </summary>
        [JsonPropertyName("details")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<AppLinkDetailItemResponse> AppLinkDetails { get; set; }
    }
}