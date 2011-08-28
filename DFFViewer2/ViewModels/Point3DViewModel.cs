// -----------------------------------------------------------------------
// <copyright file="Point3DViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Heavy.DFFViewer.ViewModels
{
  using System.Windows.Media.Media3D;

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class Point3DViewModel : BaseViewModel
  {
    private Point3D value;

    public Point3D Value
    {
      get { return this.value; }
      set
      {
        this.value = value;
        this.OnPropertyChanged(() => Value);
      }
    }

    public double X
    {
      get
      {
        return this.Value.X;
      }

      set
      {
        this.value.X = value;
        this.OnPropertyChanged(() => X);
        this.OnPropertyChanged(() => Value);
      }
    }

    public double Y
    {
      get
      {
        return this.Value.Y;
      }

      set
      {
        this.value.Y = value;
        this.OnPropertyChanged(() => Y);
        this.OnPropertyChanged(() => Value);
      }
    }

    public double Z
    {
      get
      {
        return this.Value.Z;
      }

      set
      {
        this.value.Z = value;
        this.OnPropertyChanged(() => Z);
        this.OnPropertyChanged(() => Value);
      }
    }
  }
}
