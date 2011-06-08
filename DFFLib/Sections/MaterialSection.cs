using System.IO;
using System.Linq;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class MaterialSection : ContainerSection
  {
    public MaterialStructureSection Structure
    {
      get { return this.Childs.OfType<MaterialStructureSection>().Single(); }
    }
    public TextureSection[] Textures
    {
      get { return this.Childs.OfType<TextureSection>().ToArray(); }
    }
    public MaterialExtensionSection Extension
    {
      get { return this.Childs.OfType<MaterialExtensionSection>().Single(); }
    }
    #region RWSection
    public static new RWSections SectionType { get { return RWSections.RWMaterial; } }
    #endregion
  }

  public class MaterialStructureSection : StructureSection
  {
    public int Unknown1 { get; private set; }
    public int Color { get; private set; }
    public int Unknown2 { get; private set; }
    public int TexturesCount { get; private set; }
    public Vector UnknownVector { get; private set; }
    #region DataSection
    protected override void LoadData(BinaryReader br)
    {
      this.Unknown1 = br.ReadInt32();
      this.Color = br.ReadInt32();
      this.Unknown2 = br.ReadInt32();
      this.TexturesCount = br.ReadInt32();
      this.UnknownVector = new Vector();
      this.UnknownVector.LoadFromStream(br);
    }
    #endregion
    #region RWSection
    public static new RWSections ParentSectionType { get { return RWSections.RWMaterial; } }
    #endregion
  }

  public class MaterialExtensionSection : ExtensionSection
  {
    public MaterialEffectsPLGSection MaterialEffectsPLG
    {
      get { return this.Childs.OfType<MaterialEffectsPLGSection>().Single(); }
    }
    public ReflectionMaterialSection ReflectionMaterial
    {
      get { return this.Childs.OfType<ReflectionMaterialSection>().Single(); }
    }
    public SpecularMaterialSection SpecularMaterial
    {
      get { return this.Childs.OfType<SpecularMaterialSection>().Single(); }
    }
    public UVAnimationPLGSection UVAnimationPLG
    {
      get { return this.Childs.OfType<UVAnimationPLGSection>().Single(); }
    }
    #region RWSection
    public static new RWSections ParentSectionType { get { return RWSections.RWMaterial; } }
    #endregion
  }
}
