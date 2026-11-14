using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace WpfApp5._1
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

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Ink Format (*.isf)|*.isf"
            };

            if (openFileDialog.ShowDialog() != true)
                return;

            var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
            InkCanvas.Strokes = new StrokeCollection(fileStream);
            FileName = openFileDialog.FileName;
        }

        private void MenuItem_Save(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                MenuItem_SaveAs(sender, e);
            }
            else
            {
                var fileStream = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                InkCanvas.Strokes.Save(fileStream);
            }
        }

        private void MenuItem_SaveAs(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Ink Format (*.isf)|*.isf"
            };

            if (saveFileDialog.ShowDialog() != true)
                return;

            var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
            InkCanvas.Strokes.Save(fileStream);
        }

        private void MenuItem_ExportToPng(object sender, RoutedEventArgs e)
        {
            if (InkCanvas.Strokes.Count == 0)
            {
                MessageBox.Show("Набросок пуст", "Ошибка");
                return;
            }
            
            var width = (int)InkCanvas.ActualWidth;
            var height = (int)InkCanvas.ActualHeight;
    
            if (width == 0 || height == 0) 
                return;

            var targetBitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            targetBitmap.Render(InkCanvas);

            var bitmapEncoder = new PngBitmapEncoder();
            bitmapEncoder.Frames.Add(BitmapFrame.Create(targetBitmap));

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG (*.png)|*.png | Все файлы (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() != true)
                return;
            
            using (var image = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
            {
                bitmapEncoder.Save(image);
            }
        }

        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Сохранить набросок?", "Внимание", MessageBoxButton.YesNoCancel);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    MenuItem_Save(sender, e);
                    Application.Current.Shutdown();
                    break;
                
                case MessageBoxResult.No:
                    Application.Current.Shutdown();
                    break;

                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void SetEditingModeInk_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonDraw.IsChecked = true;
            ButtonErase.IsChecked = false;
            InkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            
            if (!_isDrawSizeSet)
                SetDrawSize(DrawSizes);
        }

        private void SetEditingModeEraseByPoint_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonErase.IsChecked = true;
            ButtonDraw.IsChecked = false;
            InkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            
            if (! _isEraseSizeSet)
                SetEraseSize(EraseSizes);
        }

        private bool _isDrawSizeSet;
        private bool _isEraseSizeSet;
        
        private void DrawThickness_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InkCanvas == null)
                return;

            SetDrawSize(sender);
        }

        private void SetDrawSize(object sender)
        {
            var drawSize = ((sender as ComboBox)?.SelectedItem as TextBlock)?.Text;
            var inkDrawingAttributes = InkCanvas.DefaultDrawingAttributes;

            if (drawSize == null)
                return;

            inkDrawingAttributes.Height = int.Parse(drawSize);
            inkDrawingAttributes.Width = int.Parse(drawSize);
            InkCanvas.DefaultDrawingAttributes = inkDrawingAttributes;
            _isDrawSizeSet = true;
        }

        private void EraseThickness_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InkCanvas == null)
                return;

            SetEraseSize(sender);
        }

        private void SetEraseSize(object sender)
        {
            var eraseSize = ((sender as ComboBox)?.SelectedItem as TextBlock)?.Text;

            if (eraseSize == null)
                return;

            var size = int.Parse(eraseSize);

            InkCanvas.EraserShape = new RectangleStylusShape(size, size);
            _isEraseSizeSet = true;
            
            var currentMode = InkCanvas.EditingMode;
            InkCanvas.EditingMode = InkCanvasEditingMode.None;
            InkCanvas.EditingMode = currentMode;
        }
    }
}