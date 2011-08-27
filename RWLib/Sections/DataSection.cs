using System.IO;

namespace Heavy.RWLib.Sections
{
  public abstract class DataSection : RWSection, IStreamLoadeable
  {
    #region Методы

    protected abstract void LoadData(BinaryReader reader);

    public override void LoadFromStream(BinaryReader reader)
    {
      LoadData(reader);
      base.LoadFromStream(reader);
    }

    #endregion
  }
}
