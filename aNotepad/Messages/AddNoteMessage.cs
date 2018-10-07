using aNotepad.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace aNotepad.Messages
{
    /// <summary>
    /// Add new note message.
    /// </summary>
    public class AddNewNoteMessage : GenericMessage<NoteViewModel>
    {
        public AddNewNoteMessage(NoteViewModel noteViewModel) : base(noteViewModel)
        {
        }
    }
}
