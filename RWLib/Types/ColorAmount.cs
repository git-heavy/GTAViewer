// -----------------------------------------------------------------------
// <copyright file="ColorAmount.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;

namespace Heavy.RWLib.Types
{
  /// <summary>
  /// Цвет.
  /// </summary>
  public class ColorAmount : IStreamLoadeable
  {
    #region Поля и свойства

    public float R { get; private set; }

    public float G { get; private set; }

    public float B { get; private set; }

    public float A { get; private set; }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.R = reader.ReadSingle();
      this.G = reader.ReadSingle();
      this.B = reader.ReadSingle();
      this.A = reader.ReadSingle();
    }

    #endregion
  }
}
