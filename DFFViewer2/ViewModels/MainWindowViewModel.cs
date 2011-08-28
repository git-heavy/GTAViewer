// -----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows.Input;
using Heavy.DFFViewer.Helper;
using Heavy.RWLib;
using Heavy.RWLib.Sections;
using Microsoft.Win32;

namespace Heavy.DFFViewer.ViewModels
{

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class MainWindowViewModel : BaseViewModel
  {
    private ICommand openCommand;

    public ICommand OpenCommand
    {
      get
      {
        if (this.openCommand == null)
          this.openCommand = new BaseCommand(this.OpenCommandExecuted);
        return this.openCommand;
      }
    }

    private void OpenCommandExecuted()
    {
      OpenFileDialog dialog = new OpenFileDialog()
      {
        CheckFileExists = true,
        CheckPathExists = true,
        Multiselect = false,
        DefaultExt = "*.dff"
      };

      if (dialog.ShowDialog().Value)
      {
        RootSection root = SectionLoaderManager.Instance.LoadFromStream(dialog.OpenFile());
        //this.modelViewPort.ModelMetadata = (ClumpSection)root.Childs[0];
      }
    }


    private CameraViewModel cameraViewModel = new CameraViewModel();

    public CameraViewModel CameraViewModel
    {
      get
      {
        return this.cameraViewModel;
      }
    }

    public MainWindowViewModel()
    {
      this.cameraViewModel.PropertyChanged += new PropertyChangedEventHandler(cameraViewModel_PropertyChanged);
    }

    private void cameraViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "Camera") ;
    }

    public ICommand TestCommand { get { return new BaseCommand(this.TestCommandExecuted); } }

    private void TestCommandExecuted()
    {
      ViewService.ShowMessageBox(this.CameraViewModel.Camera.Position.ToString());
    }
  }
}
