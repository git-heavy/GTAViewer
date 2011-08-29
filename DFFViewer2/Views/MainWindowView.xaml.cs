using System.Windows;
using Heavy.DFFViewer.ViewModels;

namespace Heavy.DFFViewer.Views
{
  /// <summary>
  /// Interaction logic for MainWindowView.xaml
  /// </summary>
  public partial class MainWindowView : Window
  {
    public MainWindowView()
    {
      InitializeComponent();
      this.DataContext = new MainWindowViewModel();
    }
  }
}
