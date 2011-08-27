using System.IO;

namespace Heavy.RWLib.Sections
{
  class NullSection : RWSection, IStreamLoadeable
  {
    #region Свойства

    public override RWSections SectionType { get { return RWSections.RWNull; } }

    #endregion

    #region Методы

    public override void LoadFromStream(BinaryReader br)
    {
      br.BaseStream.Seek(0, SeekOrigin.End);
    }

    #endregion
  }
}