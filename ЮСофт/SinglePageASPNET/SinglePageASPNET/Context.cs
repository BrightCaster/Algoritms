using Microsoft.EntityFrameworkCore;
using SinglePageASPNET.Models;

namespace SinglePageASPNET
{
    public class Context:DbContext
    {
        public Context (DbContextOptions<Context> optionsBuilder) : base(optionsBuilder) { }
        public DbSet<ForRowOvers> ForOverRows => Set<ForRowOvers>();
    }
}
