// -----------------------------------------------------------------------
// <copyright file="TextureFilterFlags.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Heavy.TXDLib.Types
{
  [FlagsAttribute]
  public enum TextureFilterFlags
  {
    None = 0x00,
    Nearest = 0x01,
    Linear = 0x02,
    MipNearest = 0x03,
    MipLinear = 0x04,
    LinearMipNearest = 0x05,
    LinearMipLinear = 0x06
  }
}
