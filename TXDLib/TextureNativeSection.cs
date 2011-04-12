using System.IO;
using System.Linq;
using RWLib;

namespace TXDLib {
    public class TextureNativeSection: ContainerSection {
        public TextureNativeStructureSection Structure {
            get {
                return (from c in this.Childs
                        where c.Header.Id == RWSections.RWStruct
                        select c).Single() as TextureNativeStructureSection;
            }
        }
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWTextureNative; } }
        #endregion
    }

    public class TextureNativeStructureSection : StructureSection {
        public TextureNativeHeader TextureHeader { get; private set; }
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.TextureHeader = new TextureNativeHeader();
            this.TextureHeader.LoadFromStream(br);
        }
        #endregion
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWTextureNative; } }
        #endregion
    }
}
