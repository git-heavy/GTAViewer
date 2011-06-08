using System.Windows.Forms;
using Heavy.RWLib.Sections;

namespace Heavy.RWSectionViewer {
    class Class1 {
    }

    class SectionTreeNode : TreeNode {
        public RWSection Section {
            get {
                return this.Tag != null ? (RWSection)this.Tag : null;
            }
            private set {
                this.Tag = value;
            }
        }
        public SectionTreeNode(RWSection section)
            : base() {
            this.Section = section;
            this.Text = section.Header.ToString();
        }
    }
}
