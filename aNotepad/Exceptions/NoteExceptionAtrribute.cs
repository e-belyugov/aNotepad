 using System.Windows;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace aNotepad.Exceptions
{
    [PSerializable]
    public class NoteExceptionAttribute : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            MessageBoxResult result = MessageBox.Show("Exception catched: " + args.Exception.Message);
            args.FlowBehavior = FlowBehavior.Continue;
        }
    }
}
