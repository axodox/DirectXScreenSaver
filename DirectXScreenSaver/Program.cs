using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DirectXScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                switch (args[0].ToLower())
                {
                    case "/c":
                        Application.Run(new ConfigForm());
                        break;
                    case "/s":
                        StartScreensaver();
                        break;
                }
            }
            else
                Application.Run(new ConfigForm());
            if (System.IO.Path.GetExtension(Application.ExecutablePath) != "scr")
            {
                try
                {
                    string scrPath = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".scr";
                    if (System.IO.File.Exists(scrPath)) System.IO.File.Delete(scrPath);
                    System.IO.File.Move(Application.ExecutablePath, scrPath);
                }
                catch
                {
                    ;
                }
            }
        }

        static void StartScreensaver()
        {
            Application.Run(new MainForm());
        }
    }
}
