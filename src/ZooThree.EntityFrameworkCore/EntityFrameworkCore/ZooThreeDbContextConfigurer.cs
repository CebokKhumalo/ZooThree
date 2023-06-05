using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ZooThree.EntityFrameworkCore
{
    public static class ZooThreeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ZooThreeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ZooThreeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
