using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aNotepad.Model;

namespace aNotepad.Repositories
{
    /// <summary>
    /// Local note repository context.
    /// </summary>
    public class LocalNoteRepositoryContext: DbContext
    {
        public LocalNoteRepositoryContext() : base("DefaultConnection")
        {
        }
        public DbSet<Note> Notes { get; set; }
    }
}
