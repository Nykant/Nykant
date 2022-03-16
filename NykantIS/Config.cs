using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace NykantIS
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Email(),
                        new IdentityResources.Profile(),
                        new IdentityResource
                        {
                            Name = "roles",
                            DisplayName = "Roles",
                            UserClaims = { JwtClaimTypes.Role }
                        }
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("NykantAPI", "Nykant API", new [] { JwtClaimTypes.Role })
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    
                    ClientSecrets = { new Secret("Veryser1Iouscl3Ient5secr44ett5hatnoknowsS".Sha256()) },

                    AllowedScopes = { "NykantAPI" }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("Ver123XXXyser1Ious3m1v2C5secr44ett5hatnOknowsS".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    UpdateAccessTokenClaimsOnRefresh = true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "NykantAPI"
                    }
                }
            };
    }
}
