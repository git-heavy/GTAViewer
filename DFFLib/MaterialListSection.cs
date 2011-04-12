using System.IO;
using System.Linq;
using RWLib;

namespace DFFLib {
    public class MaterialListSection : ContainerSection {
        public MaterialListStructureSection Structure {
            get { return this.Childs.OfType<MaterialListStructureSection>().Single(); }
        }
        public MaterialSection[] Materials {
            get { return this.Childs.OfType<MaterialSection>().ToArray(); }
        }
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWMaterialList; } }
        #endregion
    }

    public class MaterialListStructureSection : StructureSection {
        public int MaterialCount { get; private set; }
        public int[] Unknown1 { get; private set; }
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.MaterialCount = br.ReadInt32();
            this.Unknown1 = new int[this.MaterialCount];
            for (int i = 0; i < this.Unknown1.Length; i++) {
                this.Unknown1[i] = br.ReadInt32();
            }
        }
        #endregion
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWMaterialList; } }
        #endregion
    }
}
