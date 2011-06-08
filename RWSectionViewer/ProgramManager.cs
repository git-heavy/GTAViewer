using System;
using System.IO;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.RWSectionViewer {
    class ProgramManager {
        #region Singleton Implementation
        private static ProgramManager _instance;
        public static ProgramManager Instance {
            get {
                if (_instance == null) {
                    _instance = new ProgramManager();
                }
                return _instance;
            }
        }
        #endregion

        private RootSection _root;
        private RWSection _currentSection;
        public RootSection Root {
            get {
                return _root;
            }
        }
        public RWSection CurrentSection {
            get {
                return _currentSection;
            }
            set {
                if (_currentSection != value) {
                    _currentSection = value;
                    if (CurrentSectionChangeEvent != null) {
                        CurrentSectionChangeEvent(this, new EventArgs());
                    }
                }                
            }
        }

        public void LoadFile(string fileName) {
            using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
                _root = SectionLoaderManager.Instance.LoadFromStream(fs);
                if (FileLoadedEvent != null) {
                    FileLoadedEvent(this, new EventArgs());
                }
            }
        }

        public event EventHandler CurrentSectionChangeEvent;
        public event EventHandler FileLoadedEvent;
    }
}
