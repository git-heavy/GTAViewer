using System.IO;
using System.Linq;
using RWLib;

namespace DFFLib {
    public class ClumpSection : ContainerSection
    {
        #region Поля и свойства

        public ClumpStructureSection Structure {
            get { return this.Childs.OfType<ClumpStructureSection>().Single(); }
        }
        public FrameListSection FrameList {
            get { return this.Childs.OfType<FrameListSection>().Single(); }
        }
        public GeometryListSection GeometryList
        {
            get { return this.Childs.OfType<GeometryListSection>().Single(); }
        }
        public AtomicSection[] Atomics
        {
            get { return this.Childs.OfType<AtomicSection>().ToArray<AtomicSection>(); }
        }

        public ClumpExtensionSection Extension {
            get { return this.Childs.OfType<ClumpExtensionSection>().Single(); }
        }

        #endregion

        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWClump; } }
        #endregion
    }

    public class ClumpStructureSection : StructureSection {
        public int ObjectsCount { get; private set; }
        public int LightsCount { get; private set; }
        public int CamerasCount { get; private set; }
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.ObjectsCount = br.ReadInt32();
            this.LightsCount = br.ReadInt32();
            this.CamerasCount = br.ReadInt32();
        }
        #endregion
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWClump; } }
        #endregion
    }

    public class ClumpExtensionSection : ContainerSection {
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWClump; } }
        #endregion
    }

}
