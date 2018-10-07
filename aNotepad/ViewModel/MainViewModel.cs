using System.CodeDom;
using GalaSoft.MvvmLight;
using aNotepad.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using aNotepad.Exceptions;
using PostSharp.Patterns.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using aNotepad.Messages;
using aNotepad.Repositories;

namespace aNotepad.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    [NotifyPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        // Demo data
        //private Note[] _notesDemo =
        //{
        //    new Note {Title = "Title 1", Text = "Text 1"},
        //    new Note {Title = "Title 2", Text = "Text 2"}
        //};

        // Local repository
        private INoteRepository _localNoteRepository;

        // Remote repository
        private INoteRepository _remoteNoteRepository;

        // Collection of note ViewModels
        public ObservableCollection<NoteViewModel> Notes { get; set; }

        // Selected note property
        private NoteViewModel _selectedNote;
        public NoteViewModel SelectedNote
        {
            get { return _selectedNote; }
            set { _selectedNote = value; }
        }

        // Add new note command
        private RelayCommand _addNewNoteCommand;
        public RelayCommand AddNewNoteCommand
        {
            get { return _addNewNoteCommand; } 
        }

        // Generate exception command
        private RelayCommand _generateExceptionCommand;
        public RelayCommand GenerateExceptionCommand
        {
            get { return _generateExceptionCommand; }
        }

        // Delete note command
        private RelayCommand<NoteViewModel> _deleteNoteCommand;
        public RelayCommand<NoteViewModel> DeleteNoteCommand
        {
            get { return _deleteNoteCommand; }
        }

        // Save note command
        private RelayCommand<NoteViewModel> _saveNoteCommand;
        public RelayCommand<NoteViewModel> SaveNoteCommand
        {
            get { return _saveNoteCommand; }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INoteRepository LocalNoteRepository, INoteRepository RemoteNoteRepository)
        {
            // Assigning local repository
            _localNoteRepository = LocalNoteRepository;

            // Assigning remote repository
            _remoteNoteRepository = LocalNoteRepository;

            // Collection of note ViewModels
            Notes = new ObservableCollection<NoteViewModel>();

            // Notes from demo repository
            //_notesDemo.ToList().ForEach(note => Notes.Add(new NoteViewModel(note)));

            // Notes from local repository
            foreach (var note in _localNoteRepository.GetAll())
            {
                Notes.Add(new NoteViewModel(note));
            }

            // --------------------------------- Messages

            // Creating add new note command
            _addNewNoteCommand = new RelayCommand(
                () =>
                {
                    var msg = new AddNewNoteMessage(null);
                    Messenger.Default.Send(msg);
                }, () => true);
            // Subsribing to add new note command
            Messenger.Default.Register<AddNewNoteMessage>(this, OnNewNoteAdded);

            // Creating generate exception command
            _generateExceptionCommand = new RelayCommand(
                () =>
                {
                    var msg = new GenerateExceptionMessage(null);
                    Messenger.Default.Send(msg);
                }, () => true);
            // Subsribing to add new note command
            Messenger.Default.Register<GenerateExceptionMessage>(this, OnGenerateExceptionAction);

            // Creating delete note command
            _deleteNoteCommand = new RelayCommand<NoteViewModel>(
                (s) =>
                {
                    var msg = new DeleteNoteMessage(s);
                    Messenger.Default.Send(msg);
                }, (s) => Notes.Count > 0);
            // Subsribing to delete note command
            Messenger.Default.Register<DeleteNoteMessage>(this, OnNoteDeleted);

            // Creating save note command
            _saveNoteCommand = new RelayCommand<NoteViewModel>(
                (s) =>
                {
                    var msg = new SaveNoteMessage(s);
                    Messenger.Default.Send(msg);
                }, (s) => Notes.Count > 0);
            // Subsribing to delete note command
            Messenger.Default.Register<SaveNoteMessage>(this, OnNoteSaved);
        }

        // New note added action 
        private void OnNewNoteAdded(GenericMessage<NoteViewModel> msg)
        {
            int count = Notes.Count + 1;
            Note note = new Note {Title = "Title " + count, Text = "Text " + count};

            _localNoteRepository.Add(note);
            Notes.Add(new NoteViewModel(note));
        }

        // Exception generated action
        [NoteException(AspectPriority = 1)]
        private void OnGenerateExceptionAction(GenericMessage<NoteViewModel> msg)
        {
            int count = Notes.Count / 0;
        }

        // Note deleted action 
        private void OnNoteDeleted(GenericMessage<NoteViewModel> msg)
        {
            _localNoteRepository.Delete(msg.Content.Note);
            Notes.Remove(msg.Content);
        }

        // Note saved action 
        private void OnNoteSaved(GenericMessage<NoteViewModel> msg)
        {
            _localNoteRepository.Save(msg.Content.Note);
        }
    }
}