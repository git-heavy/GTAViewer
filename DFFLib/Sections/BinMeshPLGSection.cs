using System.IO;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class BinMeshPLGSection : DataSection
  {
    #region DataSection
    protected override void LoadData(BinaryReader br)
    {
      // Пустой метод.
    }
    #endregion
    #region RWSection
    public static new RWSections SectionType { get { return RWSections.RWBinMeshPLG; } }
    #endregion
  }
}
