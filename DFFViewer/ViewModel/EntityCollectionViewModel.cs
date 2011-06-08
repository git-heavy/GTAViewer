using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Heavy.DFFViewer.Model;

namespace Heavy.DFFViewer.ViewModel
{
  /// <summary>
  /// Базовый класс модели представления коллекции сущностей.
  /// </summary>
  /// <typeparam name="T">Тип сущности.</typeparam>
  public abstract class EntityCollectionViewModel<T> : BaseViewModel
    where T : Entity
  {
    #region Поля и свойства

    private ObservableCollection<T> entityCollection;

    /// <summary>
    /// Коллекция сущностей.
    /// </summary>
    public ObservableCollection<T> EntityCollection
    {
      get
      {
        return this.entityCollection;
      }

      protected set
      {
        this.entityCollection = value;
        this.OnPropertyChanged("EntityCollection");
      }
    }

    private T entity;

    /// <summary>
    /// Текущая выбранная в списке сущность.
    /// </summary>
    public T SelectedEntity
    {
      get
      {
        return this.entity;
      }

      set
      {
        this.entity = value;
        this.OnPropertyChanged("SelectedEntity");
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

      EntityCollectionViewModel<T> entityCollectionViewModel = obj as EntityCollectionViewModel<T>;
      if (entityCollectionViewModel == null)
        return false;

      if (this.EntityCollection.Count != entityCollectionViewModel.EntityCollection.Count)
        return false;

      return !this.EntityCollection.Where((t, i) => t.Name != entityCollectionViewModel.EntityCollection[i].Name).Any();
    }

    /// <summary>
    /// Получить хэш объекта.
    /// </summary>
    /// <returns>Хэш объекта.</returns>
    public override int GetHashCode()
    {
      return this.EntityCollection.GetHashCode();
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="entityCollection">Коллекция сущностей.</param>
    protected EntityCollectionViewModel(IEnumerable<T> entityCollection)
    {
      if (entityCollection == null)
        throw new ArgumentNullException("entityCollection");

      this.EntityCollection = new ObservableCollection<T>(entityCollection);
    }

    #endregion
  }
}
