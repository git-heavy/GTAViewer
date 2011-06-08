using Heavy.DFFLib.Sections;
using Heavy.RWLib.Sections;

namespace Heavy.DFFViewer.Model
{
  public class GeometryObject: Entity
  {
    #region Поля

    private RootSection root;

    #endregion

    #region Свойства

    public ClumpSection Clump
    {
      get { return this.root.Childs[0] as ClumpSection; }
    }

    #endregion

    #region Конструкторы

    public GeometryObject(RootSection root)
      : base()
    {
      this.root = root;
    }

    #endregion
  }
}
