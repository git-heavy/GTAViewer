using System.IO;

namespace Heavy.RWLib.Sections
{
  public class ContainerSection : RWSection, IStreamLoadeable
  {
    #region Методы

    public override void LoadFromStream(BinaryReader br)
    {
      SectionLoaderManager.Instance.LoadSections(br, this);
      base.LoadFromStream(br);
    }

    #endregion
  }
}