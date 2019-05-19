using IdentityServer4;
using Microsoft.Extensions.DependencyInjection;

namespace Chatter.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterIdentityServer(this IServiceCollection services)
        {
            services.AddIdentityServer();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                options.SignOutScheme = IdentityServerConstants.SignoutScheme;

                options.Authority = "https://localhost:44331/";
                options.RequireHttpsMetadata = false;
                
                options.ClientId = "Chatter.App";
                options.ResponseType = "id_token";
                options.SaveTokens = true;
            });
        }
    }
}
