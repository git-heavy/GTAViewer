// -----------------------------------------------------------------------
// <copyright file="TextureWrap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using Heavy.RWLib;

namespace Heavy.TXDLib.Types
{
  public class TextureWrap : IStreamLoadeable
  {
    #region Поля и свойства

    public byte U { get; private set; }

    public byte V { get; private set; }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.U = reader.ReadByte();
      this.V = reader.ReadByte();
    }

    #endregion
  }
}
