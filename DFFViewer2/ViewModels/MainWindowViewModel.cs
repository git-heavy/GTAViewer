// -----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows.Input;
using Heavy.DFFLib.Sections;
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
        this.Scene.ModelGroupMetadata = (ClumpSection)root.Childs[0];
      }
    }

    private ICommand testCommand;

    public ICommand TestCommand
    {
      get
      {
        if (this.testCommand == null)
          this.testCommand = new BaseCommand(this.TestCommandExecuted);
        return this.testCommand;
      }
    }

    private void TestCommandExecuted()
    {
      ViewService.ShowMessageBox(this.Scene.ModelGroup.ToString());
    }

    private SceneViewModel scene = new SceneViewModel();

    public SceneViewModel Scene
    {
      get { return this.scene; }
    }

    private CameraViewModel camera = new CameraViewModel();

    public CameraViewModel Camera
    {
      get { return this.camera; }
    }

    public MainWindowViewModel()
    {
      SectionLoaderManager.Instance.RegisterLoader(new DFFLib.DFFSectionLoader());

      this.camera.PropertyChanged += new PropertyChangedEventHandler(camera_PropertyChanged);
      this.scene.PropertyChanged += new PropertyChangedEventHandler(scene_PropertyChanged);
    }

    private void scene_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.OnPropertyChanged(() => Scene);
    }

    private void camera_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      this.OnPropertyChanged(() => Camera);
    }
  }
}
