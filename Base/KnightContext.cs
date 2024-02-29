using Microsoft.EntityFrameworkCore;
using PocBTG.Models;
namespace PocBTG.Base
{
    // Context class for Knight
    public class KnightContext : DbContext
    {
        //  Constructor for KnightContext
        public KnightContext(DbContextOptions<KnightContext> options)
           : base(options)
        {
        }

        
        public DbSet<Knight> KnightItens { get; set; } = null!;
        public DbSet<Weapon> WeaponItens { get; set; } = null!;
        public DbSet<Attributes> AttributesItens { get; set; } = null!;
    }
}