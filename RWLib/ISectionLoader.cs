// -----------------------------------------------------------------------
// <copyright file="ISectionLoader.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using Heavy.RWLib.Sections;

namespace Heavy.RWLib
{
  /// <summary>
  /// Интерфейс загрузчика секций.
  /// </summary>
  public interface ISectionLoader
  {
    /// <summary>
    /// Получить фабрику секций.
    /// </summary>
    /// <param name="header">Заголовок секции.</param>
    /// <param name="parent">Родительская секция.</param>
    /// <returns>Фабрика секций.</returns>
    IRWSectionFactory GetFactory(RWSectionHeader header, RWSection parent);
  }
}
