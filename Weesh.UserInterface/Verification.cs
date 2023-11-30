using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.UserInterface
{
    public class Verification
    {
        public static bool IsArgsEmpty(string[] args)
        {
            if (args.Length != 0) return true;
            ConsoleInput.FileNotFound();
            return false;
        }
        public static bool IsPathExists(string filePath)
        {
            if (File.Exists(filePath)) return true;
            ConsoleInput.FileNotFound();
            return false;
        }
    }
}
