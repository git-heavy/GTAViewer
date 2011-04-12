using System.Windows;
using System.Windows.Media.Media3D;
using DFFLib;
using Microsoft.Win32;
using RWLib;
using System.Windows.Controls;

namespace DFFViewer
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public double CamWidth
    {
      get { return ((OrthographicCamera)ModelViewPort.Camera).Width; }
      set { ((OrthographicCamera)ModelViewPort.Camera).Width = value; }
    }

    private OrthographicCamera camera;

    public MainWindow()
    {
      InitializeComponent();
      InitViewPort();            
      ModelManager.Instance.FileLoadedEvent += new System.EventHandler(Instance_FileLoadedEvent);
    }

    private void InitViewPort()
    {
      this.camera = new OrthographicCamera();
      this.camera.LookDirection = new Vector3D(5, 0, 0);
      this.camera.Width = 5;
      ModelViewPort.Camera = this.camera;
      AmbientLight light = new AmbientLight();
      ModelVisual3D lightModel = new ModelVisual3D();
      lightModel.Content = light;
      ModelViewPort.Children.Add(lightModel);

    }

    private Model3DGroup group;

    private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
    {
      OpenFileDialog openDialog = new OpenFileDialog();
      if (openDialog.ShowDialog() == true)
      {
        ModelManager.Instance.LoadFile(openDialog.FileName);
      }
    }

    void Instance_FileLoadedEvent(object sender, System.EventArgs e)
    {
      foreach (RWSection section in ((ModelManager)sender).Root.Childs)
        if (section is ClumpSection)
        {
          this.group = new GeometryBuilder((ClumpSection)section).Build();
          MainModel.Content = group;
          return;
        }
    }

    private void Grid_MouseWheel_1(object sender, System.Windows.Input.MouseWheelEventArgs e)
    {
      this.camera.Position = new Point3D(
        this.camera.Position.X,
        this.camera.Position.Y,
        this.camera.Position.Z - e.Delta / 250D);
    }
  }
}
