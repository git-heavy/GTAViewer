using System.IO;
using Heavy.RWLib.Sections;

namespace Heavy.RWLib
{
  /// <summary>
  /// Интерфейс фабрики секций.
  /// </summary>
  public interface IRWSectionFactory
  {
    #region Методы

    /// <summary>
    /// Получить секцию.
    /// </summary>
    /// <param name="reader">Reader потока.</param>
    /// <param name="header">Заголовок секции.</param>
    /// <returns>Секция.</returns>
    RWSection GetSection(BinaryReader reader, RWSectionHeader header);

    #endregion
  }

  /// <summary>
  /// Фабрика секций.
  /// </summary>
  /// <typeparam name="T">Тип секции.</typeparam>
  public class RWSectionFactory<T> : IRWSectionFactory where T : RWSection, new()
  {
    #region IRWSectionFactory

    RWSection IRWSectionFactory.GetSection(BinaryReader reader, RWSectionHeader header)
    {
      return this.GetSection<T>(reader, header);
    }

    #endregion

    #region Методы

    /// <summary>
    /// Получить секцию.
    /// </summary>
    /// <typeparam name="TSection">Тип секции.</typeparam>
    /// <param name="reader">Reader потока.</param>
    /// <param name="header">Заголовок секции.</param>
    /// <returns>Секция.</returns>
    public virtual TSection GetSection<TSection>(BinaryReader reader, RWSectionHeader header) where TSection : RWSection, new()
    {
      TSection section = new TSection();
      section.Header = header;
      (section as IStreamLoadeable).LoadFromStream(reader);
      return section;
    }

    #endregion
  }

  /// <summary>
  /// Фабрика получения корневых секций.
  /// </summary>
  class RootSectionFactory : RWSectionFactory<RootSection>, IRWSectionFactory
  {
    #region IRWSectionFactory

    public RWSection GetSection(BinaryReader reader, RWSectionHeader header)
    {
      RootSection section = new RootSection();
      section.Header = header;
      return section;
    }

    #endregion
  }
}
