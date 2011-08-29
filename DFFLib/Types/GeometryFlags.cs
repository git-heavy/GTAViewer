// -----------------------------------------------------------------------
// <copyright file="GeometryFlags.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Heavy.DFFLib.Types
{
  [FlagsAttribute]
  public enum GeometryFlags : short
  {
    TriangleStrip = 1,
    VertexTranslation = 2,
    TextureCoordinates1 = 4,
    VertexColors = 8,
    StoreNormals = 16,
    DynamicVertexLighting = 32,
    ModulateMaterialColor = 64,
    TextureCoordinates2 = 128
  }
}
