using System;
using Heavy.DFFViewer.Model;

namespace Heavy.DFFViewer.ViewModel
{
  /// <summary>
  /// Базовый класс модели представления сущности.
  /// </summary>
  /// <typeparam name="T">Тип сущности.</typeparam>
  public abstract class EntityViewModel<T> : BaseViewModel
    where T : Entity
  {
    #region Поля и свойства

    private T entity;

    /// <summary>
    /// Сущность.
    /// </summary>
    public T Entity
    {
      get
      {
        return this.entity;
      }

      protected set
      {
        this.entity = value;
        this.OnPropertyChanged("Entity");
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Получить признак, что объекты эквивалентны.
    /// </summary>
    /// <param name="obj">Объект с которым производится сравнение.</param>
    /// <returns>Признак, что объекты эквивалентны.</returns>
    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;

      EntityViewModel<T> entityViewModel = obj as EntityViewModel<T>;
      if (entityViewModel == null)
        return false;

      return this.Entity.Name == entityViewModel.Entity.Name;
    }

    /// <summary>
    /// Получить хэш объекта.
    /// </summary>
    /// <returns>Хэш объекта.</returns>
    public override int GetHashCode()
    {
      return this.Entity.Name.GetHashCode();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    protected EntityViewModel(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");

      this.Entity = entity;
    }

    #endregion
  }
}
