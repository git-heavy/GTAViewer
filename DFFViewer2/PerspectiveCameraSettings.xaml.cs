using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace Heavy.DFFViewer
{
  /// <summary>
  /// Interaction logic for PerspectivaCameraSettings.xaml
  /// </summary>
  public partial class PerspectiveCameraSettings : UserControl, INotifyPropertyChanged
  {


    public PerspectiveCamera Camera
    {
      get { return (PerspectiveCamera)GetValue(CameraProperty); }
      set
      {
        SetValue(CameraProperty, value);
        this.Position = value.Position;
      }
    }

    // Using a DependencyProperty as the backing store for Camera.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CameraProperty =
        DependencyProperty.Register("Camera", typeof(PerspectiveCamera), typeof(PerspectiveCameraSettings));

    private void OnPropertyChanged(string propertyName)
    {
      if (this.PropertyChanged != null)
        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    private Point3D position;

    public Point3D Position
    {
      get
      {
        return this.position;
      }

      set
      {
        this.position = value;
        this.OnPropertyChanged("Position");
        this.SettingsChanged(this, null);
      }
    }
    #region Конструктор

    public PerspectiveCameraSettings()
    {
      InitializeComponent();
      this.DataContext = this;
    }

    #endregion

    public event EventHandler SettingsChanged;

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
