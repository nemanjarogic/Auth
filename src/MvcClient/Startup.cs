using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;

namespace MvcClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services
               .AddAuthentication(options =>
               {
                    // We are using a cookie to locally sign-in the user
                    options.DefaultScheme = "Cookies";

                    // When we need the user to login, we will be using the OpenID Connect protocol
                    options.DefaultChallengeScheme = "oidc";
               })
               // Add the handler that can process cookies.
               .AddCookie("Cookies")
                // Configure the handler that performs the OpenID Connect protocol
               .AddOpenIdConnect("oidc", options =>
                {
                    // Where the trusted token service (identity server) is located.
                    options.Authority = "https://localhost:5001";

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    // Even though we’ve configured the client to be allowed to retrieve the profile identity scope (IdentityServer->Config.cs),
                    // the claims associated with that scope (such as name, family_name, website etc.) don’t appear by default in the returned token.
                    options.Scope.Add("profile");
                    options.Scope.Add("favoriteProgrammingLanguage");
                    options.GetClaimsFromUserInfoEndpoint = true;

                    // Map non-standard claim between the claim appearing in JSON and the user claim
                    options.ClaimActions.MapUniqueJsonKey("favoriteProgrammingLanguage", "favoriteProgrammingLanguage");

                    // Persist the tokens from IdentityServer in the cookie
                    options.SaveTokens = true;

                    // Since SaveTokens is enabled, ASP.NET Core will automatically store the resulting ID, access and refresh token in the authentication session.
                    // Identity resources related with ID token are profile, favoriteProgrammingLanguage etc.
                    // Identity resources related with access token are api1 - scope to the API
                    options.Scope.Add("api1");
                    options.Scope.Add("offline_access");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // RequireAuthorization disables anonymous access for the entire application.
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });
        }
    }
}
