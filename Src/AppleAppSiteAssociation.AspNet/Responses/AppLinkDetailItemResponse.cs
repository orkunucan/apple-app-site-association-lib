using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using AppleAppSiteAssociation.AspNet.Configuration;

namespace AppleAppSiteAssociation.AspNet.Responses
{
    /// <summary>
    /// Represents the response for the Apple App Site Association file.
    /// </summary>
    public class AppLinkDetailItemResponse
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AppLinkDetailItemResponse"/>.
        /// </summary>
        public AppLinkDetailItemResponse(AppleAppSiteAssociationAppLinkItemOptions options)
        {
            AppIds = options.AppIds;

            Components = options.Components.Select(r =>
            {
                Dictionary<string, object> query = null;
                
                if (r.Query.Count > 0)
                {
                    query = r.Query;
                }
                return new AppLinkComponentResponse
                {
                    Query = query,
                    Fragment = r.Fragment,
                    Path = r.Path,
                    Exclude = r.Exclude,
                    Comment = r.Comment
                };
            }).ToArray();
        }
        
        /// <summary>
        /// A list of app IDs that are associated with the app .
        /// </summary>
        [JsonPropertyName("appIDs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[] AppIds { get; set; }

        /// <summary>
        /// A list of app urls that are associated with the app.
        /// </summary>
        [JsonPropertyName("components")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AppLinkComponentResponse[] Components { get; set; }
    }
}