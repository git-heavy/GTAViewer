using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Heavy.DFFLib;
using Heavy.DFFLib.Sections;
using Heavy.RWLib;

namespace DFFViewer2
{
  /// <summary>
  /// Interaction logic for ModelViewPort.xaml
  /// </summary>
  public partial class ModelViewPort : System.Windows.Controls.UserControl, INotifyPropertyChanged
  {
    #region Поля и свойства

    private Model3DGroup modelGroup = new Model3DGroup();

    /// <summary>
    /// Группа моделей.
    /// </summary>
    public Model3DGroup ModelGroup
    {
      get { return this.modelGroup; }
    }

    private AmbientLight light = new AmbientLight(Colors.Gray);

    /// <summary>
    /// Источник света.
    /// </summary>
    public Light Light
    {
      get { return null; }
    }

    private ClumpSection modelMetadata;

    /// <summary>
    /// Метаданные модели (clump-секция).
    /// </summary>
    public ClumpSection ModelMetadata
    {
      get { return this.modelMetadata; }
      set
      {
        if (this.modelMetadata != value)
        {
          this.modelMetadata = value;
          this.CreateModelGroup();
          this.OnPropertyChanged("ModelGroup");
        }
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Обработчик на изменение свойства.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    private void OnPropertyChanged(string propertyName)
    {
      if (this.PropertyChanged != null)
        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Создать группу моделей.
    /// </summary>
    private void CreateModelGroup()
    {
      this.ModelGroup.Children.Clear();
      foreach (AtomicSection atomic in this.ModelMetadata.Atomics)
        this.ModelGroup.Children.Add(this.CreateModel(atomic));
    }

    /// <summary>
    /// Создать модель.
    /// </summary>
    /// <param name="atomic">Метаданные модели (atomic-секция).</param>
    /// <returns>3D модель.</returns>
    private GeometryModel3D CreateModel(AtomicSection atomic)
    {
      GeometryModel3D model = new GeometryModel3D(this.CreateGeometry(this.ModelMetadata.GeometryList.Geometries[atomic.Structure.GeometryIndex]), null);
      this.ApplyTransformation(model, this.ModelMetadata.FrameList.Structure.Frames[atomic.Structure.FrameIndex]);
      return model;
    }

    /// <summary>
    /// Применить трансформацию к модели.
    /// </summary>
    /// <param name="model">Модель.</param>
    /// <param name="frameSection">Секция фрейма модели.</param>
    private void ApplyTransformation(GeometryModel3D model, Frame frameSection)
    {
      Matrix3D currentMatrix = this.GetMatrix(frameSection);
      while (frameSection.ParentFrame >= 0)
        currentMatrix = Matrix3D.Multiply(currentMatrix, this.GetMatrix(this.ModelMetadata.FrameList.Structure.Frames[frameSection.ParentFrame]));
      model.Transform = new MatrixTransform3D(currentMatrix);
    }

    /// <summary>
    /// Создать геометрию модели.
    /// </summary>
    /// <param name="geometrySection">Метаданные геометрии.</param>
    /// <returns>Геометрия модели.</returns>
    private MeshGeometry3D CreateGeometry(GeometrySection geometrySection)
    {
      MeshGeometry3D meshGeometry = new MeshGeometry3D();
      if (geometrySection.Structure.VertexTranslation != null)
        foreach (Vector vertex in geometrySection.Structure.VertexTranslation)
          meshGeometry.Positions.Add(new Point3D(vertex.X, vertex.Y, vertex.Z));
      if (geometrySection.Structure.Normals != null)
        foreach (Vector normal in geometrySection.Structure.Normals)
          meshGeometry.Normals.Add(new Vector3D(normal.X, normal.Y, normal.Z));
      if (geometrySection.Structure.Triangles != null)
        foreach (GeometryTriangle triangle in geometrySection.Structure.Triangles)
        {
          meshGeometry.TriangleIndices.Add(triangle.First);
          meshGeometry.TriangleIndices.Add(triangle.Second);
          meshGeometry.TriangleIndices.Add(triangle.Third);
        }
      return meshGeometry;
    }

    private Matrix3D GetMatrix(Frame frameSection)
    {
      return new Matrix3D()
      {
        M11 = frameSection.RotationMatrix[0].X,
        M12 = frameSection.RotationMatrix[0].Y,
        M13 = frameSection.RotationMatrix[0].Z,
        M21 = frameSection.RotationMatrix[1].X,
        M22 = frameSection.RotationMatrix[1].Y,
        M23 = frameSection.RotationMatrix[1].Z,
        M31 = frameSection.RotationMatrix[2].X,
        M32 = frameSection.RotationMatrix[2].Y,
        M33 = frameSection.RotationMatrix[2].Z,
        M14 = 0,
        M24 = 0,
        M34 = 0,
        M44 = 1,
        OffsetX = frameSection.Position.X,
        OffsetY = frameSection.Position.Y,
        OffsetZ = frameSection.Position.Z
      };
    }



    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public ModelViewPort()
    {
      InitializeComponent();
    }

    #endregion

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
  }
}
