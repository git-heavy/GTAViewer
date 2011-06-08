using Heavy.RWLib;
using Heavy.RWLib.Sections;
using Heavy.TXDLib.Sections;

namespace Heavy.TXDLib {
    class TXDSectionLoader: ISectionLoader {
        #region ISectionLoader
        RWSectionFactory ISectionLoader.GetFactory(RWSectionHeader sh, RWSection parent) {
            switch (sh.Id) {
                case RWSections.RWStruct:
                    switch (parent.Header.Id) {
                        case RWSections.RWTextureDictionary:
                            return new RWSectionFactory<TextureDictionaryStructureSection>();
                        case RWSections.RWTextureNative:
                            return new RWSectionFactory<TextureNativeStructureSection>();
                        default:
                            return null;
                    }
                case RWSections.RWExtension:
                    switch (parent.Header.Id) {
                        default:
                            return null;
                    }
                case RWSections.RWTextureDictionary:
                    return new RWSectionFactory<TextureDictionarySection>();
                case RWSections.RWTextureNative:
                    return new RWSectionFactory<TextureNativeSection>();
                default:
                    return null;
            }
        }
        #endregion
    }
}
