using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using MovieAspCore.Domain;
using MovieAspCore.Service;
using MovieAspCore.Domain.Repository.Abstract;
using MovieAspCore.Domain.Repository.EntityFramework;
using NLog;


namespace MovieAspCore
{
    public class Startup
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //���������� ������ ���������� ���������� � �������� ��������
            services.AddTransient<IMovieItemsReposit, EFMovieItemsReposit>();
            services.AddTransient<IMenuFieldsReposit, EFMenuFieldsReposit>();
            services.AddTransient<General>();

            //���������� �������� ��
            services.AddDbContext<MovieContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //����������� identity �������
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                //opts.User.RequireUniqueEmail = true;
                //opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<MovieContext>().AddDefaultTokenProviders();

            //����������� authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myMovieAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //����������� �������� ����������� ��� Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //��������� ������� ��� ������������ � ������������� (MVC)
            services.AddControllersWithViews(x =>
            {
                 x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //���������� ������������� � asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}

            //���������� ��������� ��������� ������ � ���������� (css, js � �.�.)
            app.UseStaticFiles();

            //���������� ������� �������������
            app.UseRouting();

            //���������� �������������� � �����������
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
                       
            //������������� ������ ��� ��������(���������)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //����������� ��������� �������
            app.UseStatusCodePages(async context =>
            {
                var request = context.HttpContext.Request;
                var response = context.HttpContext.Response;
                response.ContentType = "text/plain; charset=utf-8";
                string pathCut = request.Path;
                if ((response.StatusCode == 404) && (!pathCut.StartsWith("/sass/fon")) && (!pathCut.StartsWith("/favicon.")))
                {
                    logger.Error($" ���� {request.Path}, ��� ������ {response.StatusCode}");
                    await response.WriteAsync($"Err: ��� {response.StatusCode}, �������� �� �������, ���� {request.Path}");
                }
            });

            //app.UseStatusCodePagesWithReExecute("/error", "?code={0}");
            //app.UseStatusCodePagesWithRedirects("/error?code={0}");

            //app.Map("/error", ap => ap.Run(async context =>
            //{
            //    logger.Error($" ���� {context.Request.Path}, ��������� ������� {context.Request.Query} ��� ������ {context.Request.Query["code"]}");
            //    context.Response.ContentType = "text/plain; charset=utf-8";
            //    await context.Response.WriteAsync($"Err: ��� {context.Request.Query["code"]} �������� �� ������ ���� {context.Request.Path} �� �������");
            //}));

        }
    }
}
