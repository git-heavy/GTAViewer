using System.IO;
using Heavy.RWLib.Sections;

namespace Heavy.RWLib {

    public interface IStreamLoadeable {
        void LoadFromStream(BinaryReader br);
    }

    public interface ISectionLoader {
        RWSectionFactory GetFactory(RWSectionHeader sh, RWSection parent);
    }


    public struct Vector : IStreamLoadeable {
        public float X;
        public float Y;
        public float Z;
        #region IStreamLoadeable
        public void LoadFromStream(BinaryReader br) {
            this.X = br.ReadSingle();
            this.Y = br.ReadSingle();
            this.Z = br.ReadSingle();
        }
        #endregion
    }    

    public struct ColorAmount : IStreamLoadeable {
        public float R;
        public float G;
        public float B;
        public float A;
        #region IStreamLoadeable
        public void LoadFromStream(BinaryReader br) {
            this.R = br.ReadSingle();
            this.G = br.ReadSingle();
            this.B = br.ReadSingle();
            this.A = br.ReadSingle();
        }
        #endregion
    }

    public struct TextureCoordinate : IStreamLoadeable {
        public float U;
        public float V;
        #region IStreamLoadeable
        public void LoadFromStream(BinaryReader br) {
            this.U = br.ReadSingle();
            this.V = br.ReadSingle();
        }
        #endregion
    } 
}
