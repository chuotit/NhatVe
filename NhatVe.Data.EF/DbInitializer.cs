using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhatVe.Data.Entities;
using NhatVe.Data.Enums;
using NhatVe.Utilities.Constants;

namespace NhatVe.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active
                }, "123@12345");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            if (_context.AirPorts.Count() == 0)
            {
                List<AirPort> listColor = new List<AirPort>()
                {
                    new AirPort() {
                        Name= "Tân Sơn Nhất",
                        Id= "SGN",
                        Lat= 10.818797,
                        Lng= 106.651856,
                        City= "TP Hồ Chí Minh",
                        ShortName= "TP.HCM",
                        Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/SGN"
                    },
                };
                _context.AirPorts.AddRange(listColor);
            }
        }
    }
}