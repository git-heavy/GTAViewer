using System.Collections.Generic;
using System.IO;

namespace RWLib {     
    public class RWSection : IStreamLoadeable {               
        public RWSectionHeader Header;
        public RWSection Parent;
        public List<RWSection> Childs;
        public RWSection() {
            Childs = new List<RWSection>();
        }
        public static RWSections SectionType { get { return RWSections.RWDefault; } }
        public static RWSections ParentSectionType { get { return RWSections.RWDefault; } }
        #region IStreamLoadeable
        public virtual void LoadFromStream(BinaryReader br) {            
            br.BaseStream.Seek(this.Header.StartPos + this.Header.Size, SeekOrigin.Begin);
        }
        #endregion        
    }
    
    class NullSection : RWSection, IStreamLoadeable {
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWNull; } }
        #endregion
        #region IStreamLoadeable
        public override void LoadFromStream(BinaryReader br) {
            br.BaseStream.Seek(0, SeekOrigin.End);
        }
        #endregion
    }

    public class UnknownSection : RWSection { }

    public class ContainerSection : RWSection {
        #region IStreamLoadeable
        public override void LoadFromStream(BinaryReader br) {
            SectionLoaderManager.Instance.LoadSections(br, this);
            base.LoadFromStream(br);
        }
        #endregion
    }   

    public class StringSection: DataSection {
        public string Data { get; private set; }        
        #region DataSection
        protected override void LoadData(BinaryReader br) {           
            this.Data = System.Text.ASCIIEncoding.ASCII.GetString(br.ReadBytes(this.Header.Size));
        } 
        #endregion
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWString; } }
        #endregion
    }

    public abstract class DataSection : RWSection, IStreamLoadeable {
        protected abstract void LoadData(BinaryReader br);
        #region IStreamLoadeable
        public override void LoadFromStream(BinaryReader br) {
            LoadData(br);
            base.LoadFromStream(br);
        }
        #endregion
    }

    public class StructureSection : DataSection {
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            // Пустой метод.
        }
        #endregion
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWStruct; } }
        #endregion
    }

    public class ExtensionSection : ContainerSection {
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWExtension; } }
        #endregion
    }

    public class RootSection : ContainerSection {
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWRoot; } }
        #endregion
    }    
 
}
