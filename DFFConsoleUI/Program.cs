using System;

namespace Heavy.RWConsoleUI {
    class Program {        
        private static void Main(string[] args) {            
            if (args.Length == 1) {
                ProgramManager pm = new ProgramManager(args[0]);
                Console.WriteLine("Model loaded successfully");
                pm.Execute();                
            }
            else {
                Console.WriteLine("Error in parameters");
            }                        
            Console.WriteLine("Press any key to contiue...");
            Console.ReadKey();            
        }        
    }
}
