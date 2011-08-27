using System.IO;
using System.Linq;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class GeometryListSection : ContainerSection
  {
    #region Свойства

    public GeometryStructureSection Structure
    {
      get { return this.Childs.OfType<GeometryStructureSection>().Single(); }
    }

    public GeometrySection[] Geometries
    {
      get { return this.Childs.OfType<GeometrySection>().ToArray(); }
    }

    #region RWSection

    public override RWSections SectionType { get { return RWSections.RWGeometryList; } }

    #endregion

    #endregion
  }

  public class GeometryListStructureSection : StructureSection
  {
    #region Свойства

    public int GeometriesCount { get; private set; }

    #region RWSection

    public static new RWSections ParentSectionType { get { return RWSections.RWGeometryList; } }

    #endregion

    #endregion

    #region Методы

    #region DataSection

    protected override void LoadData(BinaryReader br)
    {
      this.GeometriesCount = br.ReadInt32();
    }

    #endregion

    #endregion
  }

}
