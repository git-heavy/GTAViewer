// -----------------------------------------------------------------------
// <copyright file="CameraViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows.Media.Media3D;

namespace Heavy.DFFViewer.ViewModels
{

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class CameraViewModel : BaseViewModel
  {
    private PerspectiveCamera camera;

    public PerspectiveCamera Camera
    {
      get
      {
        return this.camera;
      }

      set
      {
        this.camera = value;
        this.OnPropertyChanged(() => Camera);
        this.InitPosition(this.Camera.Position);
      }
    }

    private void InitPosition(Point3D position)
    {
      this.positionViewModel.Value = position;
    }

    private Point3DViewModel positionViewModel = new Point3DViewModel();

    public Point3DViewModel PositionViewModel
    {
      get { return this.positionViewModel; }
    }

    public CameraViewModel()
    {
      this.positionViewModel.PropertyChanged += new PropertyChangedEventHandler(positionViewModel_PropertyChanged);
    }

    private void positionViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "Value")
      {
        this.Camera.Position = PositionViewModel.Value;
        this.OnPropertyChanged(() => Camera);
      }
    }
  }

}
