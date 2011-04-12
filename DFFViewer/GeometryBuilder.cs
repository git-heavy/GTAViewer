using System.Windows.Media;
using System.Windows.Media.Media3D;
using DFFLib;
using RWLib;

namespace DFFViewer
{
  class GeometryBuilder
  {
    #region Конструкторы

    public GeometryBuilder(ClumpSection clump)
    {
      this._clump = clump;
      this._modelGroup = new Model3DGroup();
    }

    #endregion

    #region Поля и свойства

    private ClumpSection _clump;

    private Model3DGroup _modelGroup;

    #endregion

    #region Методы

    private GeometryModel3D BuildModel(AtomicSection atomic)
    {
      GeometryModel3D model = new GeometryModel3D();
      GeometrySection geometrySection = _clump.GeometryList.Geometries[atomic.Structure.GeometryIndex];
      MeshGeometry3D mesh = new MeshGeometry3D();
      if (geometrySection.Structure.VertexTranslation != null)
        foreach (Vector vertex in geometrySection.Structure.VertexTranslation)
          mesh.Positions.Add(new Point3D(vertex.X, vertex.Y, vertex.Z));

      if (geometrySection.Structure.Normals != null)
        foreach (Vector normal in geometrySection.Structure.Normals)
          mesh.Normals.Add(new Vector3D(normal.X, normal.Y, normal.Z));

      if (geometrySection.Structure.Triangles != null)
        foreach (GeometryTriangle triangle in geometrySection.Structure.Triangles)
        {
          mesh.TriangleIndices.Add(triangle.First - 1);
          mesh.TriangleIndices.Add(triangle.Second - 1);
          mesh.TriangleIndices.Add(triangle.Third - 1);
        }
      model.Geometry = mesh;
      return model;
    }

    private void ApplyTransformation(GeometryModel3D model, AtomicSection atomic)
    {
      Transform3DGroup transformGroup = new Transform3DGroup();
      int frameIndex = atomic.Structure.FrameIndex;
      while (frameIndex != 0)
      {
        Frame frame = _clump.FrameList.Structure.Frames[frameIndex];        
        TranslateTransform3D translate = new TranslateTransform3D(frame.Position.X, frame.Position.Y, frame.Position.Z);
        transformGroup.Children.Add(translate);



        frameIndex = frame.FrameIndex;
      }      
    }

    public Model3DGroup Build()
    {
      foreach (AtomicSection atomic in this._clump.Atomics)
      {
        GeometryModel3D model = this.BuildModel(atomic);
        model.Material = new DiffuseMaterial(Brushes.Blue);
        this._modelGroup.Children.Add(model);
      }
      return this._modelGroup;
    }

    #endregion
  }
}
