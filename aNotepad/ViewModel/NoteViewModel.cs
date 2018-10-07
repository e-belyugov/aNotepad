using aNotepad.Model;
using PostSharp.Patterns.Model;

namespace aNotepad.ViewModel
{
    /// <summary>
    /// Note view mode class.
    /// </summary>
    [NotifyPropertyChanged]
    public class NoteViewModel
    {
        private readonly Note _note;

        public NoteViewModel(Note note)
        {
            _note = note;
        }

        public Note Note
        {
            get { return _note; }
        }

        public string Title
        {
            get { return _note.Title; }
            set { _note.Title = value; }
        }

        public string Text
        {
            get { return _note.Text; }
            set { _note.Text = value; }
        }
    }
}
