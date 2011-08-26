using System.Windows;
using Heavy.DFFViewer.View;
using Heavy.DFFViewer.ViewModel;

namespace Heavy.DFFViewer
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    #region Методы

    /// <summary>
    /// Обработчик события на старт приложения.
    /// </summary>
    /// <param name="sender">Источник события.</param>
    /// <param name="e">Параметры события.</param>
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      ViewService.OpenViewModel(new MainWindowViewModel());
    }

    #endregion
  }
}
