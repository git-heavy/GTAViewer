using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using Heavy.DFFViewer.ViewModels;
using Heavy.RWLib;
using Heavy.RWLib.Sections;
using Microsoft.Win32;

namespace Heavy.DFFViewer
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
      SectionLoaderManager.Instance.RegisterLoader(new Heavy.DFFLib.DFFSectionLoader());
      SectionLoaderManager.Instance.RegisterLoader(new Heavy.TXDLib.TXDSectionLoader());
      this.camViewModel.Camera = this.cam;
      this.camViewModel.PropertyChanged += new PropertyChangedEventHandler(camViewModel_PropertyChanged);
    }

    private void camViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }

    #endregion

    private PerspectiveCamera cam = new PerspectiveCamera() { Position = new Point3D(220, 20, 30) };

    public PerspectiveCamera Cam
    {
      get { return this.cam; }
    }

    private Point3D position = new Point3D(1, 1, 1);

    public Point3D Position
    {
      get
      {
        return this.position;
      }

      set
      {
        this.position = value;
      }
    }


    private CameraViewModel camViewModel = new CameraViewModel();

    public CameraViewModel CamViewModel
    {
      get { return this.camViewModel; }
    }

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
        //this.modelViewPort.ModelMetadata = (ClumpSection)root.Childs[0];
      }
    }

    private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show(this.Cam.Position.ToString());
      //this.Position = new Point3D(10, 10, 10);
    }
  }
}
