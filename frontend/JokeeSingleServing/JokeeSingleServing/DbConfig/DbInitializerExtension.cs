using JokeeSingleServing.Models;

namespace JokeeSingleServing.DbConfig
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeedSqlLite(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<JokeContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
}
