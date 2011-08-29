// -----------------------------------------------------------------------
// <copyright file="TextureNativeHeader.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Text;
using Heavy.RWLib;

namespace Heavy.TXDLib.Types
{
  public class TextureNativeHeader : IStreamLoadeable
  {
    #region Поля и свойства

    public int PlatformID { get; private set; }

    public TextureFilterFlags FilterFlags { get; private set; }

    public TextureWrap Wrap { get; private set; }

    public string TextureName { get; private set; }

    public string AlphaName { get; private set; }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.PlatformID = reader.ReadInt32();
      this.FilterFlags = (TextureFilterFlags)reader.ReadInt16();
      this.Wrap = new TextureWrap();
      this.Wrap.LoadFromStream(reader);
      this.TextureName = ASCIIEncoding.ASCII.GetString(reader.ReadBytes(32));
      this.AlphaName = ASCIIEncoding.ASCII.GetString(reader.ReadBytes(32));
    }

    #endregion
  }
}
