using Heavy.RWLib.Sections;

namespace Heavy.RWLib
{
  /// <summary>
  /// Загрузчик секций.
  /// </summary>
  public class RWSectionLoader : ISectionLoader
  {
    #region ISectionLoader

    public IRWSectionFactory GetFactory(RWSectionHeader header, RWSection parent)
    {
      switch (header.Id)
      {
        case RWSections.RWNull:
          return new RWSectionFactory<NullSection>();
        case RWSections.RWExtension:
          return new RWSectionFactory<ExtensionSection>();
        case RWSections.RWStruct:
          return new RWSectionFactory<StructureSection>();
        default:
          return new RWSectionFactory<UnknownSection>();
      }
    }

    #endregion
  }
}
