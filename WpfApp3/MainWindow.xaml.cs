using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FontFamily_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TextBox == null)
                return;

            var fontFamily = ((sender as ComboBox)?.SelectedItem as TextBlock)?.Text;

            if (fontFamily != null)
                TextBox.FontFamily = new FontFamily(fontFamily);
        }

        private void FontSize_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TextBox == null)
                return;

            var fontSize = ((sender as ComboBox)?.SelectedItem as TextBlock)?.Text;

            if (fontSize != null)
                TextBox.FontSize = int.Parse(fontSize);
        }

        private void SetTextBold_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBox == null)
                return;

            var fontWeight = TextBox.FontWeight;
            
            TextBox.FontWeight = fontWeight != FontWeights.Bold
                ? FontWeights.Bold
                : FontWeights.Normal;
        }

        private void SetTextItalic_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBox == null)
                return;

            var fontStyle = TextBox.FontStyle;
            
            TextBox.FontStyle = fontStyle != FontStyles.Italic
                ? FontStyles.Italic
                : FontStyles.Normal;
        }
        
        private void SetTextUnderline_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextBox == null)
                return;

            var hasUnderline = TextBox.TextDecorations != null
                               && TextBox.TextDecorations.Contains(TextDecorations.Underline[0]);
            
            TextBox.TextDecorations = hasUnderline
                ? null
                : TextDecorations.Underline;
        }

        private void SetTextBlack_OnChecked(object sender, RoutedEventArgs e)
        {
            if (TextBox == null)
                return;

            TextBox.Foreground = TextBox.Foreground = Brushes.Black;
        }
        
        private void SetTextRed_OnChecked(object sender, RoutedEventArgs e)
        {
            if (TextBox == null)
                return;

            TextBox.Foreground = TextBox.Foreground = Brushes.Red;
        }
    }
}