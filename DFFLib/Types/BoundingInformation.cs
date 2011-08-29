using System.IO;
using Heavy.RWLib;

namespace Heavy.DFFLib.Types
{
  public class BoundingInformation : IStreamLoadeable
  {
    #region Поля и свойства

    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    public float Radius { get; private set; }
    public int HasPosition { get; private set; }
    public int HasNormals { get; private set; }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.X = reader.ReadSingle();
      this.Y = reader.ReadSingle();
      this.Z = reader.ReadSingle();
      this.Radius = reader.ReadSingle();
      this.HasPosition = reader.ReadInt32();
      this.HasNormals = reader.ReadInt32();
    }

    #endregion
  }
}
