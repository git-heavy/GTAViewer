using System.Linq;
using RWLib;

namespace TXDLib {
    public class TextureDictionarySection : ContainerSection {
        public TextureDictionaryStructureSection Structure {
            get {
                return (from c in this.Childs
                        where c.Header.Id == RWSections.RWStruct
                        select c).Single() as TextureDictionaryStructureSection;
            }
        }
        public TextureNativeSection[] TextureNatives {
            get {
                return (from c in this.Childs
                        where c.Header.Id == RWSections.RWTextureNative
                        select c).ToArray() as TextureNativeSection[];
            }
        }
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWTextureDictionary; } }
        #endregion
    }

    public class TextureDictionaryStructureSection : StructureSection {
        public short TextureCount { get; private set; }
        public short Unknown { get; private set; }
        #region DataSection
        protected override void LoadData(System.IO.BinaryReader br) {
            this.TextureCount = br.ReadInt16();
            this.Unknown = br.ReadInt16();
        }
        #endregion
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWTextureDictionary; } }
        #endregion
    }
}
