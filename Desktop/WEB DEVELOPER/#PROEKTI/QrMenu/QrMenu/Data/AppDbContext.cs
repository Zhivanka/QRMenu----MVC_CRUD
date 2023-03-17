using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QrMenu.Models;


namespace QrMenu.Data
{
    public class AppDbContext : IdentityDbContext
    {
      

        //konstruktor koj kje prima opcii i istite kje bidat prefrleni i na osnovnata klasa
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        //site modeli koi treba da se kreirat vo databazata se definirat ovde
        //Category e imeto na klasata model, Categories kje bide imeto na tabelata vo databazata
        //na toj nacin kje se creira nova tabela koja shto gi zema propertinjata od klasata koja e definirana vo DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> LoginUsers { get; set; }
    }
}
