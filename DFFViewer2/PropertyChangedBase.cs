// -----------------------------------------------------------------------
// <copyright file="PropertyChangedBase.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Heavy.DFFViewer
{
  using System.ComponentModel;

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class PropertyChangedBase : INotifyPropertyChanged
  {
    protected void OnPropertyChanged(string propertyName)
    {
      if (this.PropertyChanged != null)
        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
