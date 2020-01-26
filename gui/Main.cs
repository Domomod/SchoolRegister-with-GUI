using AppKit;
using System;
namespace gui
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
            NSApplication.Init();
            NSApplication.Main(args);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
