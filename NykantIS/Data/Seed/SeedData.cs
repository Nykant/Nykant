﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NykantIS.Models;
using Serilog;

namespace NykantIS.Data.Seed
{
    public class SeedData
    {
        public static void EnsureSeedData(IServiceProvider services, IWebHostEnvironment env)
        {
            try
            {
                using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    if (env.IsDevelopment())
                    {
                        var context = scope.ServiceProvider.GetService<LocalIdentityContext>();
                        context.Database.Migrate();
                    }
                    else
                    {
                        var context = scope.ServiceProvider.GetService<IdentityContext>();
                        context.Database.Migrate();
                    }

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    // create admin role
                    var adminRole = roleMgr.FindByNameAsync("Admin").Result;
                    if (adminRole == null)
                    {
                        adminRole = new IdentityRole("Admin");
                        var result = roleMgr.CreateAsync(adminRole).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        //result = roleMgr.AddClaimAsync(adminRole, new Claim("Permission", "admin")).Result;
                        //if (!result.Succeeded)
                        //{
                        //    throw new Exception(result.Errors.First().Description);
                        //}

                        //result = roleMgr.AddClaimAsync(adminRole, new Claim("Permission", "raffle")).Result;
                        //if (!result.Succeeded)
                        //{
                        //    throw new Exception(result.Errors.First().Description);
                        //}
                    }

                    // create raffle role
                    var raffleRole = roleMgr.FindByNameAsync("Raffler").Result;
                    if (raffleRole == null)
                    {
                        raffleRole = new IdentityRole("Raffler");
                        var result = roleMgr.CreateAsync(raffleRole).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        //result = roleMgr.AddClaimAsync(adminRole, new Claim("Permission", "raffle")).Result;
                        //if (!result.Succeeded)
                        //{
                        //    throw new Exception(result.Errors.First().Description);
                        //}
                    }

                    // create admin
                    var admin = userMgr.FindByNameAsync("Admin").Result;
                    if (admin == null)
                    {
                        admin = new ApplicationUser
                        {
                            UserName = "Admin",
                            Email = "Admin@login",
                            EmailConfirmed = true
                        };
                        var result = userMgr.CreateAsync(admin, "MinHemmelighed#123").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddToRoleAsync(admin, adminRole.Name).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(admin, new Claim[]{
                            new Claim(JwtClaimTypes.Id, admin.Id)
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        Log.Debug("admin user created");
                    }
                    else
                    {
                        Log.Debug("admin user exists");
                    }

                    // create raffletester
                    var raffleTester = userMgr.FindByNameAsync("RaffleTester").Result;
                    if (raffleTester == null)
                    {
                        raffleTester = new ApplicationUser
                        {
                            UserName = "RaffleTester",
                            Email = "RaffleTester@login",
                            EmailConfirmed = true
                        };
                        var result = userMgr.CreateAsync(raffleTester, "SecretTestPassword#369").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddToRoleAsync(raffleTester, raffleRole.Name).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(raffleTester, new Claim[]{
                            new Claim(JwtClaimTypes.Id, raffleTester.Id)
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("raffle user created");
                    }
                    else
                    {
                        Log.Debug("raffle user exists");
                    }
                }
            }
            catch (Exception e)
            {
                Log.Debug(e.Message);
            }
        }
    }
}
