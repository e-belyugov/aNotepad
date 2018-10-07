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
    /// Note repository interface.
    /// </summary>
    public class LocalNoteRepository: INoteRepository
    {
        // DB context
        LocalNoteRepositoryContext db;

        /// <summary>
        /// Constructor.
        /// </summary>
        public LocalNoteRepository()
        {
            db = new LocalNoteRepositoryContext();
            db.Notes.Load();
        }

        /// <summary>
        /// Get all notes.
        /// </summary>
        public IList<Note> GetAll()
        {
            return db.Notes.Local.ToBindingList();
        }

        /// <summary>
        /// Add new note.
        /// </summary>
        public void Add(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
        }

        /// <summary>
        /// Delete note.
        /// </summary>
        public void Delete(Note note)
        {
            db.Notes.Remove(note);
            db.SaveChanges();
        }

        /// <summary>
        /// Save note.
        /// </summary>
        public void Save(Note note)
        {
            Note noteDb = db.Notes.Local.SingleOrDefault(x => x.Id == note.Id);
            if (noteDb != null)
            {
                noteDb.Title = note.Title;
                noteDb.Text = note.Text;
                db.SaveChanges();
            }
        }
    }
}
