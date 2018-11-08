using Microsoft.AspNetCore.Identity;
using NhatVe.Data.Entities;
using NhatVe.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                List<AirPort> AirPort = new List<AirPort>()
                {
                    new AirPort() { Name= "Tân Sơn Nhất", Id= "SGN", Lat= 10.818797, Lng= 106.651856, City= "TP Hồ Chí Minh", ShortName= "TP.HCM", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/SGN" },
                    new AirPort() { Name= "Nội Bài", Id= "HAN", Lat= 21.221192, Lng= 105.807178, City= "Hà Nội", ShortName= "Hà Nội", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/HAN" },
                    new AirPort() { Name= "Đà nẵng", Id= "DAD", Lat= 16.043917, Lng= 108.19937, City= "Đà nẵng", ShortName= "Đ.Nẵng", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/DAD" },
                    new AirPort() { Name= "Cam Ranh", Id= "CXR", Lat= 11.998153, Lng= 109.219372, City= "Nha Trang", ShortName= "N.Trang", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/CXR" },
                    new AirPort() { Name= "Vinh", Id= "VII", Lat= 18.737569, Lng= 105.670764, City= "Vinh", ShortName= "Vinh", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/VII" },
                    new AirPort() { Name= "Cát Bi", Id= "HPH", Lat= 20.819386, Lng= 106.724989, City= "Hải Phòng", ShortName= "H.Phòng", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/HPH" },
                    new AirPort() { Name= "Phú Quốc", Id= "PQC", Lat= 10.227025, Lng= 103.967169, City= "Phú Quốc", ShortName= "Ph.Quốc", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/PQC" },
                    new AirPort() { Name= "Đồng Hới", Id= "VDH", Lat= 17.515, Lng= 106.590556, City= "Đồng Hới", ShortName= "Đồng Hới", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/VDH" },
                    new AirPort() { Name= "Liên Khương", Id= "DLI", Lat= 11.75, Lng= 108.367, City= "Đà Lạt", ShortName= "Đà Lạt", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/DLI" },
                    new AirPort() { Name= "Côn Đảo", Id= "VCS", Lat= 8.731831, Lng= 106.632589, City= "Côn Đảo", ShortName= "Côn Đảo", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/VCS" },
                    new AirPort() { Name= "Chu Lai", Id= "VCL", Lat= 15.405944, Lng= 108.705889, City= "Chu Lai", ShortName= "Chu Lai", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/VCL" },
                    new AirPort() { Name= "Pleiku", Id= "PXU", Lat= 14.004522, Lng= 108.017158, City= "Pleiku", ShortName= "Pleiku", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/PXU" },
                    new AirPort() { Name= "Cần Thơ", Id= "VCA", Lat= 10.085119, Lng= 105.711922, City= "Cần Thơ", ShortName= "Cần Thơ", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/VCA" },
                    new AirPort() { Name= "Cà Mau", Id= "CAH", Lat= 9.188049, Lng= 105.174721, City= "Cà Mau", ShortName= "Cà Mau", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/CAH" },
                    new AirPort() { Name= "Phú Bài", Id= "HUI", Lat= 16.401499, Lng= 107.702614, City= "Huế", ShortName= "Huế", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/HUI" },
                    new AirPort() { Name= "Phù Cát", Id= "UIH", Lat= 13.954986, Lng= 109.042267, City= "Phù Cát", ShortName= "Qui Nhơn", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/UIH" },
                    new AirPort() { Name= "Rạch Giá", Id= "VKG", Lat= 9.949676, Lng= 105.133659, City= "Kiên Giang", ShortName= "Rạch Giá", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/VKG" },
                    new AirPort() { Name= "Thọ Xuân", Id= "THD", Lat= 19, Lng= 105, City= "Thanh Hóa", ShortName= "Th.Hóa", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/THD" },
                    new AirPort() { Name= "Tuy Hòa", Id= "TBB", Lat= 13.04955, Lng= 109.333706, City= "Tuy Hòa", ShortName= "Tuy Hòa", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/TBB" },
                    new AirPort() { Name= "Buôn Mê Thuột", Id= "BMV", Lat= 12.668311, Lng= 108.120272, City= "Buôn Mê Thuột", ShortName= "BM.Thuột", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/BMV" },
                    new AirPort() { Name= "Changi", Id= "SIN", Lat= 1.350189, Lng= 103.994433, City= "Singapore", ShortName= "Singapore", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/SIN" },
                    new AirPort() { Name= "Jakarta", Id= "CGK", Lat= -6.125567, Lng= 106.655897, City= "Jakarta", ShortName= "Jakarta(CGK)", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/CGK" },
                    new AirPort() { Name= "Bangkok (BKK)", Id= "BKK", Lat= 13.681108, Lng= 100.747283, City= "Bangkok (BKK)", ShortName= "Bangkok", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/BKK" },
                    new AirPort() { Name= "Kuala Lumpur", Id= "KUL", Lat= 2.745578, Lng= 101.709917, City= "Kuala Lumpur", ShortName= "Kuala Lumpur", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/KUL" },
                    new AirPort() { Name= "Phnom-penh", Id= "PNH", Lat= 11.546556, Lng= 104.844139, City= "Phnom-penh", ShortName= "Phnom Penh", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/PNH" },
                    new AirPort() { Name= "Yangon", Id= "RGN", Lat= 16.907305, Lng= 96.133222, City= "Yangon", ShortName= "Yangon", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/RGN" },
                    new AirPort() { Name= "Vientiane (Laos)", Id= "VTE", Lat= 17.988322, Lng= 102.563256, City= "Vientiane (Laos)", ShortName= "VTE", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/VTE" },
                    new AirPort() { Name= "Manila", Id= "MNL", Lat= 14.508647, Lng= 121.019581, City= "Manila", ShortName= "Manila", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/MNL" },
                    new AirPort() { Name= "Seoul", Id= "ICN", Lat= 37.469075, Lng= 126.450517, City= "Seoul", ShortName= "ICN", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/ICN" },
                    new AirPort() { Name= "Busan", Id= "PUS", Lat= 35.179528, Lng= 128.938222, City= "Busan", ShortName= "Busan", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/PUS" },
                    new AirPort() { Name= "Đài Bắc", Id= "TPE", Lat= 25.077731, Lng= 121.232822, City= "Đài Loan", ShortName= "Taiwan", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/TPE" },
                    new AirPort() { Name= "Bắc Kinh", Id= "BJS", Lat= 40.0798573, Lng= 116.6031121, City= "Bắc Kinh", ShortName= "BJS", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/BJS" },
                    new AirPort() { Name= "NGB", Id= "NGB", Lat= 0, Lng= 0, City= "NGB", ShortName= "NGB", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/NGB" },
                    new AirPort() { Name= "Đài Nam", Id= "TNN", Lat= 23.1229948, Lng= 120.1313012, City= "Tainan", ShortName= "TNN", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/TNN" },
                    new AirPort() { Name= "Phuket", Id= "HKT", Lat= 8.1132, Lng= 98.316872, City= "Phuket", ShortName= "Phuket", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/HKT" },
                    new AirPort() { Name= "Hong Kong", Id= "HKG", Lat= 22.308919, Lng= 113.914603, City= "Hong Kong", ShortName= "Hong Kong", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/HKG" },
                    new AirPort() { Name= "Đài Trung", Id= "RMQ", Lat= 24.264668, Lng= 120.62058, City= "Đài Trung", ShortName= "RMQ", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/RMQ" },
                    new AirPort() { Name= "Cao Hùng", Id= "KHH", Lat= 22.577094, Lng= 120.350006, City= "Cao Hùng", ShortName= "KHH", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/KHH" },
                    new AirPort() { Name= "Hàng Châu", Id= "HGH", Lat= 30.229503, Lng= 120.434453, City= "Hàng Châu", ShortName= "HGH", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/HGH" },
                    new AirPort() { Name= "Điện Biên Phủ", Id= "DIN", Lat= 21.397481, Lng= 103.007831, City= "Điện Biên Phủ", ShortName= "Điện Biên", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/DIN" },
                    new AirPort() { Name= "Thượng Hải", Id= "PVG", Lat= 31.143378, Lng= 121.805214, City= "Thượng Hải", ShortName= "PVG", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/PVG" },
                    new AirPort() { Name= "Narita", Id= "NRT", Lat= 35.771991, Lng= 140.3906614, City= "Narita", ShortName= "NRT", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/NRT" },
                    new AirPort() { Name= "New York", Id= "JFK", Lat= 40.641117, Lng= -73.7812992, City= "New York", ShortName= "JFK", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/JFK" },
                    new AirPort() { Name= "Osaka", Id= "KIX", Lat= 34.4347222, Lng= 135.244167, City= "Osaka", ShortName= "KIX", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/KIX" },
                    new AirPort() { Name= "Los Angeles", Id= "LAX", Lat= 33.942536, Lng= -118.408075, City= "Los Angeles", ShortName= "LAX", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/LAX" },
                    new AirPort() { Name= "San Francisco", Id= "SFO", Lat= 37.618972, Lng= -122.374889, City= "San Francisco", ShortName= "SFO", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/SFO" },
                    new AirPort() { Name= "Washington", Id= "WAS", Lat= 38.851242, Lng= -77.0402315, City= "Washington", ShortName= "WAS", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/WAS" },
                    new AirPort() { Name= "Amsterdam", Id= "AMS", Lat= 52.308613, Lng= 4.763889, City= "Amsterdam", ShortName= "AMS", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/AMS" },
                    new AirPort() { Name= "LonDon", Id= "LON", Lat= 51.5287718, Lng= -0.2416796, City= "LonDon", ShortName= "LON", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/LON" },
                    new AirPort() { Name= "Paris", Id= "PAR", Lat= 48.8589507, Lng= 2.2770207, City= "Paris", ShortName= "PAR", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/PAR" },
                    new AirPort() { Name= "Frankfurt", Id= "FRA", Lat= 50.121301, Lng= -8.5665246, City= "Frankfurt", ShortName= "FRA", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/FRA" },
                    new AirPort() { Name= "Chiang Mai", Id= "CNX", Lat= 18.767749, Lng= 98.9640088, City= "Chiang Mai", ShortName= "CNX", Thumbnail= "https://ssl.12bay.vn/api/v1/AirLines/Image/CNX" }
                };
                _context.AirPorts.AddRange(AirPort);
            }
        }
    }
}