using MarketLab.Domain.Resources.Entities;
using MarketLab.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketLab.Infra.Data.EFCore.Persistence
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedResources();
            modelBuilder.SeedUsers();
        }

        private static void SeedResources(this ModelBuilder modelBuilder)
        {
            var resources = new Resource[]
            {
                new Resource(){ Id = 1, Name ="Kim",BaseUrl ="https://www.kimmarket.com"},
                new Resource(){ Id= 2, Name ="Bim",BaseUrl ="https://www.bim.com.tr/default.aspx"},
                new Resource(){ Id= 3, Name ="A101",BaseUrl ="https://www.a101.com.tr"},
                new Resource(){ Id= 4, Name ="Şok",BaseUrl ="https://www.sokmarket.com.tr/anasayfa"},
                new Resource(){ Id= 5, Name ="Migros",BaseUrl ="https://www.migros.com.tr"},
                new Resource(){ Id= 6, Name ="Carrefoursa",BaseUrl ="https://www.carrefoursa.com/tr"}
            };

            modelBuilder.Entity<Resource>().HasData(resources);
        }

        private static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var owner = new User()
            {
                Id = 1,
                Username = "eymenkhater",
                Password = "123456778",
                Email = "eymenkhater@gmail.com",
                Phone = "5325742007",
            };
            // owner.Password = new PasswordHasher<User>().HashPassword(owner, owner.Password);

            var users = new User[] { owner };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}