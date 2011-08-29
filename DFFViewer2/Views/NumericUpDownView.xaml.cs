using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Heavy.DFFViewer.Views
{
  /// <summary>
  /// Interaction logic for NumericUpDownView.xaml
  /// </summary>
  public partial class NumericUpDownView : UserControl
  {
    public double Value
    {
      get { return (double)GetValue(ValueProperty); }
      set { SetValue(ValueProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(double), typeof(NumericUpDownView), new UIPropertyMetadata(default(double)));

    public NumericUpDownView()
    {
      InitializeComponent();
      this.DataContext = this;
    }

    private void UpCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
      this.Value += 1;
    }

    private void DownCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
      this.Value -= 1;
    }

    private void UserControl_MouseWheel(object sender, MouseWheelEventArgs e)
    {
      this.Value += e.Delta > 0 ? 1 : -1;
    }
  }
}
