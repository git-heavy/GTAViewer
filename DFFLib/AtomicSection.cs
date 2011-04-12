using System.IO;
using System.Linq;
using RWLib;

namespace DFFLib {
    public class AtomicSection : ContainerSection {
        public AtomicStructureSection Structure {
            get { return this.Childs.OfType<AtomicStructureSection>().Single(); }
        }
        public AtomicExtensionSection Extension {
            get { return this.Childs.OfType<AtomicExtensionSection>().Single(); }
        }
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWAtomic; } }
        #endregion
    }

    public class AtomicStructureSection : StructureSection {
        public int FrameIndex { get; private set; }
        public int GeometryIndex { get; private set; }
        public int Unknown1 { get; private set; }
        public int Unknown2 { get; private set; }
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.FrameIndex = br.ReadInt32();
            this.GeometryIndex = br.ReadInt32();
            this.Unknown1 = br.ReadInt32();
            this.Unknown2 = br.ReadInt32();
        }
        #endregion
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWAtomic; } }
        #endregion
    }

    public class AtomicExtensionSection : ExtensionSection {
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWAtomic; } }
        #endregion
    }
}
