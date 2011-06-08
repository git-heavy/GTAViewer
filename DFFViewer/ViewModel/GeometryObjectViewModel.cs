﻿using System.Windows.Media.Media3D;
using Heavy.DFFLib;
using Heavy.DFFLib.Sections;
using Heavy.DFFViewer.Helper;
using Heavy.DFFViewer.Model;
using Heavy.RWLib;

namespace Heavy.DFFViewer.ViewModel
{
  public class GeometryObjectViewModel : EntityViewModel<GeometryObject>
  {
    #region Поля

    /// <summary>
    /// Координаты центра объекта.
    /// </summary>
    private Point3D center;

    /// <summary>
    /// Группа моделей.
    /// </summary>
    private Model3DGroup modelGroup;

    /// <summary>
    /// Команда загрузки модели.
    /// </summary>
    private DelegateCommand loadModelCommand;

    #endregion

    #region Свойства

    /// <summary>
    /// Координаты центра объекта.
    /// </summary>
    public Point3D Center
    {
      get { return this.center; }
      protected set
      {
        this.center = value;
        this.OnPropertyChanged("Center");
      }
    }

    /// <summary>
    /// Группа моделей.
    /// </summary>
    public Model3DGroup ModelGroup
    {
      get
      {
        return this.modelGroup;
      }
      protected set
      {
        this.modelGroup = value;
        this.OnPropertyChanged("ModelGroup");
      }
    }

    public DelegateCommand LoadModelCommand
    {
      get
      {
        return this.loadModelCommand ?? (this.loadModelCommand = new DelegateCommand(this.LoadModelCommandExecute, this.LoadModelCommandCanExecute));
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Инициализировать группу моделей.
    /// </summary>
    private void InitializeModelGroup()
    {
      Model3DGroup group = new Model3DGroup();
      foreach (AtomicSection atomic in this.Entity.Clump.Atomics){
        GeometryModel3D model = this.InitializeModel(atomic);
        this.ApplyModelTransformation(atomic, model);
        group.Children.Add(model);
      }
    }

    /// <summary>
    /// Применить трансформацию.
    /// </summary>
    /// <param name="atomic">Atomic-секция.</param>
    /// <param name="model">Модель.</param>
    private void ApplyModelTransformation(AtomicSection atomic, GeometryModel3D model)
    {
    }

    /// <summary>
    /// Добавляет модель в группу.
    /// </summary>
    private GeometryModel3D InitializeModel(AtomicSection atomic)
    {
      MeshGeometry3D mesh = new MeshGeometry3D();
      GeometrySection geometrySection = this.Entity.Clump.GeometryList.Geometries[atomic.Structure.GeometryIndex];
      if (geometrySection.Structure.VertexTranslation != null)
        foreach (Vector vertex in geometrySection.Structure.VertexTranslation)
          mesh.Positions.Add(new Point3D(vertex.X, vertex.Y, vertex.Z));
      if (geometrySection.Structure.Normals != null)
        foreach (Vector normal in geometrySection.Structure.Normals)
          mesh.Normals.Add(new Vector3D(normal.X, normal.Y, normal.Z));
      if (geometrySection.Structure.Triangles != null)
        foreach (GeometryTriangle triangle in geometrySection.Structure.Triangles)
        {
          mesh.TriangleIndices.Add(triangle.First);
          mesh.TriangleIndices.Add(triangle.Second);
          mesh.TriangleIndices.Add(triangle.Third);
        }
      return new GeometryModel3D() { Geometry = mesh };
    }

    private void LoadModelCommandExecute(object parameter)
    {

    }

    private bool LoadModelCommandCanExecute(object parameter)
    {
      return true;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    public GeometryObjectViewModel(GeometryObject entity)
      : base(entity)
    {
      this.InitializeModelGroup();
    }

    #endregion    

    #region EntityViewModel

    public override string Name
    {
      get { return string.Empty; }
    }

    #endregion
  }
}