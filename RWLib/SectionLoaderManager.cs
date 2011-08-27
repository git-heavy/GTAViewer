using System.Collections.Generic;
using System.IO;
using Heavy.RWLib.Sections;

namespace Heavy.RWLib
{
  /// <summary>
  /// Менеджер загрузки секций.
  /// </summary>
  public class SectionLoaderManager
  {
    #region Singleton Implementation

    private static SectionLoaderManager instance;

    public static SectionLoaderManager Instance
    {
      get
      {
        if (instance == null)
          instance = new SectionLoaderManager();
        return instance;
      }
    }

    #endregion

    #region Константы

    private const byte HeaderSize = 12;

    #endregion

    private List<ISectionLoader> loaders = new List<ISectionLoader>();

    public void RegisterLoader(ISectionLoader sectionLoader)
    {
      loaders.Add(sectionLoader);
    }

    private IRWSectionFactory GetFactory(RWSectionHeader header, RWSection parent)
    {
      IRWSectionFactory factory = null;
      foreach (ISectionLoader loader in loaders)
      {
        factory = loader.GetFactory(header, parent);
        if (factory != null)
          return factory;
      }
      return (new RWSectionLoader() as ISectionLoader).GetFactory(header, parent);
    }

    private RWSection LoadSection(BinaryReader reader, RWSection parentSection)
    {
      RWSectionHeader header = new RWSectionHeader();
      header.LoadFromStream(reader);
      RWSection section = this.GetFactory(header, parentSection).GetSection(reader, header);
      if ((section is UnknownSection) && IsContainerSection(reader, header, parentSection))
        section = (new RWSectionFactory<ContainerSection>() as IRWSectionFactory).GetSection(reader, header);
      return section;
    }

    private bool IsContainerSection(BinaryReader reader, RWSectionHeader header, RWSection parent)
    {
      reader.BaseStream.Seek(header.StartPos, SeekOrigin.Begin);
      if (header.Size > HeaderSize)
      {
        RWSectionHeader newHeader = new RWSectionHeader();
        newHeader.LoadFromStream(reader);
        if ((newHeader.Version == header.Version) && (newHeader.Size < header.Size))
        {
          reader.BaseStream.Seek(header.StartPos, SeekOrigin.Begin);
          return true;
        }
      }
      reader.BaseStream.Seek(header.StartPos + header.Size, SeekOrigin.Begin);
      return false;
    }

    internal void LoadSections(BinaryReader reader, RWSection parent)
    {
      while (reader.BaseStream.Position < parent.Header.StartPos + parent.Header.Size)
      {
        RWSection section = LoadSection(reader, parent);
        if (section != null)
        {
          section.Parent = parent;
          parent.Childs.Add(section);
        }
      }
    }

    public RootSection LoadFromStream(Stream stream)
    {
      stream.Seek(0, SeekOrigin.Begin);
      using (BinaryReader reader = new BinaryReader(stream))
      {
        RootSection rootSection = new RootSectionFactory().GetSection(reader, RWSectionHeader.GetRootHeader(reader)) as RootSection;
        LoadSections(reader, rootSection);
        return rootSection;
      }
    }
  }
}
