namespace E_Store.Data.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    
    using Data;
    using Models;
    
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    
    
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;
            
            MigrateDatabase(services);
            SeedCategories(services);

            return app;
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<EStoreDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<EStoreDbContext>();

            if (data.Categories.Any())
            {
                return;
            }
            
            data.Categories.AddRange(new []
            {
                new Category() { Title = "Living room", Url = "living-room", OrderNo = 1, Hidden = false },
                new Category() { Title = "Kitchens", Url = "kitchens", OrderNo = 4, Hidden = false },
                new Category() { ParentCategoryId = 1, Title = "Curtains", Url = "curtains", OrderNo = 2, Hidden = false },
                new Category() { ParentCategoryId = 1, Title = "Flowerpots", Url = "flowerpots", OrderNo = 3, Hidden = false },
                new Category() { ParentCategoryId = 2, Title = "Dishes", Url = "dishes", OrderNo = 5, Hidden = false },
                new Category() { ParentCategoryId = 2, Title = "Kitchen cupboards", Url = "kitchen-cupboards", OrderNo = 6, Hidden = false }
            });

            data.SaveChanges();
        }
    }
}