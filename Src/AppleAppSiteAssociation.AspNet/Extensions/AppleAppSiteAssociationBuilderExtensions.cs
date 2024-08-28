namespace AppleAppSiteAssociation.AspNet.Extensions
{
    public static class AppleAppSiteAssociationBuilderExtensions
    {
        public static IAppleAppSiteAssociationBuilder AddAppleAppSiteAssociation(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return new AppleAppSiteAssociationBuilder(services);
        }
    }
}