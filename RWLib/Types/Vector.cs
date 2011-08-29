// -----------------------------------------------------------------------
// <copyright file="Vector.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Heavy.RWLib.Types
{
  using System.IO;

  /// <summary>
  /// Вектор.
  /// </summary>
  public class Vector : IStreamLoadeable
  {
    #region Поля и свойства

    public float X { get; private set; }

    public float Y { get; private set; }

    public float Z { get; private set; }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.X = reader.ReadSingle();
      this.Y = reader.ReadSingle();
      this.Z = reader.ReadSingle();
    }

    #endregion
  }
}
