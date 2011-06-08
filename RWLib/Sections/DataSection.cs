using System.IO;

namespace Heavy.RWLib.Sections
{
  public abstract class DataSection : RWSection, IStreamLoadeable
  {
    #region Методы

    protected abstract void LoadData(BinaryReader br);

    public override void LoadFromStream(BinaryReader br)
    {
      LoadData(br);
      base.LoadFromStream(br);
    }

    #endregion
  }
}
