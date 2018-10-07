using System.Windows;
using System.Windows.Input;
using aNotepad.Messages;
using aNotepad.ViewModel;
using GalaSoft.MvvmLight.Messaging;

namespace aNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, e) =>
                MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // Subsribing to add new note command
            Messenger.Default.Register<AddNewNoteMessage>(this, OnNewNoteAdded);

            // Subsribing to delete note command
            Messenger.Default.Register<DeleteNoteMessage>(this, OnNoteDeleted);
        }

        // New note added action 
        private void OnNewNoteAdded(GenericMessage<NoteViewModel> msg)
        {
            int count = LbNotes.Items.Count;
            if (count > 0) LbNotes.SelectedIndex = count - 1;
        }

        // Note deleted action 
        private void OnNoteDeleted(GenericMessage<NoteViewModel> msg)
        {
            int count = LbNotes.Items.Count;
            if (count > 0) LbNotes.SelectedIndex = 0;
        }
    }
}
