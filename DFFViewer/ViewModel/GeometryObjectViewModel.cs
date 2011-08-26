using System.Windows.Media.Media3D;
using Heavy.DFFLib;
using Heavy.DFFLib.Sections;
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

    private int cameraWidth;

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
      get { return this.modelGroup; }
      protected set
      {
        this.modelGroup = value;
        this.OnPropertyChanged("ModelGroup");
      }
    }

    public int CameraWidth
    {
      get { return this.cameraWidth; }
      set
      {
        this.cameraWidth = value;
        this.OnPropertyChanged("CameraWidth");
      }
    }

    #region EntityViewModel

    public override string Name
    {
      get { return string.Empty; }
    }

    #endregion

    #endregion

    #region Методы

    /// <summary>
    /// Инициализировать группу моделей.
    /// </summary>
    private void InitializeModelGroup()
    {
      Model3DGroup group = new Model3DGroup();
      foreach (AtomicSection atomic in this.Entity.Clump.Atomics)
      {
        GeometryModel3D model = this.InitializeModel(atomic);
        this.ApplyModelTransformation(atomic, model);
        // TODO: материал получать из метаданных
        model.Material = new DiffuseMaterial(System.Windows.Media.Brushes.Blue);
        group.Children.Add(model);
      }
      this.ModelGroup = group;
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

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    public GeometryObjectViewModel(GeometryObject entity)
      : base(entity)
    {
      this.Center = new Point3D(0, 0, 0);
      this.InitializeModelGroup();
    }

    #endregion


  }
}
