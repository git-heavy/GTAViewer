using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DFFViewer
{
  /// <summary>
  /// Interaction logic for ExtendedSlider.xaml
  /// </summary>
  public partial class ExtendedSlider : UserControl
  {
    public ExtendedSlider()
    {
      InitializeComponent();
      this.DataContext = this;
    }

    public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
      "Value", typeof(double), typeof(ExtendedSlider));

    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
      "Orientation", typeof(Orientation), typeof(ExtendedSlider));

    public double Value
    {
      get { return this.Slider.Value; }
      set { this.Slider.Value = value;
      this.OnPropertyChanged(new DependencyPropertyChangedEventArgs());
      }
    }

    public double MinimumValue
    {
      get { return this.Slider.Minimum; }
      set { this.Slider.Minimum = value; }
    }

    public double MaximumValue
    {
      get { return this.Slider.Maximum; }
      set { this.Slider.Maximum = value; }
    }

    public Orientation Orientation
    {
      get { return this.Slider.Orientation; }
      set
      {        
        this.SliderContainer.Orientation = value;
        switch (value)
        {
          case Orientation.Horizontal:
            {
              DockPanel.SetDock(this.MinimumValueTextBox, Dock.Left);
              DockPanel.SetDock(this.MaximumValueTextBox, Dock.Right);              
              break;
            }
          case Orientation.Vertical:
            {
              DockPanel.SetDock(this.MinimumValueTextBox, Dock.Top);
              DockPanel.SetDock(this.MaximumValueTextBox, Dock.Bottom);
              break;
            }
        }
      }
    }
  }
}
