using System;
using System.Linq;
using System.Threading.Tasks;
using AppleAppSiteAssociation.AspNet.Configuration;
using AppleAppSiteAssociation.AspNet.Constants;
using AppleAppSiteAssociation.AspNet.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AppleAppSiteAssociation.AspNet.Middlewares
{
    /// <summary>
    /// Middleware for handling Apple App Site Association requests.
    /// </summary>
    public class AppleAppSiteAssociationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppleAppSiteAssociationMiddleware> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="AppleAppSiteAssociationMiddleware"/>.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public AppleAppSiteAssociationMiddleware(RequestDelegate next, ILogger<AppleAppSiteAssociationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the middleware.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        public async Task InvokeAsync(HttpContext context, AppleAppSiteAssociationOptions options)
        {
            if (context.Request.Path.Equals(UrlPaths.AppleAppSiteAssociation, StringComparison.OrdinalIgnoreCase) == false)
            {
                await _next(context);
                return;
            }

            _logger.LogDebug("Handling Apple App Site Association request.");

            if (options == null)
            {
                _logger.LogWarning("Apple App Site Association options are not configured. Returning 404.");
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
        
            CreateCachedResponseHeaders(context.Response, options.CacheDuration);

            AppleAppSiteAssociationResponse appleAppSiteAssociationResponse = new()
            {
                AppLinks = CreateAppLinkResponse(options),
                WebCredentials = CreateWebCredentialResponse(options),
                AppClips = CreateAppClipResponse(options)
            };
        
            await context.Response.WriteAsJsonAsync(appleAppSiteAssociationResponse);
        }

        private AppLinkResponse CreateAppLinkResponse(AppleAppSiteAssociationOptions options)
        {
            if (options.AppLinks == null)
            {
                return null;
            }

            if (options.AppLinks.Count == 0)
            {
                return null;
            }

            return new AppLinkResponse
            {
                AppLinkDetails = options.AppLinks.Select(p => new AppLinkDetailItemResponse(p))
            };
        }

        private AppClipResponse CreateAppClipResponse(AppleAppSiteAssociationOptions options)
        {
            if (options.AppClips == null)
            {
                return null;
            }
            
            if (options.AppClips.Length == 0)
            {
                return null;
            }

            return new AppClipResponse
            {
                AppIds = options.AppClips
            };
        }

        private static WebCredentialResponse CreateWebCredentialResponse(AppleAppSiteAssociationOptions options)
        {
            if (options.WebCredentials == null)
            {
                return null;
            }
            
            if (options.WebCredentials.Length == 0)
            {
                return null;
            }

            return new WebCredentialResponse
            {
                AppIds = options.WebCredentials
            };
        }

        private void CreateCachedResponseHeaders(HttpResponse contextResponse, TimeSpan cacheDuration)
        {
            if (cacheDuration.TotalSeconds <= 1)
            {
                return;
            }

            if (contextResponse.Headers.ContainsKey("Cache-Control"))
            {
                return;
            }

            contextResponse.Headers["Cache-Control"] = $"public, max-age={(int)cacheDuration.TotalSeconds}";
        }
    }
}