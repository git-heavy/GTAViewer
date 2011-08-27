using System.IO;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.DFFLib.Sections
{
  public class FrameSection : DataSection
  {
    #region Свойства

    public string NodeName { get; private set; }

    #region RWSection

    public override RWSections SectionType { get { return RWSections.RWFrame; } }

    #endregion

    #endregion

    #region Методы

    #region DataSection

    protected override void LoadData(BinaryReader br)
    {
      this.NodeName = br.ReadChars(this.Header.Size).ToString();
    }

    #endregion

    #endregion
  }
}