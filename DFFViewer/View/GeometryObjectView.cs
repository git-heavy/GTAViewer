using System.Windows;
using System.Windows.Controls;

namespace Heavy.DFFViewer.View
{
  public class GeometryObjectView : Viewport3D
  {
    static GeometryObjectView()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(GeometryObjectView), new FrameworkPropertyMetadata(typeof(GeometryObjectView)));
    }
  }
}
