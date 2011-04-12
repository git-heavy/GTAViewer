using System;
using System.IO;
using RWLib;

namespace DFFViewer
{
    class ModelManager
    {
        #region Singleton Implementation
        private static ModelManager _instance;
        public static ModelManager Instance
        {
            get
            {
                if (_instance == null)                
                    _instance = new ModelManager();                        
                return _instance;
            }
        }
        #endregion

        #region Конструкторы

        private ModelManager()
        {
            SectionLoaderManager.Instance.RegisterLoader(new DFFLib.DFFSectionLoader());
        }

        #endregion

        #region Поля и свойства

        private RootSection _root;        

        private RWSection _currentSection;

        public RootSection Root { get { return _root; } }

        private RWSection CurrentSection
        {
            get { return _currentSection; }
            set
            {
                if (_currentSection != value)
                {
                    _currentSection = value;
                    if (CurrentSectionChangeEvent != null)
                        CurrentSectionChangeEvent(this, new EventArgs());
                }
            }
        }

        #endregion

        #region Методы
        
        public void LoadFile(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                _root = SectionLoaderManager.Instance.LoadFromStream(fs);
                if (FileLoadedEvent != null)                
                    FileLoadedEvent(this, new EventArgs());               
            }
        }

        #endregion

        #region События

        private event EventHandler CurrentSectionChangeEvent;
        public event EventHandler FileLoadedEvent;

        #endregion
    }

}
