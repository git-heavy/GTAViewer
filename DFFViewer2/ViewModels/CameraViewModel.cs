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
    #region Поля и свойства

    private PerspectiveCamera camera = new PerspectiveCamera();

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
        this.Initialize();
      }
    }

    private Point3DViewModel position = new Point3DViewModel();

    public Point3DViewModel Position
    {
      get { return this.position; }
    }

    private Vector3DViewModel lookDirection = new Vector3DViewModel();

    public Vector3DViewModel LookDirection
    {
      get { return this.lookDirection; }
    }

    public double FieldOfView
    {
      get
      {
        return this.Camera.FieldOfView;
      }

      set
      {
        this.Camera.FieldOfView = value;
        this.OnPropertyChanged(() => FieldOfView);
        this.OnPropertyChanged(() => Camera);
      }
    }

    #endregion

    #region Методы

    private void Initialize()
    {
      this.Position.Value = this.Camera.Position;
      this.LookDirection.Value = this.Camera.LookDirection;
    }

    private void lookDirectionViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "Value")
      {
        this.Camera.LookDirection = this.LookDirection.Value;
        this.OnPropertyChanged(() => Camera);
      }
    }

    private void positionViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "Value")
      {
        this.Camera.Position = this.Position.Value;
        this.OnPropertyChanged(() => Camera);
      }
    }

    #endregion

    #region Конструкторы

    public CameraViewModel()
    {
      this.position.PropertyChanged += new PropertyChangedEventHandler(positionViewModel_PropertyChanged);
      this.lookDirection.PropertyChanged += new PropertyChangedEventHandler(lookDirectionViewModel_PropertyChanged);
    }

    #endregion
  }
}
