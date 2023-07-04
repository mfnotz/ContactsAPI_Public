using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Abstractions.Repositories
{
    public interface IContactsDbContext
    {
        //DbSet<LoginInfo> LoginInfo { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Skill> Skills { get; set; }

        int SaveChanges(CancellationToken cancellationToken = default);
    }
}
