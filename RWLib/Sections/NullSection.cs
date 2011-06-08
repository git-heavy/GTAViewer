using System.IO;

namespace Heavy.RWLib.Sections
{
  class NullSection : RWSection, IStreamLoadeable
  {
    #region Свойства

    #region RWSection

    public static new RWSections SectionType { get { return RWSections.RWNull; } }

    #endregion

    #endregion

    #region Методы

    public override void LoadFromStream(BinaryReader br)
    {
      br.BaseStream.Seek(0, SeekOrigin.End);
    }

    #endregion
  }
}