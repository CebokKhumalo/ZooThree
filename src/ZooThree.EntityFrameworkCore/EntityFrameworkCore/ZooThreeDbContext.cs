using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ZooThree.Authorization.Roles;
using ZooThree.Authorization.Users;
using ZooThree.MultiTenancy;
using ZooThree.Domain;

namespace ZooThree.EntityFrameworkCore
{
    public class ZooThreeDbContext : AbpZeroDbContext<Tenant, Role, User, ZooThreeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Person> Persons { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<Species> Specieses { get; set; }
        public ZooThreeDbContext(DbContextOptions<ZooThreeDbContext> options)
            : base(options)
        {
        }
    }
}
