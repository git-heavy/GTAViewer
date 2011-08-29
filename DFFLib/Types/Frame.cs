// -----------------------------------------------------------------------
// <copyright file="Frame.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using Heavy.RWLib;
using Heavy.RWLib.Types;

namespace Heavy.DFFLib.Types
{
  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public class Frame : IStreamLoadeable
  {
    #region Поля и свойства

    public Vector[] RotationMatrix { get; private set; }

    public Vector Position { get; private set; }

    public int ParentFrame { get; private set; }

    public int Flags { get; private set; }

    #endregion

    #region Конструкторы

    public Frame()
    {
      this.Position = new Vector();
      this.RotationMatrix = new Vector[3] { new Vector(), new Vector(), new Vector() };
    }

    #endregion

    #region IStreamLoadeable

    public void LoadFromStream(BinaryReader reader)
    {
      foreach (Vector vct in this.RotationMatrix)
        vct.LoadFromStream(reader);
      this.Position.LoadFromStream(reader);
      this.ParentFrame = reader.ReadInt32();
      this.Flags = reader.ReadInt32();
    }

    #endregion
  }
}
