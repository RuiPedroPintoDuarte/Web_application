using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class SeedRoles
    {
        public static void Seed(RoleManager<IdentityRole> roleManager)
        {
            if(roleManager.Roles.Any()==false)
            {
                roleManager.CreateAsync(new IdentityRole("Cliente")).Wait();
                roleManager.CreateAsync(new IdentityRole("Funcionário")).Wait();
                roleManager.CreateAsync(new IdentityRole("Administrador")).Wait();
            }
        }
    }
}
