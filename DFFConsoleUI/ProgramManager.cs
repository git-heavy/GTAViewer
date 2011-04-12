using System;
using System.IO;
using RWLib;

namespace RWConsoleUI {
    public class ProgramManager {
        /* private */
        private RootSection _root;
        private void LoadModel(string fileName) {
            if (!File.Exists(fileName)) {
                throw new Exception(String.Format("File '{0}' not exists", fileName));
            }
            else {
                using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
                    this.Root = SectionLoaderManager.Instance.LoadFromStream(fs) as RootSection;
                }
            }
        }
        private string GetPathString() {
            RWSection parentSection = this.Current;
            string path = String.Empty;
            while (parentSection != null) {
                path = String.Format("{0}/{1}", parentSection.Header.Id, path);
                parentSection = parentSection.Parent;
            }
            return path;
        }
        /* public */
        public RootSection Root {
            get {
                return this._root;
            }
            private set {
                this._root = value;
                this.Current = this.Root;
            }
        }
        public RWSection Current { get; internal set; }
        public ProgramManager(string fileName) {
            LoadModel(fileName);
        }
        public void Execute() {
            CommandParser parser = new CommandParser();
            Command cmd = null;
            string cmdString;
            do {
                Console.Write("{0}$ ", GetPathString());
                cmdString = Console.ReadLine();
                try {
                    cmd = parser.Parse(cmdString);                    
                    cmd.Execute(this);
                }
                catch (Exception ex) {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            } while (!(cmd is ExitCommand));
        }
    }
}
