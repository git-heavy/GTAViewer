using System;
using System.IO;
using System.Text;
using RWLib;

namespace TXDLib {
    public struct TextureNativeHeader : IStreamLoadeable {
        public int PlatformID { get; private set; }
        public TextureFilterFlags FilterFlags { get; private set; }
        public TextureWrap Wrap { get; private set; }
        public string TextureName { get; private set; }
        public string AlphaName { get; private set; }
        #region IStreamLoadeable
        public void LoadFromStream(BinaryReader br) {
            this.PlatformID = br.ReadInt32();
            this.FilterFlags = (TextureFilterFlags)br.ReadInt16();
            this.Wrap = new TextureWrap();
            this.Wrap.LoadFromStream(br);
            this.TextureName = ASCIIEncoding.ASCII.GetString(br.ReadBytes(32));
            this.AlphaName = ASCIIEncoding.ASCII.GetString(br.ReadBytes(32));
            
        }
        #endregion
    }

    [FlagsAttribute]
    public enum TextureFilterFlags {
        None = 0x00,
        Nearest = 0x01,
        Linear = 0x02,
        MipNearest = 0x03,
        MipLinear = 0x04,
        LinearMipNearest = 0x05,
        LinearMipLinear = 0x06
    }

    public struct TextureWrap : IStreamLoadeable {
        public byte U;
        public byte V;
        #region IStreamLoadeable
        public void LoadFromStream(BinaryReader br) {
            this.U = br.ReadByte();
            this.V = br.ReadByte();
        }
        #endregion
    }
}
