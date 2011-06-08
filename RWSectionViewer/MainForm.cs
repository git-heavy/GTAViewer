using System;
using System.Windows.Forms;
using Heavy.RWLib;
using Heavy.RWLib.Sections;

namespace Heavy.RWSectionViewer {
    public partial class MainForm : Form {
        private enum SectionIndexes {
            siUnknown = 0,
            siExtension = 1,
            siData = 2,
            siContainer = 3
        }

        private static SectionIndexes GetImageIndexFor(RWSection section) {
            if (section is UnknownSection) {
                return SectionIndexes.siUnknown;
            }
            if (section is ExtensionSection) {
                return SectionIndexes.siExtension;
            }
            if (section is DataSection) {
                return SectionIndexes.siData;
            }
            if (section is ContainerSection) {
                return SectionIndexes.siContainer;
            }
            return SectionIndexes.siUnknown;
        }        

        private int GetTreeImageIndex(RWSection section) {
            return 0;
        }

        private void BuildTreeNode(RWSection section, TreeNodeCollection parentNodes) {
            if (section.Header.Id != RWSections.RWNull) {
                SectionTreeNode node = new SectionTreeNode(section);
                parentNodes.Add(node);                                           
                foreach (RWSection childSeciton in section.Childs) {
                    BuildTreeNode(childSeciton, node.Nodes);
                }
            }
        }
        
        private void AddResources() {            
        }

        public MainForm() {                                    
            InitializeComponent();
            AddResources();
            ProgramManager.Instance.FileLoadedEvent += new EventHandler(FileLoadedEventHandler);
            ProgramManager.Instance.CurrentSectionChangeEvent += new EventHandler(CurrentSectionChangeEventHandler);
        }

        void CurrentSectionChangeEventHandler(object sender, EventArgs e) {
            SectionsListView.BeginUpdate();
            try {
                SectionsListView.Items.Clear();                
                if (((ProgramManager)sender).CurrentSection != null) {                    
                    foreach (RWSection curSection in ((ProgramManager)sender).CurrentSection.Childs) {
                        ListViewItem lvi = new ListViewItem();
                        lvi.ImageIndex = (int)GetImageIndexFor(curSection);
                        lvi.Text = curSection.Header.Id.ToString();
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, curSection.Header.Size.ToString()));
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, curSection.Header.Version.ToString()));
                        if (curSection is ContainerSection) {
                            lvi.Group = SectionsListView.Groups["ContainerSectionsGroup"];
                        }
                        else if (curSection is DataSection) {
                            lvi.Group = SectionsListView.Groups["DataSectionsGroup"];

                        }
                        else if (curSection is UnknownSection) {
                            lvi.Group = SectionsListView.Groups["UnknownSectionsGroup"];
                        }
                        lvi.Tag = curSection;
                        SectionsListView.Items.Add(lvi);
                    }
                }
            }
            finally {
                SectionsListView.EndUpdate();
            }            
        }

        void FileLoadedEventHandler(object sender, EventArgs e) {
            SectionsTreeView.BeginUpdate();
            try {
                if (((ProgramManager)sender).Root != null) {
                    foreach (RWSection section in ((ProgramManager)sender).Root.Childs) {
                        BuildTreeNode(section, SectionsTreeView.Nodes);
                    }
                }
            }
            finally {
                SectionsTreeView.EndUpdate();
            }            
        }

        private void OpenFileHandler(object sender, System.EventArgs e) {
            openFileDialog1.Filter = "DFF Files|*.dff";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                ProgramManager.Instance.LoadFile(openFileDialog1.FileName);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            ProgramManager.Instance.CurrentSection = e.Node != null ? (RWSection)e.Node.Tag : null;
        }

        private void TreeCollapseButton_Click(object sender, EventArgs e) {
            SectionsTreeView.BeginUpdate();
            try {
                SectionsTreeView.CollapseAll();
            }
            finally {
                SectionsTreeView.EndUpdate();
            }
        }

        private void TreeExpandButton_Click(object sender, EventArgs e) {
            SectionsTreeView.BeginUpdate();
            try {
                SectionsTreeView.ExpandAll();
            }
            finally {
                SectionsTreeView.EndUpdate();
            }
        }

    }
}
