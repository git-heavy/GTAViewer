using System;
using System.IO;

namespace Heavy.RWLib {

    public enum RWSections {
        RWRoot = -2,
        RWDefault = -1,
        RWNull = 0x0000,
        RWStruct = 0x0001,
        RWString = 0x0002,
        RWExtension = 0x0003,
        RWCamera = 0x0005,
        RWTexture = 0x0006,
        RWMaterial = 0x0007,
        RWMaterialList = 0x0008,
        RWAtomicSection = 0x0009,
        RWPlane = 0x000A,
        RWWorld = 0x000B,
        RWSpline = 0x000C,
        RWMatrix = 0x000D,
        RWFrameList = 0x000E,
        RWGeometry = 0x000F,
        RWClump = 0x0010,
        RWLight = 0x0012,
        RWUnicodeString = 0x0013,
        RWAtomic = 0x0014,
        RWTextureNative = 0x0015,
        RWTextureDictionary = 0x0016,
        RWAnimationDatabase = 0x0017,
        RWImage = 0x0018,
        RWSkinAnimation = 0x0019,
        RWGeometryList = 0x001A,
        RWAnimAnimation = 0x001B,
        RWTeam = 0x001C,
        RWCrowd = 0x001D,
        RWDeltaMorphAnimation = 0x001E,
        RWRightToRender = 0x001F,
        RWHAnimPLG = 0x011E,
        RWMaterialEffectsPLG = 0x0120,
        RWUVAnimationPLG = 0x0135,
        RWBinMeshPLG = 0x050E,
        RWZModelerLock = 0xF21E,
        RWAtomicVisibilityDistance = 0x0253F200,
        RWClumpVisibilityDistance = 0x0253F201,
        RWFrameVisibilityDistance = 0x0253F202,        
        RWPipelineSet = 0x0253F2F3,
        RWTexDictionaryLink = 0x0253F2F5,
        RWSpecularMaterial = 0x0253F2F6,
        RW2dfx = 0x0253F2F8,
        RWNightVertexColors = 0x0253F2F9,
        RWCollisionModel = 0x0253F2FA,
        RWGTAHAnim = 0x0253F2FB,
        RWReflectionmaterial = 0x0253F2FC,
        RWMeshExtension = 0x0253F2FD,
        RWFrame = 0x0253F2FE
    }

    public enum RWVersions {
        v30 = 0x0003FFFF,
        v305 = 0x0800FFFF,
        v31 = 0x00000310,
        v33 = 0x0C02FFFF,
        v34 = 0x1003FFFF,
        v36 = 0x1803FFFF
    }

    public struct RWSectionHeader : IStreamLoadeable {
        public RWSections Id { get; private set; }
        public long StartPos { get; private set; }
        public int Size { get; private set; }
        public RWVersions Version { get; private set; }
        public static RWSectionHeader GetRootHeader(BinaryReader br) {
            RWSectionHeader sh = new RWSectionHeader();
            sh.Id = RWSections.RWRoot;
            sh.StartPos = 0;
            sh.Size = (int)br.BaseStream.Length;
            return sh;
        }
        #region IStreamLoadeable
        public void LoadFromStream(BinaryReader br) {
            this.Id = (RWSections)br.ReadInt32();
            this.Size = br.ReadInt32();
            this.Version = (RWVersions)br.ReadInt32();
            this.StartPos = br.BaseStream.Position;
        }
        #endregion
        #region Object
        public override string ToString() {
            return String.Format("Section: ID={0}({4}) Size={1} Version={2} StartPos={3}", this.Id, this.Size, this.Version, this.StartPos, (int)this.Id);
        }
        #endregion
    }
}
