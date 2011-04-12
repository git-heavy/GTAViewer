using System.IO;
using RWLib;

namespace DFFLib {
    public class FrameSection : DataSection {
        public string NodeName { get; private set; }
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.NodeName = br.ReadChars(this.Header.Size).ToString();
        }
        #endregion
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWFrame; } }
        #endregion
    }

    public class BinMeshPLGSection : DataSection {
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            // Пустой метод.
        }
        #endregion
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWBinMeshPLG; } }
        #endregion
    }

    public class MaterialEffectsPLGSection : DataSection {
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            // Пустой метод.
        }
        #endregion
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWMaterialEffectsPLG; } }
        #endregion
    }

    public class ReflectionMaterialSection : DataSection {
        public ColorAmount Amount { get; private set; }
        public float Intensity { get; private set; }
        public int Unknown { get; private set; }
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.Amount = new ColorAmount();
            this.Amount.LoadFromStream(br);
            this.Intensity = br.ReadSingle();
            this.Unknown = br.ReadInt32();
        }
        #endregion
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWReflectionmaterial; } }
        #endregion
    }

    public class SpecularMaterialSection : DataSection {
        public float Level { get; private set; }
        /*
         * ? - CHAR[?] - Specular Texture Name, see below. Null-Terminated. Aligned by 4 bytes.
         * 4b - DWORD   - unknown, always 0 (zero)
         */
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            this.Level = br.ReadSingle();
        }
        #endregion
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWSpecularMaterial; } }
        #endregion
    }

    public class UVAnimationPLGSection : DataSection {
        #region DataSection
        protected override void LoadData(BinaryReader br) {
            // Пустой метод.
        }
        #endregion
        #region RWSection
        public static new RWSections SectionType { get { return RWSections.RWUVAnimationPLG; } }
        #endregion
    }
}
