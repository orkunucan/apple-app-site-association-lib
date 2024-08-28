using System.Collections.Generic;

namespace AppleAppSiteAssociation.AspNet.Responses;

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
        Query = new Dictionary<string, object>();
    }
        
    /// <summary>
    /// # Fragment identifier
    /// </summary>
    public string Fragment { get; set; }
        
    /// <summary>
    /// / Path to content
    /// </summary>
    public string Path { get; set; }
        
    /// <summary>
    /// ? Query parameters
    /// </summary>
    public Dictionary<string, object> Query { get; set; }

    /// <summary>
    /// Comment for the app link.
    /// </summary>
    public string Comment { get; set; }
        
    /// <summary>
    /// Exclude the app link.
    /// </summary>
    public bool Exclude { get; set; }
}