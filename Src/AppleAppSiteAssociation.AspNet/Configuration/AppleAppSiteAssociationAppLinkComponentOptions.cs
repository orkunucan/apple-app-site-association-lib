using System.Collections.Generic;

namespace AppleAppSiteAssociation.AspNet.Configuration
{
    /// <summary>
    /// Options for configuring Apple App Site Association app link components.
    /// </summary>
    public class AppleAppSiteAssociationAppLinkComponentOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AppleAppSiteAssociationAppLinkComponentOptions"/>.
        /// </summary>
        public AppleAppSiteAssociationAppLinkComponentOptions()
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
        public bool? Exclude { get; set; }
    }
}