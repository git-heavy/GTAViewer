using System;
using System.Linq;
using RWLib;

namespace RWConsoleUI {
    class CommandParser {                
        public Command Parse(string cmdString) {
            Command cmd = null;
            string[] strings = (from s in cmdString.ToLower().Split(new char[] { ' ' })
                                    where (String.Compare(s.Trim(), string.Empty) != 0)
                                    select s).ToArray<string>();
            if (strings.Length == 0) {
                cmd = new DummyCommand();
            }
            else {
                if ((strings[0] == ExitCommand.AsString) && (strings.Length == 1)) {
                    cmd = new ExitCommand();
                }
                else
                    if ((strings[0] == ListCommand.AsString) && (strings.Length == 1)) {
                        cmd = new ListCommand();
                    }
                    else
                        if ((strings[0] == ChangeSectionCommand.AsString)) {
                            if (strings.Length == 2) {
                                if (strings[1] == "..") {
                                    cmd = new GoToParentCommand();
                                }
                                else
                                    if (strings[1] == "/") {
                                        cmd = new GoToRootCommand();
                                    }
                                    else {
                                        int sectionTypeId;
                                        if (int.TryParse(strings[1], out sectionTypeId)) {
                                            cmd = new GoToChildSection();
                                            (cmd as GoToChildSection).NewSectionType = sectionTypeId;
                                        }
                                    }

                            }
                            if (strings.Length == 3) {
                                cmd = new GoToChildSection();
                                (cmd as GoToChildSection).NewSectionType = int.Parse(strings[1]);
                                (cmd as GoToChildSection).NewSectionNumber = int.Parse(strings[2]);
                            }
                        }
            }
            if (cmd == null){
                cmd = new UnknownCommand();
            }
            return cmd;
        }
    }

    abstract class Command {
        public static string AsString { get { return String.Empty; } }
        public abstract void Execute(ProgramManager pm);
    }

    class DummyCommand : Command {
        #region Command
        public override void Execute(ProgramManager pm) {
            // Пустой метод.
        }
        #endregion
    }

    class UnknownCommand : Command {
        #region Command
        public override void Execute(ProgramManager pm) {
            Console.WriteLine("Unknown command");
        }
        #endregion
    }

    class ExitCommand : Command {
        #region Command
        public static new string AsString { get { return "exit"; } }
        public override void Execute(ProgramManager pm) {
            Console.WriteLine("Goodbye!");
        }
        #endregion
    }

    class ListCommand : Command {        
        #region Command
        public static new string AsString { get { return "ls"; } }               
        public override void Execute(ProgramManager pm) {
            foreach (RWSection section in pm.Current.Childs) {
                Console.WriteLine(section.Header);
            }
        }
        #endregion
    }

    abstract class ChangeSectionCommand: Command {        
        protected abstract RWSection GetNewSection(ProgramManager pm);
        #region Command
        public static new string AsString { get { return "cd"; } }        
        public override void Execute(ProgramManager pm){
            pm.Current = GetNewSection(pm);
        }
        #endregion
    }

    class GoToParentCommand : ChangeSectionCommand {
        #region ChangeSectionCommand
        protected override RWSection GetNewSection(ProgramManager pm) {
            if (pm.Current != pm.Root) {
                return pm.Current.Parent;
            }
            else
                throw new Exception("You are already in the root section");
        }
        #endregion
    }

    class GoToRootCommand : ChangeSectionCommand {
        #region ChangeSectionCommand
        protected override RWSection GetNewSection(ProgramManager pm) {
            return pm.Root;
        }
        #endregion
    }

    class GoToChildSection : ChangeSectionCommand {
        public int NewSectionType { get; set; }
        public int NewSectionNumber { get; set; }
        #region ChangeSectionCommand
        protected override RWSection GetNewSection(ProgramManager pm) {
            RWSection[] childSections = (from c in pm.Current.Childs
                                         where (int)c.Header.Id == this.NewSectionType
                                         select c).ToArray() as RWSection[];            
            if (this.NewSectionNumber < childSections.Length) {
                return childSections[NewSectionNumber];
            }
            else {
                throw new Exception(String.Format("There is no child section {O}[{1}]", this.NewSectionType, this.NewSectionNumber));
            }
        }
        #endregion
    }
}
