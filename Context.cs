using api_ead.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace api_ead
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Usuario> tbUsuario { get; set; }
    }
}
