using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace Saatphere_WIN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        public static string ReadResourceValue(string file, string key)
        {

            string resourceValue = string.Empty;
            try
            {

                string resourceFile = file;

                string filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

                ResourceManager resourceManager = ResourceManager.CreateFileBasedResourceManager(resourceFile, filePath, null);
                // retrieve the value of the specified key
                resourceValue = resourceManager.GetString(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resourceValue = string.Empty;
            }
            return resourceValue;
        }


    }
}
