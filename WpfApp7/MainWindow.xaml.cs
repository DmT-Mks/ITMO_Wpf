using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace WpfApp7
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

        private string FileName { get; set; }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.**"
            };

            if (openFileDialog.ShowDialog() != true)
                return;

            TextBox.Text = File.ReadAllText(openFileDialog.FileName);
            FileName = openFileDialog.FileName;
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                SaveAsExecuted(sender, e);
            }
            else
            {
                File.WriteAllText(FileName, TextBox.Text);
            }
        }

        private void SaveAsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.**"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TextBox.Text);
            }
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox.Text))
            {
                var result = MessageBox.Show("Сохранить файл?", "Внимание", MessageBoxButton.YesNoCancel);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        File.WriteAllText(FileName, TextBox.Text);
                        Application.Current.Shutdown();
                        break;

                    case MessageBoxResult.No:
                        Application.Current.Shutdown();
                        break;

                    case MessageBoxResult.Cancel:
                        return;
                }
            }

            Application.Current.Shutdown();
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