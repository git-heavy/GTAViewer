using Heavy.RWLib.Sections;

namespace Heavy.RWLib {      
    class RWSectionLoader: ISectionLoader {
        #region ISectionLoader
        RWSectionFactory ISectionLoader.GetFactory(RWSectionHeader sh, RWSection parent) {            
            switch (sh.Id) {
                case RWSections.RWNull: 
                        return new RWSectionFactory<NullSection>();                                            
                case RWSections.RWExtension: 
                        return new RWSectionFactory<ExtensionSection>();                       
                case RWSections.RWStruct: 
                        return new RWSectionFactory<StructureSection>();                                            
                default:
                        return new RWSectionFactory<UnknownSection>();
            }              
        }
        #endregion
    }
}
