using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Heavy.DFFViewer.ViewModel;
using System.Windows.Data;

namespace Heavy.DFFViewer.View
{
  /// <summary>
  /// Сервис управления окнами.
  /// </summary>
  public static class ViewService
  {
    #region Поля и свойства

    /// <summary>
    /// Коллекция открытых окон.
    /// </summary>
    private static Collection<Window> openedWindows = new Collection<Window>();

    #endregion

    #region Методы

    /// <summary>
    /// Открыть представление.
    /// </summary>
    /// <param name="viewModel">Модель представления.</param>
    /// <param name="width">Ширина окна.</param>
    /// <param name="height">Высота окна.</param>
    public static void OpenViewModel(BaseViewModel viewModel, double width, double height)
    {
      Window openedWindow = openedWindows.SingleOrDefault(window => window.Content.Equals(viewModel));
      if (openedWindow == null)
      {
        openedWindow = new Window();
        openedWindow.Width = width;
        openedWindow.Height = height;
        openedWindow.SetBinding(Window.TitleProperty, new Binding("Name"));        
        openedWindow.DataContext = viewModel;
        openedWindow.Content = viewModel;
        openedWindow.Closed += OpenedWindowClosed;
        openedWindows.Add(openedWindow);
        openedWindow.Show();
      }
      else
        openedWindow.Activate();
    }

    /// <summary>
    /// Открыть представление.
    /// </summary>
    /// <param name="viewModel">Модель представления.</param>
    public static void OpenViewModel(BaseViewModel viewModel)
    {
      OpenViewModel(viewModel, 640, 480);
    }

    /// <summary>
    /// Обработчик события на закрытие окна.
    /// </summary>
    /// <param name="sender">Источник события.</param>
    /// <param name="e">Параметры события.</param>
    private static void OpenedWindowClosed(object sender, EventArgs e)
    {
      Window window = sender as Window;
      if (window != null && openedWindows.Contains(window))
      {
        openedWindows.Remove(window);
        window.Closed -= OpenedWindowClosed;
      }
    }

    #endregion
  }
}
