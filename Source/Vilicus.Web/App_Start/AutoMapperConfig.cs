
using AutoMapper;
using Vilicus.Web.AutoMapperProfiles;

/// <summary>
/// AutoMapperConfig
/// https://github.com/AutoMapper/AutoMapper/wiki/Configuration
/// </summary>
public static class AutoMapperConfig
{
    /// <summary>
    /// Configure Automapper by adding profiles
    /// </summary>
    public static void Configure()
    {
        Mapper.Initialize(config =>
        {
            // Add profiles here - profiles can be per controller or whatever organization is preferred
            config.AddProfile(new GeneralProfile());
        });
    }
}
