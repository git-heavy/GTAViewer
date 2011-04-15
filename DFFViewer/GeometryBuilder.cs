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

    private GeometryModel3D CreateModel(GeometrySection geometrySection)
    {          
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
          mesh.TriangleIndices.Add(triangle.First);
          mesh.TriangleIndices.Add(triangle.Second);
          mesh.TriangleIndices.Add(triangle.Third);
        }
      return new GeometryModel3D() { Geometry = mesh };      
    }

    private void ApplyTransformation(GeometryModel3D model, Frame[] frames, int currentFrameIndex)
    {
      Transform3DGroup transformGroup = new Transform3DGroup();      
      while (currentFrameIndex != 0)
      {
        Frame frame = frames[currentFrameIndex];
        TranslateTransform3D translate = new TranslateTransform3D(frame.Position.X, frame.Position.Y, frame.Position.Z);
        transformGroup.Children.Add(translate);
        RotateTransform3D rotate = new RotateTransform3D();
        



        currentFrameIndex = frame.FrameIndex;
      }      
    }

    public Model3DGroup Build()
    {
      foreach (AtomicSection atomic in this._clump.Atomics)
      {
        GeometryModel3D model = this.CreateModel(this._clump.GeometryList.Geometries[atomic.Structure.GeometryIndex]);
        //this.ApplyTransformation(model, this._clump.FrameList.Structure.Frames, atomic.Structure.FrameIndex);
        model.Material = new DiffuseMaterial(Brushes.Blue);
        this._modelGroup.Children.Add(model);
      }
      return this._modelGroup;
    }

    #endregion
  }
}
