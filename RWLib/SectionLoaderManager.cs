using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RWLib {
    public class SectionLoaderManager {
        public SectionLoaderManager() {
            _loaders = new List<ISectionLoader>();            
        }
        #region Singleton Implementation
        private static SectionLoaderManager _instance;
        public static SectionLoaderManager Instance {
            get {
                if (_instance == null) {
                    _instance = new SectionLoaderManager();
                }
                return _instance;
            }
        }
        #endregion
                             
        private List<ISectionLoader> _loaders;

        public void RegisterLoader(ISectionLoader sectionLoader) {
            _loaders.Add(sectionLoader);
        }

        private RWSectionFactory GetFactory(RWSectionHeader sh, RWSection parent) {
            RWSectionFactory factory = null;
            foreach (ISectionLoader loader in _loaders) {
                factory = loader.GetFactory(sh, parent);
                if (factory != null) {
                    return factory;
                }
            }            
            return (new RWSectionLoader() as ISectionLoader).GetFactory(sh, parent);            
        }
        
        private RWSection LoadSection(BinaryReader br, RWSection parentSection) {
            RWSectionHeader sh = new RWSectionHeader();
            sh.LoadFromStream(br);            
            RWSection section = this.GetFactory(sh, parentSection).GetSection(br, sh);
            if ((section is UnknownSection) && IsContainerSection(br, sh, parentSection)) {
                section = new RWSectionFactory<ContainerSection>().GetSection(br, sh);
            }
            return section;
        }

        private bool IsContainerSection(BinaryReader br, RWSectionHeader sh, RWSection parent) {
            br.BaseStream.Seek(sh.StartPos, SeekOrigin.Begin);
            if (sh.Size > 12) {
                RWSectionHeader newHeader = new RWSectionHeader();
                newHeader.LoadFromStream(br);
                if ((newHeader.Version == sh.Version) && (newHeader.Size < sh.Size)) {
                    br.BaseStream.Seek(sh.StartPos, SeekOrigin.Begin);
                    return true;
                }
            }
            br.BaseStream.Seek(sh.StartPos + sh.Size, SeekOrigin.Begin);
            return false;
        }

        internal void LoadSections(BinaryReader br, RWSection parentSection) {
            while (br.BaseStream.Position < parentSection.Header.StartPos + parentSection.Header.Size) {
                RWSection section = LoadSection(br, parentSection);
                if (section != null) {
                    section.Parent = parentSection;
                    parentSection.Childs.Add(section);
                }
            }
        }

        public RootSection LoadFromStream(FileStream fs) {
            fs.Seek(0, SeekOrigin.Begin);
            using (BinaryReader br = new BinaryReader(fs)) {
                RootSection rootSection = new RootSectionFactory().GetSection(br, RWSectionHeader.GetRootHeader(br)) as RootSection;
                LoadSections(br, rootSection);
                return rootSection;
            }
        }
    }
}
