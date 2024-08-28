using Microsoft.Extensions.DependencyInjection;

namespace AppleAppSiteAssociation.AspNet.Builders
{
    /// <summary>
    /// A builder for configuring Apple App Site Association services.
    /// </summary>
    public interface IAppleAppSiteAssociationBuilder
    {
    
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where Apple App Site Association services are configured.
        /// </summary>
        IServiceCollection Services { get; }
    }
}