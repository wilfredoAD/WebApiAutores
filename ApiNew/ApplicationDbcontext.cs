using ApiNew.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiNew
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor>Autors{ get; set; }
    }
}
