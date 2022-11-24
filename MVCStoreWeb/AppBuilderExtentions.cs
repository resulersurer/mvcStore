using Microsoft.EntityFrameworkCore;
using MVCStoreData;


namespace MVCStoreWeb
{
    public static class AppBuilderExtentions
    {
        public static IApplicationBuilder UseMVCStore(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            return builder;
        }
    }
}
