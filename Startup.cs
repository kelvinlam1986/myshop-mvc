using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using shop.Data;
using shop.Models;
using shop.Repositories;
using shop.Services;
using shop.ViewModels.Category;
using shop.ViewModels.Creditor;
using shop.ViewModels.Customer;
using shop.ViewModels.Home;
using shop.ViewModels.Product;
using shop.ViewModels.SalesTransactionCredit;
using shop.ViewModels.Supplier;

namespace shop
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("MySQLConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ShopContext>()
                .AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
               options.IdleTimeout = TimeSpan.FromMinutes(1));

            services.AddMvc();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITempTransRepository, TempTransRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<ITermRepository, TermRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            // services
            services.AddScoped<ISalesTranService, SalesTranService>();
            services.AddScoped<IPaymentService, PaymentService>();

            // Configure service for AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Branch, IndexAboutDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<Customer, CreditorDTO>().ForMember(x => x.CiDate,
                    opt => opt.MapFrom(src => ((DateTime)src.CiDate).ToString("dd/MM/yyyy")));
                cfg.CreateMap<CreditorApplicationDTO, Customer>().ForMember(x => x.BirthDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.BirthDate, "dd/MM/yyyy", null)));
                cfg.CreateMap<Customer, CreditorApplicationDTO>().ForMember(x => x.BirthDate,
                    opt => opt.MapFrom(src => ((DateTime)src.BirthDate).ToString("dd/MM/yyyy")));
                cfg.CreateMap<NewProductDTO, Product>().ForMember(x => x.Price,
                    opt => opt.MapFrom(src => Convert.ToDecimal(src.Price))).ForMember(x => x.Reorder,
                    opt => opt.MapFrom(src => Convert.ToInt32(src.Reorder)));
                cfg.CreateMap<Product, EditProductDTO>().ForMember(x => x.Price,
                        opt => opt.MapFrom(src => src.Price.ToString("#,###0")))
                    .ForMember(x => x.Reorder,
                        opt => opt.MapFrom(src => src.Reorder.ToString("#,###0")));
                cfg.CreateMap<EditProductDTO, Product>().ForMember(x => x.Price,
                        opt => opt.MapFrom(src => Convert.ToDecimal(src.Price)))
                    .ForMember(x => x.Reorder,
                        opt => opt.MapFrom(src => Convert.ToInt32(src.Reorder)));
                cfg.CreateMap<Supplier, SupplierDTO>();
                cfg.CreateMap<SupplierDTO, Supplier>();
                cfg.CreateMap<Customer, SearchCustomerDTO>();

            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            ShopContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            app.UseIdentity();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DBInitializer.Initialize(context);
        }
    }
}