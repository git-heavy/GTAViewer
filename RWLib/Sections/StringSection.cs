using System.IO;
using System.Text;

namespace Heavy.RWLib.Sections
{
  public class StringSection : DataSection
  {
    #region Свойства

    public string Data { get; private set; }

    #region RWSection

    public static new RWSections SectionType { get { return RWSections.RWString; } }

    #endregion

    #endregion

    #region Методы

    #region DataSection

    protected override void LoadData(BinaryReader br)
    {
      this.Data = ASCIIEncoding.ASCII.GetString(br.ReadBytes(this.Header.Size));
    }

    #endregion

    #endregion
  }
}