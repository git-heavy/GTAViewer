using System.IO;
using System.Linq;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class AtomicSection : ContainerSection
  {
    #region Свойства

    #region RWSection

    public static new RWSections SectionType { get { return RWSections.RWAtomic; } }

    #endregion

    public AtomicStructureSection Structure
    {
      get { return this.Childs.OfType<AtomicStructureSection>().Single(); }
    }

    public AtomicExtensionSection Extension
    {
      get { return this.Childs.OfType<AtomicExtensionSection>().Single(); }
    }

    #endregion
  }

  public class AtomicStructureSection : StructureSection
  {
    #region Свойства

    #region RWSection

    public static new RWSections ParentSectionType { get { return RWSections.RWAtomic; } }

    #endregion

    public int FrameIndex { get; private set; }

    public int GeometryIndex { get; private set; }

    public int Unknown1 { get; private set; }

    public int Unknown2 { get; private set; }

    #endregion

    #region Методы

    #region DataSection

    protected override void LoadData(BinaryReader br)
    {
      this.FrameIndex = br.ReadInt32();
      this.GeometryIndex = br.ReadInt32();
      this.Unknown1 = br.ReadInt32();
      this.Unknown2 = br.ReadInt32();
    }

    #endregion

    #endregion
  }

  public class AtomicExtensionSection : ExtensionSection
  {
    #region Свойства

    #region RWSection

    public static new RWSections ParentSectionType { get { return RWSections.RWAtomic; } }

    #endregion

    #endregion
  }
}