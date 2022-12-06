using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace David.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()

        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope()
                {
                    //Name = "Prof Oaks Kanto Pokedex",
                    //ClientId = "profOaksKantoPokedexClient",
                    //AllowedGrantTypes = GrantTypes.Code,
                    //RedirectUris =
                    //{
                    //    "https://localhost:7041/signin-oidc"
                    //},
                    //AllowedScopes =
                    //{
                    //    IdentityServerConstants.StandardScopes.OpenId,
                    //    IdentityServerConstants.StandardScopes.Profile
                    //},
                    //ClientSecrets =
                    //{
                    //    new Secret("secret".Sha256())
                    //}
                }

            };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            { 
                new Client()
                {
                    //ClientName = "Prof Oaks Kanto Pokedex",
                    //ClientId = "profOaksKantoPokedexClient",
                    //AllowedGrantTypes = GrantTypes.Code,
                    //RedirectUris =
                    //{
                    //    "https://localhost:7041/signin-oidc"
                    //},
                    //AllowedScopes =
                    //{
                    //    IdentityServerConstants.StandardScopes.OpenId,
                    //    IdentityServerConstants.StandardScopes.Profile
                    //},
                    //ClientSecrets =
                    //{
                    //    new Secret("secret".Sha256())
                    //}
                }
            };
}