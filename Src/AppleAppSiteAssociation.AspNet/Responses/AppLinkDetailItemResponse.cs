using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppleAppSiteAssociation.AspNet.Responses;

/// <summary>
/// Represents the response for the Apple App Site Association file.
/// </summary>
public class AppLinkDetailItemResponse
{
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
    public Dictionary<string, string>[] Components { get; set; }
}