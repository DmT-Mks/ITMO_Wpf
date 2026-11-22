using System.Windows.Input;

namespace WpfApp8
{
    public class AppCommands
    {
        public static readonly RoutedUICommand SaveAs = new RoutedUICommand(
            "Save as", 
            "SaveAs", 
            typeof(AppCommands),
            new InputGestureCollection { new KeyGesture(Key.S, ModifierKeys.Control | ModifierKeys.Shift , "Ctrl+Shift+S") }
        );
    }
}