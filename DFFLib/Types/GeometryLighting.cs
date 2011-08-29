// -----------------------------------------------------------------------
// <copyright file="GeometryLighting.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using Heavy.RWLib;

namespace Heavy.DFFLib.Types
{
  public class GeometryLighting : IStreamLoadeable
  {
    #region Поля и свойства

    public int Ambient { get; private set; }

    public int Diffuse { get; private set; }

    public int Specular { get; private set; }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.Ambient = reader.ReadInt32();
      this.Diffuse = reader.ReadInt32();
      this.Specular = reader.ReadInt32();
    }

    #endregion
  }
}
