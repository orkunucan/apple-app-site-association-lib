# AppleAppSiteAssociation
A implementation library + demo for [Apple App Site Association](https://developer.apple.com/documentation/xcode/supporting-associated-domains) using [.NET](https://dotnet.microsoft.com/)

### Usage

```Install-Package AppleAppSiteAssociation.AspNet```

```csharp
// Add Apple App Site Association services
builder.Services.AddAppleAppSiteAssociation(cfg =>
{
    cfg.AppLinks.AddAppLink(
    [
        "ABCDE12345.com.example.app",
        "ABCDE12345.com.example.app.dev"
    ], new AppleAppSiteAssociationAppLinkComponentOptions
    {
        Fragment = "no_universal_links",
        Exclude = true,
        Comment = "Matches any URL whose fragment equals no_universal_links and instructs the system not to open it as a universal link"
    });
    
    // OR

    List<AppleAppSiteAssociationAppLinkComponentOptions> components = new()
    {
        new AppleAppSiteAssociationAppLinkComponentOptions
        {
            Path = "/buy/*",
            Comment = "Matches any URL with a path that starts with /buy/."
        },
        new AppleAppSiteAssociationAppLinkComponentOptions
        {
            Path = "/help/website/*",
            Exclude = true,
            Comment = "Matches any URL with a path that starts with /help/website/ and instructs the system not to open it as a universal link."
        },
        new AppleAppSiteAssociationAppLinkComponentOptions
        {
            Path = "/help/*",
            Query = { { "articleNumber", "?????" } },
            Comment = "Matches any URL with a path that starts with /help/ and also contains the query parameter articleNumber."
        }
    };
    
    cfg.AppLinks.AddAppLink(
        new[]
        {
            "ABCDE12345.com.example.app",
            "ABCDE12345.com.example.app.dev"
        }, components);
    
    // Optional: Set the web credentials
    cfg.WebCredentials = ["ABCDE12345.com.example.app", "ABCDE12345.com.example.app.dev"];
    
    // Optional: Set the app clip IDs
    cfg.AppClips = ["ABCDE12345.com.example.app.Clip", "ABCDE12345.com.example.app.Clip.dev"];
    
    // Optional: Set the cache duration for the Apple App Site Association file
    cfg.CacheDuration = TimeSpan.FromDays(1);
});
```

```csharp
// Add the middleware to the pipeline
app.UseAppleAppSiteAssociation();
```

Apple App Site Association file will be available at `/.well-known/apple-app-site-association`
```json
{
    "applinks": {
        "details": [
            {
                "appIDs": [
                    "ABCDE12345.com.example.app",
                    "ABCDE12345.com.example.app.dev"
                ],
                "components": [
                    {
                        "#": "no_universal_links",
                        "?": {},
                        "comment": "Matches any URL whose fragment equals no_universal_links and instructs the system not to open it as a universal link",
                        "exclude": true
                    }
                ]
            },
            {
                "appIDs": [
                    "ABCDE12345.com.example.app",
                    "ABCDE12345.com.example.app.dev"
                ],
                "components": [
                    {
                        "/": "/buy/*",
                        "?": {},
                        "comment": "Matches any URL with a path that starts with /buy/."
                    },
                    {
                        "/": "/help/website/*",
                        "?": {},
                        "comment": "Matches any URL with a path that starts with /help/website/ and instructs the system not to open it as a universal link.",
                        "exclude": true
                    },
                    {
                        "/": "/help/*",
                        "?": {
                            "articleNumber": "?????"
                        },
                        "comment": "Matches any URL with a path that starts with /help/ and also contains the query parameter articleNumber."
                    }
                ]
            }
        ]
    },
    "webcredentials": {
        "apps": [
            "ABCDE12345.com.example.app",
            "ABCDE12345.com.example.app.dev"
        ]
    },
    "appclips": {
        "apps": [
            "ABCDE12345.com.example.app.Clip",
            "ABCDE12345.com.example.app.Clip.dev"
        ]
    }
}
```
