using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace OnlineCourse.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("resource_catalog"){Scopes = {"catalog_fullpermission"}},
        new ApiResource("photo_stock_catalog"){Scopes = {"photo_stock_fullpermission"}},
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };


    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("catalog_fullpermission","Catalog API icin full erisim"),
            new ApiScope("photo_stock_fullpermission","Photo Stock API icin full erisim"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientName = "Asp.Net Core MVC",
                ClientId = "WebMvcClient",
                ClientSecrets = {new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "catalog_fullpermission", "photo_stock_fullpermission", IdentityServerConstants.LocalApi.ScopeName }
            }
        };
}
