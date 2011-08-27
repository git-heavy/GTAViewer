using System.Windows;
using System.Windows.Input;
using Heavy.DFFLib.Sections;
using Heavy.RWLib;
using Heavy.RWLib.Sections;
using Microsoft.Win32;

namespace DFFViewer2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    #region Конструкторы

    /// <summary>
    /// Initializes a new instance of the MainWindow class.
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = this;
    }

    #endregion

    private void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog()
      {
        CheckFileExists = true,
        CheckPathExists = true,
        Multiselect = false,
        DefaultExt = "*.dff"
      };

      if (dialog.ShowDialog().Value)
      {
        RootSection root = SectionLoaderManager.Instance.LoadFromStream(dialog.OpenFile());
        this.modelViewPort.ModelMetadata = (ClumpSection)root.Childs[0];
      }
    }

    private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }
  }
}
