// -----------------------------------------------------------------------
// <copyright file="GeometryTriangle.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using Heavy.RWLib;

namespace Heavy.DFFLib.Types
{
  public class GeometryTriangle : IStreamLoadeable
  {
    #region Поля и свойства

    public short First { get; private set; }

    public short Second { get; private set; }

    public short Third { get; private set; }

    public short UseLine { get; private set; }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.First = reader.ReadInt16();
      this.Second = reader.ReadInt16();
      this.UseLine = reader.ReadInt16();
      this.Third = reader.ReadInt16();
    }

    #endregion
  }
}
