using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aNotepad.Model;

namespace aNotepad.Repositories
{
    /// <summary>
    /// Note repository interface.
    /// </summary>
    public interface INoteRepository
    {
        /// <summary>
        /// Get all notes.
        /// </summary>
        IList<Note> GetAll();

        /// <summary>
        /// Add new note.
        /// </summary>
        void Add(Note note);

        /// <summary>
        /// Delete note.
        /// </summary>
        void Delete(Note note);

        /// <summary>
        /// Save note.
        /// </summary>
        void Save(Note note);
    }
}
