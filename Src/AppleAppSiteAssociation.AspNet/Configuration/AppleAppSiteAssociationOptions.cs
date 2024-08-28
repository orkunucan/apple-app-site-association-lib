using System;
using System.Collections.Generic;

namespace AppleAppSiteAssociation.AspNet.Configuration
{
    /// <summary>
    /// Options for configuring Apple App Site Association services.
    /// </summary>
    public class AppleAppSiteAssociationOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AppleAppSiteAssociationOptions"/>. 
        /// </summary>
        public AppleAppSiteAssociationOptions()
        {
            CacheDuration = TimeSpan.FromMinutes(1);
            AppLinks = new List<AppleAppSiteAssociationAppLinkItemOptions>();
        }
        
        /// <summary>
        /// Cache duration for the Apple App Site Association file.
        /// </summary>
        public TimeSpan CacheDuration { get; set; }

        /// <summary>
        /// A list of app links that are associated with the app.
        /// </summary>
        public List<AppleAppSiteAssociationAppLinkItemOptions> AppLinks { get; }
        
        /// <summary>
        /// A list of app IDs that are associated with the web credentials.
        /// </summary>
        public string[] WebCredentials { get; set; }

        /// <summary>
        /// A list of app IDs that are associated with the app clip.
        /// </summary>
        public string[] AppClips { get; set; }
    }

    /// <summary>
    /// Options for configuring Apple App Site Association app link items.
    /// </summary>
    public class AppleAppSiteAssociationAppLinkItemOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] AppIds { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public AppleAppSiteAssociationAppLinkComponentOptions[] Components { get; set; }
    }
}