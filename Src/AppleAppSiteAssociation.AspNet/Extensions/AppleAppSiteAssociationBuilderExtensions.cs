using System;
using AppleAppSiteAssociation.AspNet.Builders;
using AppleAppSiteAssociation.AspNet.Configuration;
using AppleAppSiteAssociation.AspNet.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AppleAppSiteAssociation.AspNet.Extensions
{
    /// <summary>
    /// Extension methods for configuring Apple App Site Association services.
    /// </summary>
    public static class AppleAppSiteAssociationBuilderExtensions
    {
        /// <summary>
        /// Adds Apple App Site Association services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IAppleAppSiteAssociationBuilder AddAppleAppSiteAssociation(this IServiceCollection services, Action<AppleAppSiteAssociationOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
         
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }
            
            services.Configure(setupAction);

            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AppleAppSiteAssociationOptions>>().Value);
            
            return new AppleAppSiteAssociationBuilder(services);
        }
        
        /// <summary>
        /// Adds Apple App Site Association services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="app"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void UseAppleAppSiteAssociation(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            
            app.UseMiddleware<AppleAppSiteAssociationMiddleware>();
        }
    }
}