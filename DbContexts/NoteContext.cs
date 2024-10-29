using DSCC_CW1_00013940.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_CW1_00013940.DbContexts
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
