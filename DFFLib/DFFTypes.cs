using System;
using System.IO;
using Heavy.RWLib;

namespace Heavy.DFFLib
{
  public class Frame : IStreamLoadeable
  {
    public Vector[] RotationMatrix;
    public Vector Position;
    public int FrameIndex;
    public int Flags;
    public Frame()
    {
      this.RotationMatrix = new Vector[3];
      this.Position = new Vector();
    }
    #region IStreamLoadeable
    public void LoadFromStream(BinaryReader br)
    {
      foreach (Vector vct in this.RotationMatrix)
      {
        vct.LoadFromStream(br);
      }
      this.Position.LoadFromStream(br);
      this.FrameIndex = br.ReadInt32();
      this.Flags = br.ReadInt32();
    }
    #endregion
  }

  public class GeometryLighting : IStreamLoadeable
  {
    public int Ambient { get; private set; }
    public int Diffuse { get; private set; }
    public int Specular { get; private set; }
    #region IStreamLoadeable
    public void LoadFromStream(BinaryReader br)
    {
      this.Ambient = br.ReadInt32();
      this.Diffuse = br.ReadInt32();
      this.Specular = br.ReadInt32();
    }
    #endregion
  }

  [FlagsAttribute]
  public enum GeometryFlags : short
  {
    TriangleStrip = 1,
    VertexTranslation = 2,
    TextureCoordinates1 = 4,
    VertexColors = 8,
    StoreNormals = 16,
    DynamicVertexLighting = 32,
    ModulateMaterialColor = 64,
    TextureCoordinates2 = 128
  }

  public struct GeometryTriangle : IStreamLoadeable
  {
    public short First;
    public short Second;
    public short Third;
    public short UseLine;
    #region IStreamLoadeable
    public void LoadFromStream(BinaryReader br)
    {
      this.First = br.ReadInt16();
      this.Second = br.ReadInt16();
      this.UseLine = br.ReadInt16();
      this.Third = br.ReadInt16();
    }
    #endregion
  }

  public struct BoundingInformation : IStreamLoadeable
  {
    public float X;
    public float Y;
    public float Z;
    public float Radius;
    public int HasPosition;
    public int HasNormals;
    #region IStreamLoadeable
    public void LoadFromStream(BinaryReader br)
    {
      this.X = br.ReadSingle();
      this.Y = br.ReadSingle();
      this.Z = br.ReadSingle();
      this.Radius = br.ReadSingle();
      this.HasPosition = br.ReadInt32();
      this.HasNormals = br.ReadInt32();
    }
    #endregion
  }
}
