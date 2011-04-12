using System.IO;
using System.Linq;
using RWLib;

namespace DFFLib {
    public class FrameListSection : ContainerSection {
        public FrameListStructureSection Structure {
            get { return this.Childs.OfType<FrameListStructureSection>().Single(); }
        }
        public FrameListExtensionSection[] Extensions {
            get { return this.Childs.OfType<FrameListExtensionSection>().ToArray(); }                
        }
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWFrameList; } }
        #endregion
    }

    public class FrameListStructureSection : StructureSection {
        public int FramesCount { get; private set; }
        public Frame[] Frames { get; private set; }
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.FramesCount = br.ReadInt32();
            this.Frames = new Frame[this.FramesCount];
            for (int i = 0; i < this.Frames.Length; i++) {
                this.Frames[i] = new Frame();
                this.Frames[i].LoadFromStream(br);
            }
        }
        #endregion
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWFrameList; } }
        #endregion
    }

    public class FrameListExtensionSection : ExtensionSection {
        public FrameSection Frame {
            get { return this.Childs.OfType<FrameSection>().Single(); }
        }
        #region RWSection
        public static new RWSections ParentSectionType { get { return RWSections.RWFrameList; } }
        #endregion
    }
}
