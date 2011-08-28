using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace Heavy.DFFViewer.Views
{
  /// <summary>
  /// Interaction logic for CameraView.xaml
  /// </summary>
  public partial class CameraView : UserControl
  {


    public PerspectiveCamera Camera
    {
      get { return (PerspectiveCamera)GetValue(CameraProperty); }
      set { SetValue(CameraProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Camera.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CameraProperty =
        DependencyProperty.Register("Camera", typeof(PerspectiveCamera), typeof(CameraView));



    public CameraView()
    {
      InitializeComponent();
    }
  }
}
