// -----------------------------------------------------------------------
// <copyright file="SceneViewModel.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Media;
using System.Windows.Media.Media3D;
using Heavy.DFFLib.Sections;
using Heavy.DFFLib.Types;
using Heavy.RWLib.Types;
namespace Heavy.DFFViewer.ViewModels
{

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class SceneViewModel : BaseViewModel
  {
    private Model3DGroup modelGroup = new Model3DGroup();

    public Model3DGroup ModelGroup
    {
      get
      {
        return this.modelGroup;
      }

      set
      {
        this.modelGroup = value;
        this.OnPropertyChanged(() => ModelGroup);
      }
    }

    private Light light = new AmbientLight(Colors.White);

    public Light Light
    {
      get
      {
        return this.light;
      }
    }

    private ClumpSection modelGroupMetadata;

    public ClumpSection ModelGroupMetadata
    {
      get { return this.modelGroupMetadata; }
      set
      {
        this.modelGroupMetadata = value;
        this.OnPropertyChanged(() => ModelGroupMetadata);
        this.InitializeModelGroupMetadata();
        this.OnPropertyChanged(() => ModelGroup);
      }
    }

    private void InitializeModelGroupMetadata()
    {
      this.ModelGroup.Children.Clear();
      foreach (AtomicSection atomic in this.ModelGroupMetadata.Atomics)
        this.ModelGroup.Children.Add(this.CreateModel(atomic));
    }

    /// <summary>
    /// Создать модель.
    /// </summary>
    /// <param name="atomic">Метаданные модели (atomic-секция).</param>
    /// <returns>3D модель.</returns>
    private GeometryModel3D CreateModel(AtomicSection atomic)
    {
      GeometryModel3D model = new GeometryModel3D(this.CreateGeometry(this.ModelGroupMetadata.GeometryList.Geometries[atomic.Structure.GeometryIndex]), new DiffuseMaterial(Brushes.Gray));
      this.ApplyTransformation(model, this.ModelGroupMetadata.FrameList.Structure.Frames[atomic.Structure.FrameIndex]);
      return model;
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

    /// <summary>
    /// Применить трансформацию к модели.
    /// </summary>
    /// <param name="model">Модель.</param>
    /// <param name="frameSection">Секция фрейма модели.</param>
    private void ApplyTransformation(GeometryModel3D model, Frame frameSection)
    {
      Matrix3D currentMatrix = this.GetMatrix(frameSection);
      while (frameSection.ParentFrame >= 0)
        currentMatrix = Matrix3D.Multiply(currentMatrix, this.GetMatrix(this.ModelGroupMetadata.FrameList.Structure.Frames[frameSection.ParentFrame]));
      model.Transform = new MatrixTransform3D(currentMatrix);
    }
  }
}
