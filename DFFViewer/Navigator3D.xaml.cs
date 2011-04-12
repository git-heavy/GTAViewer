using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace DFFViewer
{
  /// <summary>
  /// Interaction logic for Navigator3D.xaml
  /// </summary>
  public partial class Navigator3D : UserControl
  {
    public Navigator3D()
    {
      InitializeComponent();
    }

    private void LeftCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {

    }

    private void RightCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
    }

    private void TopCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {

    }

    private void BottomCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {

    }

    public Point3D Position { get; set; }    
  }
}
