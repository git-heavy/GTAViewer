using System.IO;
using System.Windows.Forms;
using Heavy.DFFViewer.Helper;
using Heavy.DFFViewer.Model;

namespace Heavy.DFFViewer.ViewModel
{
  public class MainWindowViewModel : BaseViewModel
  {
    #region Поля

    private DelegateCommand loadModelCommand;

    private DelegateCommand closeModelCommand;

    private GeometryObjectViewModel geometryViewModel;

    private string fileName;

    #endregion

    #region Свойства

    public DelegateCommand LoadModelCommand
    {
      get { return this.loadModelCommand ?? (this.loadModelCommand = new DelegateCommand(this.LoadModelCommandExecute, this.LoadModelCommandCanExecute)); }
    }

    public DelegateCommand CloseModelCommand
    {
      get { return this.closeModelCommand ?? (this.closeModelCommand = new DelegateCommand(this.CloseModelCommandExecute, this.CloseModelCommandCanExecute)); }
    }

    public GeometryObjectViewModel GeometryViewModel
    {
      get { return this.geometryViewModel; }
      protected set
      {
        this.geometryViewModel = value;
        this.OnPropertyChanged("GeometryViewModel");
      }
    }

    public string FileName
    {
      get { return this.fileName; }
      private set
      {
        if (string.Compare(this.fileName, value, true) != 0)        
        {
          this.fileName = value;
          this.GeometryViewModel = File.Exists(this.fileName) ? new GeometryObjectViewModel(new GeometryObject(ModelManager.Instance.LoadFile(this.fileName))) : null;
          this.OnPropertyChanged("FileName");
          this.OnPropertyChanged("Name");
        }
      }
    }

    #region BaseViewModel

    public override string Name
    {
      get
      {
        return string.Format("Главное окно {0} {1}", string.IsNullOrEmpty(this.FileName) ? string.Empty : "-", System.IO.Path.GetFileName(this.FileName)).Trim();
      }
    }

    #endregion

    #endregion

    #region Методы

    private void LoadModelCommandExecute(object parameter)
    {      
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        dialog.Filter = (@"DFF files (*.dff)|*.dff|All files (*.*)|*.*");
        dialog.Multiselect = false;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
          // TODO: Изменения не подхватываются автоматически, поэтому сначала присваиваем null.
          this.FileName = string.Empty;
          this.FileName = dialog.FileName;
        }
      }
    }

    private bool LoadModelCommandCanExecute(object parameter)
    {
      return true;
    }

    private void CloseModelCommandExecute(object parameter)
    {
      this.FileName = string.Empty;
    }

    private bool CloseModelCommandCanExecute(object parameter)
    {
      return !string.IsNullOrEmpty(this.FileName);
    }

    #endregion
  }
}
