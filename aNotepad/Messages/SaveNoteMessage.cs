using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aNotepad.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace aNotepad.Messages
{
    /// <summary>
    /// Add new note message.
    /// </summary>
    public class SaveNoteMessage : GenericMessage<NoteViewModel>
    {
        public SaveNoteMessage(NoteViewModel noteViewModel) : base(noteViewModel)
        {
        }
    }
}
