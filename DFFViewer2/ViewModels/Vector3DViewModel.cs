// -----------------------------------------------------------------------
// <copyright file="Vector3DViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Media.Media3D;
namespace Heavy.DFFViewer.ViewModels
{

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class Vector3DViewModel : BaseViewModel
  {
    private Vector3D value;

    public Vector3D Value
    {
      get
      {
        return this.value;
      }

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
        return this.value.X;
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
        return this.value.Y;
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
        return this.value.Z;
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
