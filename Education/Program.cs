using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using EducationModel;
using Microsoft.EntityFrameworkCore;
 
 
    var builder = WebApplication.CreateBuilder(args);
    //builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

         // Add services to the container.

        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddIdentity<User, IdentityRole>
           ().AddEntityFrameworkStores<Context>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.MapControllerRoute("main", "{controller=Home}/{action=Index}/{id?}");
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();

        app.Run();

        return 0;
    
 
