using UI.Components;
using Logto.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddLogtoAuthentication(options =>
            {
                options.Endpoint = "PUT ENDPOINT HERE";
                options.AppId = "PUT APPID HERE";
                options.AppSecret = "PUT APPSECRET HERE";
                // Fill the fields
            });

            builder.Services.AddCascadingAuthenticationState();

            var app = builder.Build();

            app.UseAuthentication();

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.MapGet("/SignIn", async context =>
            {
                if (!(context.User?.Identity?.IsAuthenticated ?? false))
                {
                    await context.ChallengeAsync(new AuthenticationProperties { RedirectUri = "/" });
                }
                else
                {
                    context.Response.Redirect("/");
                }
            });

            app.MapGet("/SignOut", async context =>
            {
                if (context.User?.Identity?.IsAuthenticated ?? false)
                {
                    await context.SignOutAsync(new AuthenticationProperties { RedirectUri = "/" });
                }
                else
                {
                    context.Response.Redirect("/");
                }
            });

            app.Run();
        }
    }
}
