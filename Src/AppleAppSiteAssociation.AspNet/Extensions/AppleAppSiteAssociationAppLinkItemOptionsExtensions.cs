using System.Collections.Generic;
using AppleAppSiteAssociation.AspNet.Configuration;

namespace AppleAppSiteAssociation.AspNet.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class AppleAppSiteAssociationAppLinkItemOptionsExtensions
    {
        /// <summary>
        /// Creates a new instance of <see cref="AppleAppSiteAssociationAppLinkItemOptions"/>.
        /// </summary>
        /// <param name="appLinks"></param>
        /// <param name="appIds"></param>
        /// <param name="components"></param>
        /// <returns></returns>
        public static List<AppleAppSiteAssociationAppLinkItemOptions> AddAppLink(this List<AppleAppSiteAssociationAppLinkItemOptions> appLinks, string[] appIds, List<AppleAppSiteAssociationAppLinkComponentOptions> components)
        {
            if (appLinks == null)
            {
                appLinks = new List<AppleAppSiteAssociationAppLinkItemOptions>();
            }
            
            appLinks.Add(new AppleAppSiteAssociationAppLinkItemOptions
            {
                AppIds = appIds,
                Components = components.ToArray()
            });

            return appLinks;
        }

        /// <summary>
        /// Creates a new instance of <see cref="AppleAppSiteAssociationAppLinkItemOptions"/>.
        /// </summary>
        /// <param name="appLinks"></param>
        /// <param name="appIds"></param>
        /// <param name="components"></param>
        /// <returns></returns>
        public static List<AppleAppSiteAssociationAppLinkItemOptions> AddAppLink(this List<AppleAppSiteAssociationAppLinkItemOptions> appLinks, string[] appIds, params AppleAppSiteAssociationAppLinkComponentOptions[] components)
        {
            if (appLinks == null)
            {
                appLinks = new List<AppleAppSiteAssociationAppLinkItemOptions>();
            }
            
            appLinks.Add(new AppleAppSiteAssociationAppLinkItemOptions
            {
                AppIds = appIds,
                Components = components
            });

            return appLinks;
        }
    }
}