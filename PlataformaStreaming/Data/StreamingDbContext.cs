using Microsoft.EntityFrameworkCore;
using PlataformaStreaming.Dominio;

namespace PlataformaStreaming.Data;

public class StreamingDbContext : DbContext
{
    public StreamingDbContext(DbContextOptions<StreamingDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; } = default!;
}
