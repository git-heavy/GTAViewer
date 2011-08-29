using System.IO;
using Heavy.RWLib;
using Heavy.RWLib.Sections;
using Heavy.RWLib.Types;

namespace Heavy.DFFLib.Sections
{
  public class ReflectionMaterialSection : DataSection
  {
    public ColorAmount Amount { get; private set; }
    public float Intensity { get; private set; }
    public int Unknown { get; private set; }
    #region DataSection
    protected override void LoadData(BinaryReader br)
    {
      this.Amount = new ColorAmount();
      this.Amount.LoadFromStream(br);
      this.Intensity = br.ReadSingle();
      this.Unknown = br.ReadInt32();
    }
    #endregion
    #region RWSection
    public override RWSections SectionType { get { return RWSections.RWReflectionmaterial; } }
    #endregion
  }
}
