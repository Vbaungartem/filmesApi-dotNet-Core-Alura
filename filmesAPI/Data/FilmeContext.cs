using filmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace filmesAPI.Data
{
    public class FilmeContext :DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {
        }
        public DbSet<Filme> Filmes
        {
            get;
            set;
        }
    }
}
