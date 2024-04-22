using Microsoft.EntityFrameworkCore;
using MvcBasics.Models;

namespace MvcBasics.Data;

public class UserSeed
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        string adminUserEmail = "teddysmithdeveloper@gmail.com";
        string appUserEmail = "user@etickets.com";


        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                UserName = "teddysmithdev",
                Email = adminUserEmail,
                EmailConfirmed = true,
                AddressId = 1
            },
            new User()
            {
                Id = 2,
                UserName = "app-user",
                Email = appUserEmail,
                EmailConfirmed = true,
                AddressId = 2
            }
            );
        }
    }

    //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
    //{
    //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
    //    {
    //        //Roles
    //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin.ToString()))
    //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin.ToString()));
    //        if (!await roleManager.RoleExistsAsync(UserRoles.User.ToString()))
    //            await roleManager.CreateAsync(new Microsoft.AspNetCore.Identity.IdentityRole(UserRoles.User.ToString()));

    //        //Users
    //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
    //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

    //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
    //        if (adminUser == null)
    //        {
    //            var newAdminUser = new User()
    //            {
    //                UserName = "teddysmithdev",
    //                Email = adminUserEmail,
    //                EmailConfirmed = true,
    //                Address = new Address()
    //                {
    //                    Street = "123 Main St",
    //                    City = "Charlotte",
    //                    State = "NC"
    //                }
    //            };
    //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
    //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.User.ToString());
    //        }

    //        string appUserEmail = "user@etickets.com";

    //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
    //        if (appUser == null)
    //        {
    //            var newAppUser = new User()
    //            {
    //                UserName = "app-user",
    //                Email = appUserEmail,
    //                EmailConfirmed = true,
    //                Address = new Address()
    //                {
    //                    Street = "123 Main St",
    //                    City = "Charlotte",
    //                    State = "NC"
    //                }
    //            };
    //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
    //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User.ToString());
    //        }
    //    }