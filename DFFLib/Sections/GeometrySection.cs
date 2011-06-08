using System.IO;
using System.Linq;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class GeometrySection : ContainerSection
  {
    #region Свойства

    public GeometryStructureSection Structure
    {
      get { return this.Childs.OfType<GeometryStructureSection>().Single(); }
    }

    public MaterialListSection MaterialList
    {
      get { return this.Childs.OfType<MaterialListSection>().Single(); }
    }

    public GeometryExtensionSection Extension
    {
      get { return this.Childs.OfType<GeometryExtensionSection>().Single(); }
    }

    #region RWSection

    public static new RWSections SectionType { get { return RWSections.RWGeometry; } }

    #endregion

    #endregion
  }

  public class GeometryStructureSection : StructureSection
  {
    #region Свойства

    public GeometryFlags Flags { get; private set; }

    public byte UVCoordinatesCount { get; private set; }

    public byte Unknown1 { get; private set; }

    public int TriangleCount { get; private set; }

    public int VertexCount { get; private set; }

    public int FrameCount { get; private set; }

    public GeometryLighting Lighting { get; private set; }

    public int[] VertexColors { get; private set; }

    public TextureCoordinate[] TextureCoordinates1 { get; private set; }

    public TextureCoordinate[] TextureCoordinates2 { get; private set; }

    public GeometryTriangle[] Triangles { get; private set; }

    public BoundingInformation Bounding { get; private set; }

    public Vector[] VertexTranslation { get; private set; }

    public Vector[] Normals { get; private set; }

    #region RWSection

    public static new RWSections ParentSectionType { get { return RWSections.RWGeometry; } }

    #endregion

    #endregion

    #region Методы

    #region DataSection

    protected override void LoadData(BinaryReader br)
    {
      this.Flags = (GeometryFlags)br.ReadInt16();
      this.UVCoordinatesCount = br.ReadByte();
      this.Unknown1 = br.ReadByte();
      this.TriangleCount = br.ReadInt32();
      this.VertexCount = br.ReadInt32();
      this.FrameCount = br.ReadInt32();
      if ((int)this.Header.Version < 0x1000FFFF)
      {
        this.Lighting = new GeometryLighting();
        this.Lighting.LoadFromStream(br);
      }
      if ((this.Flags & GeometryFlags.VertexColors) == GeometryFlags.VertexColors)
      {
        this.VertexColors = new int[this.VertexCount];
        for (int i = 0; i < this.VertexCount; i++)
        {
          this.VertexColors[i] = br.ReadInt32();
        }
      }
      if ((this.Flags & GeometryFlags.TextureCoordinates1) == GeometryFlags.TextureCoordinates1)
      {
        TextureCoordinates1 = new TextureCoordinate[this.VertexCount];
        for (int i = 0; i < this.TextureCoordinates1.Length; i++)
        {
          this.TextureCoordinates1[i] = new TextureCoordinate();
          this.TextureCoordinates1[i].LoadFromStream(br);
        }
      }
      if ((this.Flags & GeometryFlags.TextureCoordinates2) == GeometryFlags.TextureCoordinates2)
      {
        TextureCoordinates2 = new TextureCoordinate[this.VertexCount];
        for (int i = 0; i < this.TextureCoordinates2.Length; i++)
        {
          this.TextureCoordinates2[i] = new TextureCoordinate();
          this.TextureCoordinates2[i].LoadFromStream(br);
        }
      }
      this.Triangles = new GeometryTriangle[this.TriangleCount];
      for (int i = 0; i < this.Triangles.Length; i++)
      {
        this.Triangles[i] = new GeometryTriangle();
        this.Triangles[i].LoadFromStream(br);
      }
      this.Bounding = new BoundingInformation();
      this.Bounding.LoadFromStream(br);
      if ((this.Flags & GeometryFlags.VertexTranslation) == GeometryFlags.VertexTranslation)
      {
        this.VertexTranslation = new Vector[this.VertexCount];
        for (int i = 0; i < this.VertexTranslation.Length; i++)
        {
          this.VertexTranslation[i] = new Vector();
          this.VertexTranslation[i].LoadFromStream(br);
        }
      }
      if ((this.Flags & GeometryFlags.StoreNormals) == GeometryFlags.StoreNormals)
      {
        this.Normals = new Vector[this.VertexCount];
        for (int i = 0; i < this.Normals.Length; i++)
        {
          this.Normals[i] = new Vector();
          this.Normals[i].LoadFromStream(br);
        }
      }
    }

    #endregion

    #endregion
  }

  public class GeometryExtensionSection : ExtensionSection
  {
    #region Свойства

    public BinMeshPLGSection BinMeshPLG
    {
      get { return this.Childs.OfType<BinMeshPLGSection>().Single(); }
    }

    /*
     * Native Data PLG (on Xbox and PS2)
     * Skin PLG
     * Mesh Extension - optional
     * Night Vertex Colors - optional (static objects only)
     * Morph PLG
     * 2dfx - optional
     */

    #region RWSection

    public static new RWSections ParentSectionType { get { return RWSections.RWGeometry; } }

    #endregion

    #endregion
  }
}