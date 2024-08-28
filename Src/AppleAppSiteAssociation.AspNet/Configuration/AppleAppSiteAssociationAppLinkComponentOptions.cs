namespace AppleAppSiteAssociation.AspNet.Configuration;

/// <summary>
/// 
/// </summary>
public class AppleAppSiteAssociationAppLinkComponentOptions
{
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
    public string Query { get; set; }

    /// <summary>
    /// Comment for the app link.
    /// </summary>
    public string Comment { get; set; }
        
    /// <summary>
    /// Exclude the app link.
    /// </summary>
    public bool Exclude { get; set; }
}