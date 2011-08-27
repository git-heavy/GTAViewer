using Heavy.DFFLib.Sections;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib
{
  public class DFFSectionLoader : ISectionLoader
  {
    #region ISectionLoader

    public IRWSectionFactory GetFactory(RWSectionHeader header, RWSection parent)
    {
      switch (header.Id)
      {
        case RWSections.RWExtension:
          switch (parent.Header.Id)
          {
            case RWSections.RWAtomic:
              return new RWSectionFactory<AtomicExtensionSection>();
            case RWSections.RWClump:
              return new RWSectionFactory<ClumpExtensionSection>();
            case RWSections.RWFrameList:
              return new RWSectionFactory<FrameListExtensionSection>();
            case RWSections.RWGeometry:
              return new RWSectionFactory<GeometryExtensionSection>();
            case RWSections.RWMaterial:
              return new RWSectionFactory<MaterialExtensionSection>();
            case RWSections.RWTexture:
              return new RWSectionFactory<TextureExtensionSection>();
            default:
              return null;
          }
        case RWSections.RWStruct:
          switch (parent.Header.Id)
          {
            case RWSections.RWAtomic:
              return new RWSectionFactory<AtomicStructureSection>();
            case RWSections.RWClump:
              return new RWSectionFactory<ClumpStructureSection>();
            case RWSections.RWFrameList:
              return new RWSectionFactory<FrameListStructureSection>();
            case RWSections.RWGeometryList:
              return new RWSectionFactory<GeometryListStructureSection>();
            case RWSections.RWGeometry:
              return new RWSectionFactory<GeometryStructureSection>();
            case RWSections.RWMaterialList:
              return new RWSectionFactory<MaterialListStructureSection>();
            case RWSections.RWMaterial:
              return new RWSectionFactory<MaterialStructureSection>();
            case RWSections.RWTexture:
              return new RWSectionFactory<TextureStructureSection>();
            default:
              return null;
          }
        case RWSections.RWAtomic:
          return new RWSectionFactory<AtomicSection>();
        case RWSections.RWClump:
          return new RWSectionFactory<ClumpSection>();
        case RWSections.RWFrameList:
          return new RWSectionFactory<FrameListSection>();
        case RWSections.RWGeometryList:
          return new RWSectionFactory<GeometryListSection>();
        case RWSections.RWGeometry:
          return new RWSectionFactory<GeometrySection>();
        case RWSections.RWMaterialList:
          return new RWSectionFactory<MaterialListSection>();
        case RWSections.RWMaterial:
          return new RWSectionFactory<MaterialSection>();
        case RWSections.RWTexture:
          return new RWSectionFactory<TextureSection>();
        case RWSections.RWFrame:
          return new RWSectionFactory<FrameSection>();
        case RWSections.RWBinMeshPLG:
          return new RWSectionFactory<BinMeshPLGSection>();
        case RWSections.RWMaterialEffectsPLG:
          return new RWSectionFactory<MaterialEffectsPLGSection>();
        case RWSections.RWReflectionmaterial:
          return new RWSectionFactory<ReflectionMaterialSection>();
        case RWSections.RWSpecularMaterial:
          return new RWSectionFactory<SpecularMaterialSection>();
        case RWSections.RWUVAnimationPLG:
          return new RWSectionFactory<UVAnimationPLGSection>();
        default:
          return null;
      }
    }

    #endregion
  }
}
