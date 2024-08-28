using System;
using System.Collections.Generic;
using AppleAppSiteAssociation.AspNet.Configuration;
using AppleAppSiteAssociation.AspNet.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Add the middleware to the pipeline
app.UseAppleAppSiteAssociation();

app.MapControllers();

app.Run();