using System.IO;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class MaterialEffectsPLGSection : DataSection
  {
    #region DataSection
    protected override void LoadData(BinaryReader br)
    {
      // Пустой метод.
    }
    #endregion
    #region RWSection
    public override RWSections SectionType { get { return RWSections.RWMaterialEffectsPLG; } }
    #endregion
  }
}
