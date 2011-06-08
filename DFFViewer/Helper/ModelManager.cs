using System.IO;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFViewer.Helper
{
  public class ModelManager
  {
    #region Singleton

    private static ModelManager instance;

    public static ModelManager Instance
    {
      get { return instance ?? (instance = new ModelManager()); }
    }

    #endregion

    #region Конструкторы

    private ModelManager()
    {
      SectionLoaderManager.Instance.RegisterLoader(new DFFLib.DFFSectionLoader());
    }

    #endregion

    #region Методы

    /// <summary>
    /// Загрузить модель из файла.
    /// </summary>
    /// <param name="fileName">Имя файла.</param>
    /// <returns>Корневая секция.</returns>
    public RootSection LoadFile(string fileName)
    {
      using (FileStream fs = new FileStream(fileName, FileMode.Open))
      {
        return SectionLoaderManager.Instance.LoadFromStream(fs);
      }
    }

    #endregion
  }
}
