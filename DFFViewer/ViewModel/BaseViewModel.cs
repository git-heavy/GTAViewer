﻿using System.ComponentModel;

namespace Heavy.DFFViewer.ViewModel
{
  /// <summary>
  /// Базовый класс модели представления.
  /// </summary>
  public abstract class BaseViewModel : INotifyPropertyChanged
  {
    #region Поля и свойства

    /// <summary>
    /// Имя модели представления.
    /// </summary>
    public abstract string Name { get; }

    #endregion

    #region События

    /// <summary>
    /// Событие на изменение свойства.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Сгенерировать событие на изменение свойства.
    /// </summary>
    /// <param name="propertyName">Имя изменённого свойства.</param>
    protected void OnPropertyChanged(string propertyName)
    {
      if (this.PropertyChanged != null)
        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
  }
}
