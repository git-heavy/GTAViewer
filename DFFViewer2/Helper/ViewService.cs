// -----------------------------------------------------------------------
// <copyright file="ViewService.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;

namespace Heavy.DFFViewer.Helper
{

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public static class ViewService
  {
    public static void ShowMessageBox(string message)
    {
      MessageBox.Show(message, "", MessageBoxButton.OK, MessageBoxImage.Error);
    }
  }
}
