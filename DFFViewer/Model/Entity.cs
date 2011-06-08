using System.ComponentModel;

namespace Heavy.DFFViewer.Model
{
  /// <summary>
  /// Базовая сущность.
  /// </summary>
  public abstract class Entity : INotifyPropertyChanged, IDataErrorInfo
  {
    #region Поля и свойства

    private string name;

    /// <summary>
    /// Имя сущности.
    /// </summary>
    public string Name
    {
      get
      {
        return this.name;
      }

      set
      {
        this.name = value;
        this.OnPropertyChanged("Name");
      }
    }

    /// <summary>
    /// Текст ошибки.
    /// </summary>
    public string Error
    {
      get { return "Объект содержит ошибки данных."; }
    }

    /// <summary>
    /// Текст ошибки определённого свойства.
    /// </summary>
    /// <param name="columnName">Имя свойства.</param>
    /// <returns>Текст ошибки.</returns>
    public virtual string this[string columnName]
    {
      get { return null; }
    }

    #endregion

    #region События

    /// <summary>
    /// Событие на изменение свойства.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Сгенерировать событие на изменение свойства.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    protected void OnPropertyChanged(string propertyName)
    {
      if (this.PropertyChanged != null)
        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
  }
}
