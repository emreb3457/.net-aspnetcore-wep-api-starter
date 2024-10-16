using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Service
{
    public static class DbContextSeed
    {
        public static async Task SeedRolesAndAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminEmail = configuration["AdminUser:Email"];
            var adminPassword = configuration["AdminUser:Password"];

            var adminUser = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                // FirstName = configuration["AdminUser:FirstName"],
                // LastName = configuration["AdminUser:LastName"],
                EmailConfirmed = true
            };

            if (await userManager.FindByEmailAsync(adminUser.Email!) == null)
            {
                var createPowerUser = await userManager.CreateAsync(adminUser, adminPassword!);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}