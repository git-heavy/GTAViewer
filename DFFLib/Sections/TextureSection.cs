using System.IO;
using System.Linq;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class TextureSection : ContainerSection
  {
    public TextureStructureSection Structure
    {
      get { return this.Childs.OfType<TextureStructureSection>().Single(); }
    }
    public StringSection TextureName
    {
      get { return this.Childs.OfType<StringSection>().Single(); }
    }
    public StringSection AlphaName
    {
      get { return this.Childs.OfType<StringSection>().ToArray()[1] as StringSection; }
    }
    public TextureExtensionSection Extension
    {
      get { return this.Childs.OfType<TextureExtensionSection>().Single(); }
    }
    #region RWSection
    public override RWSections SectionType { get { return RWSections.RWTexture; } }
    #endregion
  }

  public class TextureStructureSection : StructureSection
  {
    public short FilterFlags { get; private set; }
    public short Unknown { get; private set; }
    #region DataSection
    protected override void LoadData(BinaryReader br)
    {
      this.FilterFlags = br.ReadInt16();
      this.Unknown = br.ReadInt16();
    }
    #endregion
    #region RWSection
    public static new RWSections ParentSectionType { get { return RWSections.RWTexture; } }
    #endregion
  }

  public class TextureExtensionSection : ExtensionSection
  {
    #region RWSection
    public static new RWSections ParentSectionType { get { return RWSections.RWTexture; } }
    #endregion
  }
}
