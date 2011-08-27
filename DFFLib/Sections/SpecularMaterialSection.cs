using System.IO;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class SpecularMaterialSection : DataSection
  {
    public float Level { get; private set; }
    /*
     * ? - CHAR[?] - Specular Texture Name, see below. Null-Terminated. Aligned by 4 bytes.
     * 4b - DWORD   - unknown, always 0 (zero)
     */
    #region DataSection
    protected override void LoadData(BinaryReader br)
    {
      this.Level = br.ReadSingle();
    }
    #endregion
    #region RWSection
    public override RWSections SectionType { get { return RWSections.RWSpecularMaterial; } }
    #endregion
  }
}
