using System.IO;

namespace Heavy.RWLib.Sections
{
  public class StructureSection : DataSection
  {
    #region Свойства

    #region RWSection

    public static new RWSections SectionType { get { return RWSections.RWStruct; } }

    #endregion

    #endregion

    #region Методы

    #region DataSection

    protected override void LoadData(BinaryReader br)
    {
      // Пустой метод.
    }


    #endregion

    #endregion
  }
}
