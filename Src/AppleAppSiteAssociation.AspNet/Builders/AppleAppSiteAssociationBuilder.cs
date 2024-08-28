using System;
using Microsoft.Extensions.DependencyInjection;

namespace AppleAppSiteAssociation.AspNet.Builders
{
    /// <summary>
    /// A builder for configuring Apple App Site Association services.
    /// </summary>
    public class AppleAppSiteAssociationBuilder : IAppleAppSiteAssociationBuilder
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AppleAppSiteAssociationBuilder"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AppleAppSiteAssociationBuilder(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            Services = services;
        }
        
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where Apple App Site Association services are configured.
        /// </summary>
        public IServiceCollection Services { get; }
    }
}