using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public Busket Busket { get;set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }

    }
    public class DModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public string Version { get; set; }
        public string Color { get; set; }
        public string Style { get; set; }
        public string Price { get; set; }
        public ICollection<Busket> Buskets { get; set; }
        public DModel()
        {
            Buskets = new List<Busket>();
        }
    }

    public class Busket
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public ICollection<DModel> Models { get; set; }
        public Busket()
        {
            Models = new List<DModel>();
        }
        public ApplicationUser User { get; set; }
    }

    public class Purchase
    {
        public int Id { get; set; }

        public int DModelId { get; set; }

        public int ApplicationUserId { get; set; }

        public DateTime Date { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<DModel> DModels { get; set; }
        public DbSet<Busket> Buskets { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}