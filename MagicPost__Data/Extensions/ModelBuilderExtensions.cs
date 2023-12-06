using MagicPost__Data.Entities;
using MagicPost__Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace MagicPost_Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of MagicPost" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of MagicPost" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of MagicPost" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

       

            // any guid
            var NhanVienId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var LanhDaoID = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            var TruongDiemId = new Guid("8dbdfeba-e424-4e2c-9931-cdde4472daa6");
            var GiaoDichVienId = new Guid("f98d4249-7ab3-44b6-b074-9c28b018475b");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = TruongDiemId,
                Name = "TruongDiem",
                NormalizedName = "TruongDiem",
                Description = "Trưởng điểm giao dịch và tập kết "
            },
            new AppRole
            {
                Id = LanhDaoID,
                Name = "LanhDao",
                NormalizedName = "LanhDao",
                Description = "Lãnh đạo"
            },
            new AppRole
            {
                Id = GiaoDichVienId,
                Name = "GiaoDichVien",
                NormalizedName = "GiaoDichVien",
                Description = "Giao dịch viên"
            },
            new AppRole
            {
                Id = NhanVienId,
                Name = "NhanVienTapKet",
                NormalizedName = "NhanVienTapKet",
                Description = "Nhân viên tập kết"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = NhanVienId,
                UserName = "NhanVienTapKet",
                NormalizedUserName = "NhanVienTapKet",
                Email = "hieumai09042003@gmail.com",
                NormalizedEmail = "hieumai09042003@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "BTL@123"),
                SecurityStamp = string.Empty,
                FirstName = "Hieu",
                LastName = "Nguyen",
                Dob = new DateTime(2003, 04, 09)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = NhanVienId,
                UserId = NhanVienId
            });
			modelBuilder.Entity<Order>().HasData(new Order
			{
			    Id =1,
                OrderDate = DateTime.Now,
                UserId = NhanVienId,
                Code = "MAX123",
                SendName ="Hieu",
                ReceiveName ="Hung",
                SendAddress ="Cau giay",
				ReceiveAddress ="Xuan Thuy",
                SendPhoneNumber ="0827259403",
				ReceivePhoneNumber ="088965072",
                Cuoc = 100000,
                KhoiLuong = 1.2
                
			});
			modelBuilder.Entity<Slide>().HasData(
			  new Slide() { Id = 1, Name = "Magic Post siêu uy tín", Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
			  new Slide() { Id = 2, Name = "Magic Post siêu uy tín", Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
			  new Slide() { Id = 3, Name = "Magic Post siêu uy tín", Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
			  new Slide() { Id = 4, Name = "Magic Post siêu uy tín", Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
			  new Slide() { Id = 5, Name = "Magic Post siêu uy tín", Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
			  new Slide() { Id = 6, Name = "Magic Post siêu uy tín", Description = "Magic Post siêu uy tín, uy tín số 1 Việt Nam", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
			  );
		}
    }
}
