// -----------------------------------------------------------------------
// <copyright file="IStreamLoadeable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;

namespace Heavy.RWLib
{
  /// <summary>
  /// Интерфейс загружаемого из потока элемента.
  /// </summary>
  public interface IStreamLoadeable
  {
    /// <summary>
    /// Загрузить из потока.
    /// </summary>
    /// <param name="reader">Reader потока.</param>
    void LoadFromStream(BinaryReader reader);
  }
}
