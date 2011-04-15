using System.Windows;
using System.Windows.Media.Media3D;
using DFFLib;
using Microsoft.Win32;
using RWLib;

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

    public MainWindow()
    {
      InitializeComponent();
      InitViewPort();            
      ModelManager.Instance.FileLoadedEvent += new System.EventHandler(Instance_FileLoadedEvent);
    }

    private void InitViewPort()
    {
      //this.camera = new OrthographicCamera();
      //this.camera.LookDirection = new Vector3D(5, 0, 0);
      this.camera.Width = 10;
      //ModelViewPort.Camera = this.camera;
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
  }
}
