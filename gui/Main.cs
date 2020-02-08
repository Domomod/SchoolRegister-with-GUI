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
                Backendoptions.CloseConnection();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Backendoptions.CloseConnection();
            }
        }
    }
}
