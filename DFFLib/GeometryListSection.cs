using System.IO;
using System.Linq;
using RWLib;

namespace DFFLib {
    public class GeometryListSection : ContainerSection {
        public GeometryStructureSection Structure {
            get { return this.Childs.OfType<GeometryStructureSection>().Single(); }            
        }
        public GeometrySection[] Geometries {
            get { return this.Childs.OfType<GeometrySection>().ToArray(); }
        }
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWGeometryList; } }
        #endregion
    }

    public class GeometryListStructureSection : StructureSection {
        public int GeometriesCount { get; private set; }
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.GeometriesCount = br.ReadInt32();
        }
        #endregion
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWGeometryList; } }
        #endregion
    }

}
