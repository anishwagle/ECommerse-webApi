using Ecommerce_webApi.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerse_webApi
{
    public class ContactManagementDbContext : DbContext
    {
        public ContactManagementDbContext(DbContextOptions<ContactManagementDbContext> options) : base(options) { }

        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
