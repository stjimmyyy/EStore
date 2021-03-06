namespace E_Store
{
    using Business.Interfaces;
    using Business.Managers;
    using Data.Interfaces.Repositories;
    using Data.Infrastructure.Extensions;
    using E_Store.Business.Classes;
    using Extensions;
    using E_Store.Data.Data;
    using E_Store.Data.Models;
    
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
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

            services.AddDbContext<EStoreDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    .UseLazyLoadingProxies()
                    .ConfigureWarnings(x => 
                        x.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning)));
            
            services.AddDatabaseDeveloperPageExceptionFilter();
            

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireDigit = true;
                    options.Password.RequireUppercase = true;
                })
                .AddEntityFrameworkStores<EStoreDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReadOnlyRepository, ReadOnlyRepository>();
            services.AddScoped<IAccountingSettingRepository, AccountingSettingRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonDetailRepository, PersonDetailRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<IEOrderRepository, EOrderRepository>();
            services.AddScoped<IProductEOrderRepository, ProductEOrderRepository>();

            services.AddScoped<IEmailSender, EmailSender>();
            
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IReadOnlyManager, ReadOnlyManager>();
            services.AddScoped<IPersonManager, PersonManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IAccountingSettingManager, AccountingSettingManager>();

            services.AddSingleton(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());


            services.AddAutoMapper(typeof(Startup));
            
            services.AddImageProcessing();
            
            services.AddMvc(options =>
            {
                options.Filters.Add<Classes.ExceptionsToMessageFilterAttribute>();
            });

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "ProductDetail",
                    pattern: "Products/{url}",
                    defaults: new {controller = "Product", action = "Detail", url = ""});
                
                endpoints.MapRazorPages();
            });
        }
    }
}