using System.IO;
using System.Linq;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class ClumpSection : ContainerSection
  {
    #region Свойства

    #region RWSection

    public static new RWSections SectionType { get { return RWSections.RWClump; } }

    #endregion

    public ClumpStructureSection Structure
    {
      get { return this.Childs.OfType<ClumpStructureSection>().Single(); }
    }

    public FrameListSection FrameList
    {
      get { return this.Childs.OfType<FrameListSection>().Single(); }
    }

    public GeometryListSection GeometryList
    {
      get { return this.Childs.OfType<GeometryListSection>().Single(); }
    }

    public AtomicSection[] Atomics
    {
      get { return this.Childs.OfType<AtomicSection>().ToArray<AtomicSection>(); }
    }

    public ClumpExtensionSection Extension
    {
      get { return this.Childs.OfType<ClumpExtensionSection>().Single(); }
    }

    #endregion
  }

  public class ClumpStructureSection : StructureSection
  {
    #region Свойства

    public int ObjectsCount { get; private set; }

    public int LightsCount { get; private set; }

    public int CamerasCount { get; private set; }

    #region RWSection

    public static new RWSections ParentSectionType { get { return RWSections.RWClump; } }

    #endregion

    #endregion

    #region Методы

    #region DataSection

    protected override void LoadData(BinaryReader br)
    {
      this.ObjectsCount = br.ReadInt32();
      this.LightsCount = br.ReadInt32();
      this.CamerasCount = br.ReadInt32();
    }

    #endregion

    #endregion
  }

  public class ClumpExtensionSection : ContainerSection
  {
    #region Свойства

    #region RWSection

    public static new RWSections ParentSectionType { get { return RWSections.RWClump; } }

    #endregion

    #endregion
  }
}