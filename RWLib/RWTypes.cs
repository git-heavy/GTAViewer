using System.IO;
using Heavy.RWLib.Sections;

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

  /// <summary>
  /// Вектор.
  /// </summary>
  public struct Vector : IStreamLoadeable
  {
    public float X;

    public float Y;

    public float Z;

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.X = reader.ReadSingle();
      this.Y = reader.ReadSingle();
      this.Z = reader.ReadSingle();
    }

    #endregion
  }

  /// <summary>
  /// Цвет.
  /// </summary>
  public struct ColorAmount : IStreamLoadeable
  {
    public float R;

    public float G;

    public float B;

    public float A;

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.R = reader.ReadSingle();
      this.G = reader.ReadSingle();
      this.B = reader.ReadSingle();
      this.A = reader.ReadSingle();
    }

    #endregion
  }

  /// <summary>
  /// Координаты текстуры.
  /// </summary>
  public struct TextureCoordinate : IStreamLoadeable
  {
    public float U;

    public float V;

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      this.U = reader.ReadSingle();
      this.V = reader.ReadSingle();
    }

    #endregion
  }
}
