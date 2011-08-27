using System.IO;

namespace Heavy.RWLib.Sections
{
  public class ContainerSection : RWSection, IStreamLoadeable
  {
    #region Методы

    public override void LoadFromStream(BinaryReader reader)
    {
      SectionLoaderManager.Instance.LoadSections(reader, this);
      base.LoadFromStream(reader);
    }

    #endregion
  }
}