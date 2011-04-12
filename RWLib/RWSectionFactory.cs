using System.IO;

namespace RWLib {
    public abstract class RWSectionFactory {
        public bool IsDefault { get; internal set; }
        public abstract RWSection GetSection(BinaryReader br, RWSectionHeader sh);
    }

    // Фабрика создает секции своего класса.
    public class RWSectionFactory<T>: RWSectionFactory where T: RWSection, new()  {
        public override RWSection GetSection(BinaryReader br, RWSectionHeader sh) {
            return GetSection<T>(br, sh);
        }

        public virtual TSection GetSection<TSection>(BinaryReader br, RWSectionHeader sh) where TSection: RWSection, new() {
            TSection section = new TSection();
            section.Header = sh;                        
            (section as IStreamLoadeable).LoadFromStream(br);
            return section;
        }
    }

    class RootSectionFactory : RWSectionFactory<RootSection> {
        public override RWSection GetSection(BinaryReader br, RWSectionHeader sh) {
            RootSection section = new RootSection();
            section.Header = sh;
            return section as RWSection;
        }
    }
}
