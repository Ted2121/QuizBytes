using Microsoft.AspNetCore.Authentication.Cookies;
using QuizBytesWebsite.Helpers;
using QuizBytesWebsite.Hubs;
using WebApiClient;

namespace QuizBytesWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<ITimerLogicHelper, TimerLogicHelper>();
            builder.Services.AddScoped<ILeaderboardBuilder, LeaderboardBuilder>();
            builder.Services.AddScoped<IWebUserFacadeApiClient>((conf) => new WebUserFacadeApiClient(configuration["WebApiURI"]));
            builder.Services.AddScoped<ICourseFacadeApiClient>((conf) => new CourseFacadeApiClient(configuration["WebApiURI"]));
            builder.Services.AddScoped<IChallengeFacadeApiClient>((conf) => new ChallengeFacadeApiClient(configuration["WebApiURI"]));
            builder.Services.AddSignalR();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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
            //MvcOptions.EnableEndpointRouting = false;

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

           



            app.MapHub<TimerHub>("/timerHub");

            app.Run();
        }
    }
}