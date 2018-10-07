using PostSharp.Patterns.Model;

namespace aNotepad.Model
{
    /// <summary>
    /// Note class.
    /// </summary>
    [NotifyPropertyChanged]
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
