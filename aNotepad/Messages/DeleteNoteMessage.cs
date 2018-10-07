using aNotepad.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace aNotepad.Messages
{
    /// <summary>
    /// Add new note message.
    /// </summary>
    public class DeleteNoteMessage : GenericMessage<NoteViewModel>
    {
        public DeleteNoteMessage(NoteViewModel noteViewModel) : base(noteViewModel)
        {
        }
    }
}

