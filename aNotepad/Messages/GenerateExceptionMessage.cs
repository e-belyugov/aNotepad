using aNotepad.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace aNotepad.Messages
{
    /// <summary>
    /// Generate exception message.
    /// </summary>
    public class GenerateExceptionMessage : GenericMessage<NoteViewModel>
    {
        public GenerateExceptionMessage(NoteViewModel noteViewModel) : base(noteViewModel)
        {
        }
    }
}
