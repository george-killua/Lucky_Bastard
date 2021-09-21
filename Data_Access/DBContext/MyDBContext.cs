
using Data_Access.Enum;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access.DBContext
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<GameHistory> GameHistories { get; set; }
        public DbSet<Mini> Minis { get; set; }  
        public DbSet<Minor> Minors { get; set; }
        public DbSet<Major> Majors { get; set; }

        public DbSet<LoginHistory> LoginHistories { get; set; }
        public DbSet<ChargeHistory> ChargeHistories { get; set; }

        public DbSet<Grand> Grands { get; set; }
        public DbSet<GameInstraction> GameInstractions { get; set; }
        public DbSet<JackbotWinner> JackbotWinners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(C => C.Username);
            modelBuilder.Entity<User>().HasMany(d => d.ChargeHistories).WithOne(h => h.User).HasForeignKey(f => f.Creater).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(d => d.LoginHistories).WithOne(h => h.User).HasForeignKey(f => f.Creater).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(d => d.GameHistories).WithOne(h => h.User).HasForeignKey(f => f.Creater).OnDelete(DeleteBehavior.Cascade);
            var converter = new EnumToStringConverter<UserType>();
            modelBuilder.Entity<User>().Property(E => E.UserType).HasConversion(converter);
 
        //    var stock = new Faker<User>()
        //.RuleFor(m => m.Username, f => f.Person.FullName)
        //.RuleFor(m => m.Creater, f => "george")
        //.RuleFor(m => m.UserType, f => UserType.Player)
        //.RuleFor(m => m.Password, f => "159753Abo");


        //    // generate 1000 items

        //    List<User> orders = stock.Generate(100);

        //    modelBuilder.Entity<User>().HasData(orders.ToArray());
           

        }
       
    }
}
