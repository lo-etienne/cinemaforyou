using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaForYou.Models;

namespace CinemaForYou.Data
{
    public static class DataInitializer
    {

        public static async Task SeedData(RoleManager<IdentityRole> roleManager, UserManager<Member> userManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }


        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Manager"))
            {
                IdentityRole admin = new IdentityRole()
                {
                    Name = "Manager"
                };

                var result = roleManager.CreateAsync(admin).Result;
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                IdentityRole admin = new IdentityRole()
                {
                    Name = "User"
                };

                var result = roleManager.CreateAsync(admin).Result;
            }
        }

        public static async Task SeedUsers(UserManager<Member> userManager)
        {
            if (userManager.FindByNameAsync("peterjackson@c4y.com").Result == null)
            {
                Member admin = new Member()
                {
                    Name = "Jackson",
                    Surname = "Peter",
                    Email = "peterjackson@c4y.com",
                    UserName = "peterjackson@c4y.com",
                    Birthdate = new DateTime(1961,10,31)

                };

                var adminResult = await userManager.CreateAsync(admin, "Lotr1!");

                if (adminResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Manager");
                }

                Member user1 = new Member()
                {
                    Name = "Etienne",
                    Surname = "Loic",
                    Email = "etienneloic@gmail.com",
                    UserName = "etienneloic@gmail.com",
                    Birthdate = new DateTime(1996,9,22)
                };

                var userResult = await userManager.CreateAsync(user1, "Loic123/");

                if (userResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "User");
                }

                Member user2 = new Member()
                {
                    Name = "Fillon",
                    Surname = "Justine",
                    Email = "fillonjustine@gmail.com",
                    UserName = "fillonjustine@gmail.com",
                    Birthdate = new DateTime(1995,10,17)
                };

                userResult = await userManager.CreateAsync(user2, "Justine123/");

                if (userResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user2, "User");
                }

                Member user3 = new Member()
                {
                    Name = "Etienne",
                    Surname = "Mathys",
                    Email = "etiennemathys@gmail.com",
                    UserName = "etiennemathys@gmail.com",
                    Birthdate = new DateTime(2015,12,10)
                };

                userResult = await userManager.CreateAsync(user3, "Mathys123/");

                if (userResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user3, "User");
                }

            }
        }
    }

}
