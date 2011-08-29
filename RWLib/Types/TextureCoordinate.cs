// -----------------------------------------------------------------------
// <copyright file="TextureCoordinate.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
namespace Heavy.RWLib.Types
{
  /// <summary>
  /// Координаты текстуры.
  /// </summary>
  public class TextureCoordinate : IStreamLoadeable
  {
    #region Поля и свойства

    public float U { get; private set; }

    public float V { get; private set; }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.U = reader.ReadSingle();
      this.V = reader.ReadSingle();
    }

    #endregion
  }
}
