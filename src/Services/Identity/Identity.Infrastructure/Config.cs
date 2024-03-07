using IdentityServer4;
using IdentityServer4.Models;

namespace Identity.Infrastructure;

public static class Config
{
    /// <summary>
    /// Gets the identity resources..
    /// </summary>
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    /// <summary>
    /// Gets the API scopes..
    /// </summary>
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("MeetSkool", "My API"),
            new ApiScope(name: "read", displayName: "Read your data."),
            new ApiScope(name: "write", displayName: "Write your data."),
            new ApiScope(name: "delete", displayName: "Delete your data."),
        };

    /// <summary>
    /// Gets the Clients.
    /// </summary>
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            // machine to machine client
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GetGrantTypes(),
                AllowedScopes = { IdentityServerConstants.StandardScopes.OfflineAccess, "MeetSkool" },
                AllowOfflineAccess = true,

                // AllowAccessTokensViaBrowser = true,
                // RedirectUris = { "https://notused" },
                // PostLogoutRedirectUris = { "https://notused" },
                // EnableLocalLogin = true,
                RefreshTokenUsage = TokenUsage.ReUse,
                AllowAccessTokensViaBrowser = true,
            },
        };

    /// <summary>
    /// Gets the grant types.
    /// </summary>
    /// <returns>Return grant types.</returns>
    public static List<string> GetGrantTypes()
    {
        List<string> grantTypes = new();
        grantTypes.AddRange(GrantTypes.ResourceOwnerPassword);
        grantTypes.AddRange(GrantTypes.ClientCredentials);
        return grantTypes;
    }

    /// <summary>
    /// The GetClients.
    /// </summary>
    /// <param name="services">The services<see cref="IServiceCollection" />.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>
    /// The <see cref="IEnumerable{Client}" />.
    /// </returns>
    //public static IEnumerable<Client> GetClients(IServiceCollection services, IConfiguration configuration)
    //{
    //    var clients = new List<Client>();
    //    try
    //    {
    //        var dbContext = services.BuildServiceProvider().GetService<IdentityDbContext>();
    //        var dbClients = dbContext.IdentityClients.ToList();

    //        if (dbClients != null && dbClients.Count > 0)
    //        {
    //            foreach (var client in dbClients)
    //            {
    //                var dbClient = new Client
    //                {
    //                    ClientId = client.ClientId,
    //                    ClientSecrets = { new Secret(client.ClientSecret.Sha256()) },
    //                    AllowedGrantTypes = GetGrantTypes(),
    //                    AllowedScopes = { IdentityServerConstants.StandardScopes.OfflineAccess, client.AllowedScope },
    //                    AllowOfflineAccess = true,

    //                    // AllowAccessTokensViaBrowser = true,
    //                    // RedirectUris = { "https://notused" },
    //                    // PostLogoutRedirectUris = { "https://notused" },
    //                    // EnableLocalLogin = true,
    //                    RefreshTokenUsage = TokenUsage.ReUse,
    //                    AllowAccessTokensViaBrowser = true,
    //                    AccessTokenLifetime = int.Parse(configuration["IdentityTokenExpiryTime"]),
    //                };

    //                clients.Add(dbClient);
    //            }
    //        }
    //    }
    //    catch (System.Exception)
    //    {
    //        return clients;
    //    }

    //    return clients;
    //}
}