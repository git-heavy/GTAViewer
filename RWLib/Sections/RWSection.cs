using System.Collections.Generic;
using System.IO;

namespace Heavy.RWLib.Sections
{
  public class RWSection : IStreamLoadeable
  {
    #region Свойства

    public RWSectionHeader Header { get; set; }

    public RWSection Parent { get; set; }

    public List<RWSection> Childs { get; set; }

    public static RWSections SectionType { get { return RWSections.RWDefault; } }

    public static RWSections ParentSectionType { get { return RWSections.RWDefault; } }

    #endregion

    #region Конструкторы
    
    public RWSection()
    {
      Childs = new List<RWSection>();
    }

    #endregion
    
    #region Методы

    public virtual void LoadFromStream(BinaryReader br)
    {
      br.BaseStream.Seek(this.Header.StartPos + this.Header.Size, SeekOrigin.Begin);
    }

    #endregion
  }
}